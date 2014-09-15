
using Npgsql;
using System;
using System.Collections.Generic;
using BrightIdeasSoftware;
using System.Reflection;

namespace CornTracker
{   
    // Базовый абстрактный класс для всех записей (строк в таблице) базы данных
    public abstract class Record
    {
        protected Record() { }

        // Инициализирует запись данными из DataReader
        protected Record(NpgsqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if( !reader.IsDBNull(i) )
                    this.GetType().GetProperty(reader.GetName(i)).SetValue(this, reader.GetValue(i), null);
        }

        // Присваивает текущей записи свойства другой
        public void CopyPropertiesFrom(Record record)
        {
            foreach (PropertyInfo info in record.GetType().GetProperties())
            {
                if (IsField(info))
                {
                    PropertyInfo myInfo = this.GetType().GetProperty(info.Name);
                    myInfo.SetValue(this, info.GetValue(record, null), null);
                }
            }
        }

        // Проверяет, является ли указаное свойство полем базы данных
        private bool IsField(PropertyInfo info)
        {
            object[] attributes = info.GetCustomAttributes(typeof(Field), true);
            return attributes.Length > 0;
        }

        // Возвращает имя таблицы в базе данных, которой соответстует эта запись
        virtual public string GetTableName()
        {
            return this.GetType().Name.ToLower() + "s";
        }

        // Выполняет INSERT-запрос данной записи с указанными параметрами
        public int Insert(List<Parameter> parameters)
        {
            var columns = new List<string>();
            var values = new List<string>();
            foreach (var parameter in parameters)
            {
                columns.Add(parameter.Name);
                values.Add(parameter.SQLString);
            }

            string queryString = String.Format(
                "INSERT INTO {0} ({1}) VALUES ({2}) RETURNING id",
                GetTableName(), String.Join(", ", columns), String.Join(", ", values)
            );

            var command = DataProvider.CreateCommand(queryString, parameters);
            int id = (int)command.ExecuteScalar();
            this.id = id;
            return id;
        }

        // Выполняет INSERT-запрос
        public int Insert()
        {
            var parameters = GetUniqueParameters();
            return Insert(parameters);
        }

        // Выполняет UPDATE-запрос данной записи с указанными параметрами
        public void Update(List<Parameter> parameters)
        {
            var pairs = new List<string>();
            foreach (var parameter in parameters)
                pairs.Add(parameter.Name + " = " + parameter.SQLString);

            string queryString = String.Format(
                "UPDATE {0} SET {1} WHERE id = {2}",
                GetTableName(), String.Join(", ", pairs), id
            );

            var command = DataProvider.CreateCommand(queryString, parameters);
            command.ExecuteNonQuery();
        }

        // Выполняет UPDATE-запрос полей, отличных от указанной записи 
        public void Update(Record defaultRecord = null)
        {
            var parameters = GetUniqueParameters(defaultRecord);
            Update(parameters);
        }

        // Возвращает поля записи, отличные от заданной записи, в виде списка параметров для запроса 
        public List<Parameter> GetUniqueParameters(Record defaultRecord = null)
        {
            var parameters = new List<Parameter>();
            foreach (PropertyInfo info in this.GetType().GetProperties())
            {
                if (info.Name == "id" || !IsField(info))
                    continue;
                
                var value = info.GetValue(this, null);

                if( defaultRecord != null )
                {
                    var defaultInfo = defaultRecord.GetType().GetProperty(info.Name);
                    var defaultValue = defaultInfo.GetValue(defaultRecord, null);

                    if (Utils.ToString(value) == Utils.ToString(defaultValue))
                    //if( value.Equals(defaultValue) )
                        continue;
                }

                parameters.Add(new Parameter(info.Name, value));
            }
            return parameters;
        }

        // Все записи базы данных имеют колонку id;
        // Унаследованные от Record классы объявляют
        // колонки подобным образом
        [Field] virtual public int id { get; set; }
    }
}
