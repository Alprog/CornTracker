using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Npgsql;

namespace CornTracker
{
    public sealed class DataProvider
    {
        static NpgsqlConnection connection = null;

        public static DateTime lastUpdateTime;

        public static void TryConnect()
        {
            string connstring = String.Format(
                "Server={0};Port={1};User Id={2};Password={3};Database={4};",
                "server-linux", 5432, "postgres", "", "CornTrackerDB"
            );
            /*string connstring = String.Format(
                "Server={0};Port={1};User Id={2};Password={3};Database={4};",
                "localhost", 5432, "postgres", "123", "CornTrackerDB"
            );*/
            try
            {
                connection = new NpgsqlConnection(connstring);
                connection.Open();
                connection.Notification += new NotificationEventHandler(OnNotificate);
                NotificationCommand("listen", "update");
            }
            catch (Exception msg)
            {
                connection = null;
                Utils.ErrorMessage(msg.ToString());
            }
        }

        private static void OnNotificate(Object sender, NpgsqlNotificationEventArgs e)
        {
            Global.needUpdate = true;
        }

        private static void NotificationCommand(string command, string name)
        {
            string commandaString = String.Format("{0} {1};", command, name);
            new NpgsqlCommand(commandaString, connection).ExecuteNonQuery();
        }

        public static void Notify(string name)
        {
            NotificationCommand("notify", name);
        }

        public static DateTime GetTime()
        {
            var command = new NpgsqlCommand("SELECT NOW()", connection);
            return (DateTime)command.ExecuteScalar();
        }

        public static List<Node> GetUpdatedNodes()
        {
            string queryString = "SELECT * FROM nodes WHERE time > @time";
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter("time", lastUpdateTime));
            lastUpdateTime = GetTime();
            return GetRecordsFromQuery<Node>(queryString, parameters);
        }

        public static List<Node> GetAllActiveNodes()
        {
            string queryString = String.Format(@"
                WITH RECURSIVE subTree AS (
                    SELECT *
                    FROM nodes
                    WHERE id = 1
                UNION ALL
                    SELECT n.*
                    FROM nodes AS n, subTree AS st
                    WHERE n.parent = st.id
                    AND n.status <> {0}
                )
                SELECT * FROM subTree
            ", (int)ENodeStatus.CLOSED);
            lastUpdateTime = GetTime();
            return GetRecordsFromQuery<Node>(queryString);
        }

        public static NpgsqlCommand CreateCommand(string queryString, List<Parameter> parameters = null)
        {
            NpgsqlCommand command = new NpgsqlCommand(queryString, connection);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    if (!parameter.IsSQLString)
                        command.Parameters.Add(new NpgsqlParameter(parameter.Name, parameter.Value));
                }
            }
            return command;
        }

        public static List<T> GetAllRecords<T>() where T : Record
        {
            String tableName = typeof(T).Name.ToLower() + "s";
            String queryString = String.Format("SELECT * FROM {0}", tableName);
            return GetRecordsFromQuery<T>(queryString);
        }

        public static List<T> GetRecordsFromQuery<T>(String queryString, List<Parameter> parameters = null) where T : Record
        {
            NpgsqlDataReader reader = RunQuery(queryString, parameters);
            List<T> list = new List<T>();
            while (reader.Read())
                list.Add((T)System.Activator.CreateInstance(typeof(T), reader));
            return list;
        }

        public static NpgsqlDataReader RunQuery(string queryString, List<Parameter> parameters = null)
        {
            NpgsqlCommand command = CreateCommand(queryString, parameters);
            return command.ExecuteReader();
        }
    }
}

/*public static List<Node> LoadNodes()
{
    var dict = new Dictionary<int, Node>();

    // Интересующие нас таски в выбраном поддереве
    NpgsqlDataReader reader = RunQuery(@"
        CREATE TEMP TABLE needNodes AS (
                    
            WITH RECURSIVE subTree AS (
                SELECT * FROM nodes WHERE id = 1
            UNION
                SELECT n.*
                FROM nodes AS n, subTree AS st
                WHERE n.parent = st.id
            )
                    
            SELECT * FROM subTree WHERE type = 1
        );
        SELECT * FROM needNodes;
    ");

    while (reader.Read())
    {
        Node node = new Node(reader);
        node.SetInterest(true);
        dict.Add(node.id, node);
    }
    reader.Close();

    // Пути к интересующим нам таскам, их дети, папки
    reader = RunQuery(@"
        WITH RECURSIVE fullTable AS (
            SELECT * FROM needNodes
        UNION
            SELECT n.*
            FROM nodes AS n, fullTable AS ft
            WHERE ft.parent = n.id
        )

        SELECT * FROM fullTable
        UNION
        SELECT nodes.* FROM nodes, needNodes
        WHERE nodes.parent = needNodes.id
        EXCEPT
        SELECT * FROM needNodes
        UNION
        SELECT * FROM nodes WHERE type = 0;
                
        DROP TABLE needNodes;
    ");

    while (reader.Read())
    {
        Node node = new Node(reader);
        dict.Add(node.id, node);
    }
    reader.Close();

    lastUpdateTime = GetTime();

    var list = new List<Node>();
    foreach (Node node in dict.Values)
    {
        if (dict.ContainsKey(node.parent))
            dict[node.parent].AddNode(node);
        else
            list.Add(node);
    }
    return list;
}*/

/*NpgsqlDataReader reader = RunQuery(@"
    WITH RECURSIVE
                
    -- Интересующее нас поддерево
    subTree AS (
        SELECT *
        FROM nodes
        WHERE id = 1
    UNION ALL
        SELECT n.*
        FROM nodes AS n, subTree AS st
        WHERE n.parent = st.id
    ),

    -- Интересующие нас таски
    filterTable AS (
        SELECT *
        FROM subTree
        WHERE type = 1 OR id = 1
    ),

    -- Интересующие нас таски + путь к ним
    finalTable AS (
        SELECT * FROM filterTable
    UNION
        SELECT st.*
        FROM subTree AS st, finalTable AS ft
        WHERE ft.parent = st.id
    ),

    fTable AS (
        SELECT * FROM finalTable
        UNION
        SELECT * FROM nodes WHERE type = 0
    )
                
   SELECT * FROM finalTable
   UNION
   SELECT * FROM nodes WHERE type = 0;
");*/