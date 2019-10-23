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
        private static int idCounter = 0; //DB??
        private string username;
        private string password; 
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
        public User (string name, string pwd)
        {
            username = name;
            password = pwd;
            userId = idCounter;
            idCounter++; 
            cardBoxList = new List<CardBox>(); 
        }
        public void changeCardBox (string alt, string neu)
        {
            //Datenbank
        }
        public Boolean changePassword (string alt, string neu)
        {
            //Datenbank
            return true; 
        }
        public Boolean changeUsername (string alt, string neu)
        {
            //Datenbank
            return true; 
        }
        public void createNewCardBox(string name)
        {
            CardBox cardbox = new CardBox(name);
            if (cardBoxList.Contains(cardbox))
            { //FEhlermeldung breits vorhanden, erstezen?
                    
            }
            else
            {
                cardBoxList.Add(cardbox);
                //Erfolgsmeldung
            }
            //Datenbank
        }
        public void deleteCardBox(string name)
        {
            //Auswahl aus Liste oder wird Name eingegeben?
            CardBox cardbox = (from c in cardBoxList
                               where c.CardBoxName == name
                               select c).FirstOrDefault();
            
            if (cardbox == null)
            {
                //Fehlermeldung: nicht vorhanden
            }

            else
            {
                cardBoxList.Remove(cardbox);
                //Erfolgmeldung
            }
        }
        public Boolean deleteUser(string name)
        {
            //Datenbank
            return true; 
        }
        public Boolean loginUser(string name, string pwd)
        {
            // Datenbank
            return true; 
        }
        //public void newUser(string name, string pwd)
        //{
        //    User neu = new User(name, pwd);
        //    if //User wo vorhanden?
        //    { //FEhlermeldung breits vorhanden, erstezen?

        //    }
        //    else
        //    {
        //        //Erfolgsmeldung, Speichern?? 
        //    }
        //    //Datenbank
        //}
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
