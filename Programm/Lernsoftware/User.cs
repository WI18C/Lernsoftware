using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
    class User
    {
        private int userId;
        private string userName;
        private List<CardBox> cardBoxList;

        public User(int userID, string username)
        {
            UserId = userID;
            Username = username;
        }

        public User(string username)
        {
            Username = username;
        }

        public int UserId
        {
            get => userId;
            set => userId = value;
        }
        public string Username
        {
            get => userName;
            set => userName = value;
        }
        internal List<CardBox> CardBoxList
        {
            get => cardBoxList;
            set => cardBoxList = value;
        }

    }
}
