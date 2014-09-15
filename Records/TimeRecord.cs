using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace CornTracker
{
    
    // Абстрактный класс записей, имеющих поле время
    public abstract class TimeRecord : Record
    {
        protected TimeRecord() { }
        protected TimeRecord(NpgsqlDataReader reader) : base(reader) { }

        [Field] virtual public DateTime time { get; set; }

        private void SetCurrentTime(List<Parameter> parameters)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                if (parameters[i].Name == "time")
                {
                    parameters.RemoveAt(i);
                    break;
                }
            }
            parameters.Add(new Parameter("time", "NOW()"));
        }

        public int InsertWithCurrentTime()
        {
            var parameters = GetUniqueParameters();
            SetCurrentTime(parameters);
            return this.Insert(parameters);
        }

        public void UpdateWithCurrentTime(Record defaultRecord = null)
        {
            var parameters = GetUniqueParameters(defaultRecord);
            SetCurrentTime(parameters);
            this.Update(parameters);
        }

    }
}
