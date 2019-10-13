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

        public void saveSingleFileCardinDB(FileCard fileCard, int registerID)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "INSERT INTO `filecard` (`fc_ID`, `register_ID`, `fc_question`, `fc_answer`) " +
                                   "VALUES(NULL, " + registerID + ", '" + fileCard.Question + "', '" + fileCard.Answer + "');";

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
            connection.Close();
        }
        public void saveListOfFileCards(List<FileCard> fileCards, int registerID)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "INSERT INTO `filecard` (`fc_ID`, `register_ID`, `fc_question`, `fc_answer`) ";

            int counter = 0;
            foreach(var card in fileCards)
            {
                if(counter != fileCards.Count - 1)
                {
                    commandstring += "(NULL, " + registerID + ", '" + card.Question + "', '" + card.Answer + "'), ";
                }
                else
                    commandstring += "(NULL, " + registerID + ", '" + card.Question + "', '" + card.Answer + "');";
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

            connection.Close();

        }
        public List<FileCard> loadFilecardsInResgisterFromDB(int registerID)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "SELECT * FROM `filecard` WHERE filecard.register_ID = " + registerID + ";";

            if(connection.State.ToString() == "Open")
            {
                MySqlCommand command = new MySqlCommand(commandstring, connection);
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        List<FileCard> fileCards = new List<FileCard>();
                        while(reader.Read())
                        {
                            FileCard fileCard = new FileCard(reader.GetInt16(0), reader.GetString(2), reader.GetString(3));
                            fileCards.Add(fileCard);
                        }

                        connection.Close();
                        return fileCards;
                    }

                    else
                        return null;
                }

                catch(Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        /**
          *Beispielcode:
          * 
          *  dao.updateFileCardInDB(register.FileCards[0], true, "Wie heißen die Konjunktionen? ODER und...?");
             dao.updateFileCardInDB(register.FileCards[0], false, "UND");
             dao.updateFileCardInDB(register.FileCards[0], "Wie ändert man Frage und Antwort gleichzeitig?", "Na so!");
          **/
        public void updateFileCardInDB(FileCard OriginalfileCard, bool changeQuestion, string changedText)
        {

            MySqlConnection connection = getConnection("root", "");
            //Klonen der OriginalFileCard
            FileCard clone = new FileCard(OriginalfileCard.FileCardId, OriginalfileCard.Question, OriginalfileCard.Answer);
            string commandstring = "";

            if(changeQuestion)
            {
                clone.Question = changedText;
            }

            else
            {
                clone.Answer = changedText;
            }

            commandstring = "UPDATE `filecard` SET `fc_question` = '" + clone.Question + "', `fc_answer` = '" + clone.Answer + "' WHERE `filecard`.`fc_ID` = " + clone.FileCardId + ";";
            MySqlCommand command = new MySqlCommand(commandstring, connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {

                throw;
            }
        }

        /**
         *Beispielcode:
         * 
         *  dao.updateFileCardInDB(register.FileCards[0], true, "Wie heißen die Konjunktionen? ODER und...?");
            dao.updateFileCardInDB(register.FileCards[0], false, "UND");
            dao.updateFileCardInDB(register.FileCards[0], "Wie ändert man Frage und Antwort gleichzeitig?", "Na so!");
         **/
        public void updateFileCardInDB(FileCard OriginalfileCard, string changeQuestion, string changedAnswer)
        {
            MySqlConnection connection = getConnection("root", "");            
            //Erstellen einer Karte mit veränderten Werten, aber gleicher ID
            FileCard clone = new FileCard(OriginalfileCard.FileCardId, changeQuestion, changedAnswer);
            string commandstring = "UPDATE `filecard` SET `fc_question` = '" + clone.Question + "', `fc_answer` = '" + clone.Answer + "' WHERE `filecard`.`fc_ID` = " + clone.FileCardId + ";";
            MySqlCommand command = new MySqlCommand(commandstring, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {

                throw;
            }
        }

        public List<Register> loadRegistersInCardboxFromDB(int cardboxID)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "SELECT register_ID, register_Name, register_counter, register_rightcounter FROM `register` WHERE cardbox_ID = " + cardboxID + ";";

            if(connection.State.ToString() == "Open")
            {
                MySqlCommand command = new MySqlCommand(commandstring, connection);
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();


                    if(reader.HasRows)
                    {
                        List<Register> registers = new List<Register>();
                        while(reader.Read())
                        {
                            Register register = new Register(reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2), reader.GetInt32(3));
                            registers.Add(register);
                        }

                        connection.Close();
                        return registers;
                    }

                    else
                        return null;
                }

                catch(Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }


    }
}
