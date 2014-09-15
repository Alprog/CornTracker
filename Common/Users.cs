using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CornTracker
{
    class Users
    {
        public static Dictionary<int, User> dictionary;

        public static void UpdateInformation()
        {
            dictionary = new Dictionary<int, User>();
            List<User> userList = DataProvider.GetAllRecords<User>();
            foreach (User user in userList)
                dictionary[user.id] = user;
        }

        public static string GetName(int id)
        {
            if (id == 0)
                return "";

            if (dictionary.ContainsKey(id))
                return dictionary[id].name;
            else
                return "Новый пользователь";
        }
    }
}
