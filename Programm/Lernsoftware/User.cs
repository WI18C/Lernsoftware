using MySql.Data.MySqlClient;
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
        private string username;
        private string password; 
        private List<CardBox> cardBoxList;
        static MySQLDao connection = new MySQLDao();

        public User(int userID, string username)
        {
            UserId = userID;
            Username = username;
        }

        public User(string username)
        {
            Username = username;
        }

        public User()
        {
        }

        public int UserId
        {
            get => userId;
            set => userId = value;
        }
        public string Username
        {
            get => username;
            set => username = value;
        }
        public string Password
        {
            get => password;
            set => password = value;
        }
        internal List<CardBox> CardBoxList
        {
            get => cardBoxList;
            set => cardBoxList = value;
        }
        
        //Ändert Cardbox-Namen
        public Boolean changeCardBox (User user, string alt, string neu)
        {
            List<CardBox> cardBoxes = connection.loadCardBoxesInUserFromDB(user.UserId);
            CardBox cardbox = (from c in cardBoxes
                               where c.CardBoxName == alt
                               select c).FirstOrDefault(); 
            if (cardbox == null)
            {
                return false; 
            }
            else
            {
                connection.updateCardboxInDB(cardbox, neu);
                return true; 
            }
           

        }
        public void changePassword (User user, string neu)
        {
            connection.updateUser(user, false, neu);
        }
        public void changeUsername (User user, string neu)
        {   
            //Prüfung ob Username bereits vorhanden ist
            connection.updateUser(user, true, neu); 
        }
        public void createNewCardBox(int UserId, string name)
        {
            connection.saveCardboxInDB(UserId, name);
        }
        public Boolean deleteCardBox(string name)
        {
            //Datenbank
            return true; 
        }
        public CardBox getCardboxById(int cardboxId,int userId)
        {
            List<CardBox> cardBoxes = connection.loadCardBoxesInUserFromDB(userId);
            CardBox cardbox = (from c in cardBoxes
                               where c.CardBoxId == cardboxId
                               select c).FirstOrDefault(); 
            return cardbox; 
        }
        public Boolean deleteUser(string name)
        {
            //Datenbank
            return true; 
        }
        public User loginUser(string name, string pwd)
        {
            User user = connection.userLogIn(name, pwd);
            
            try
            {
                user.CardBoxList = connection.loadCardBoxesInUserFromDB(user.UserId);
                return user;
            }

            catch (Exception ex)
            {
                return null; 
            }
        }
        public User newUser(string name, string pwd)
        {
            User user = connection.CreateNewUser(name, pwd);
            user.CardBoxList = connection.loadCardBoxesInUserFromDB(user.UserId);
            return user; 
            //if schon vorhanden? 
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            User user = (User)obj;
            if (user.UserId == this.UserId
                && user.Username == this.Username)
            {
                return true;
            }
            else
                return false;
        }



    }
}
