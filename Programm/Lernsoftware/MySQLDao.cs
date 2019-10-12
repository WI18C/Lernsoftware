using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lernsoftware
{
    class MySQLDao
    {
        static MySqlConnection connection = new MySqlConnection();

        public string connect(string user, string password)
        {
            connection.ConnectionString = "SERVER=localhost; DATABASE=lernsoftwaredb; UID=" + user + "; PASSWORD=" + password + ";";

            try
            {
                connection.Open();
                return "Verbindungsaufbau erfolgreich";
            }

            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public MySqlConnection getConnection(string user, string password)
        {
            connect(user, password);
            return connection;
        }
        public string closeConnection()
        {
            if(connection.State.ToString() != "Closed")
            {
                connection.Close();
                if(connection.State.ToString() == "Closed")
                {
                    return "DB-Verbindung erfolgreich geschlossen";
                }
                else
                    return "Fehler beim Abmelden der DB-Verbindung";
            }

            else
                return "Es bestand keine DB-Verbindung";
        }
        public void saveSingleFileCardinDB(FileCard fileCard)
        {
            string commandstring = "INSERT INTO `filecards` (`fileCardId`, `question`, `answer`) " +
                                   "VALUES(NULL, '" + fileCard.Question + "', '" + fileCard.Answer + "');";

            if(connection.State.ToString() == "Open")
            {
                MySqlCommand command = new MySqlCommand(commandstring, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void saveListOfFileCards(List<FileCard> fileCards)
        {
            string commandstring = "INSERT INTO `filecards` (`fileCardId`, `question`, `answer`) VALUES";

            int counter = 0;
            foreach(var card in fileCards)
            {
                if(counter != fileCards.Count-1)
                {
                    commandstring += "(NULL, '" + card.Question + "', '" + card.Answer + "'), ";
                }
                else
                    commandstring += "(NULL, '" + card.Question + "', '" + card.Answer + "');";
                counter++;
            }

            if(connection.State.ToString() == "Open")
            {
                MySqlCommand command = new MySqlCommand(commandstring, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }


        }
    }
}
