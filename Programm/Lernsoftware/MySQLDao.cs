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

        //===============================================Verbindungsaufbau==================================================

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

        //=================================================FileCards==================================================
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
        public void updateFileCardInDB(FileCard OriginalfileCard, bool isQuestion, string changedText)
        {

            MySqlConnection connection = getConnection("root", "");
            //Klonen der OriginalFileCard
            FileCard clone = new FileCard(OriginalfileCard.FileCardId, OriginalfileCard.Question, OriginalfileCard.Answer);
            string commandstring = "";

            if(isQuestion)
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

        //==================================================Register==================================================
        public List<Register> loadRegistersInCardboxFromDB(int cardboxID)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "SELECT register_ID, register_Name, register_counter, register_rightcounter " +
                                   "FROM `register` WHERE cardbox_ID = " + cardboxID + ";";

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

        public void saveRegisterInDB(int cardboxID, string registerName)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "INSERT INTO `register` (`register_ID`, `cardbox_ID`, `register_Name`, `register_counter`, `register_rightcounter`) " +
                                   "VALUES(NULL, '" + cardboxID + "', '" + registerName + "', '0', '0');";

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

        public void updateRegister(Register register, string registerName)
        {
            MySqlConnection connection = getConnection("root", "");
            //Erstellen eines Registers mit veränderten Werten, aber gleicher ID
            Register clone = new Register(register.RegisterId, registerName, register.RegisterTryCounter, register.RegisterRightCounter);
            string commandstring = "UPDATE `register` SET `register_Name` = '" + clone.RegisterName + "' " +
                                   "WHERE `register`.`register_ID` = " + register.RegisterId +";";
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

        //=================================================Cardboxes==================================================
        public List<CardBox> loadCardBoxesInUserFromDB(int userID)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "SELECT cardbox_ID, cardbox_name " +
                                   "FROM `cardbox` " +
                                   "WHERE user_ID = " + userID + ";";

            if(connection.State.ToString() == "Open")
            {
                MySqlCommand command = new MySqlCommand(commandstring, connection);
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();


                    if(reader.HasRows)
                    {
                        List<CardBox> cardBoxes = new List<CardBox>();
                        while(reader.Read())
                        {
                            CardBox cardBox = new CardBox(reader.GetInt32(0), reader.GetString(1));
                            cardBoxes.Add(cardBox);
                        }

                        connection.Close();
                        return cardBoxes;
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

        public void saveCardboxInDB(int userID, string cardBoxName)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "INSERT INTO `cardbox` (`cardbox_ID`, `cardbox_name`, `user_ID`) " +
                                   "VALUES (NULL, '" + cardBoxName + "', '" + userID + "');";

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
        
        public void updateCardboxInDB(CardBox cardBox, string cardBoxName)
        {
            MySqlConnection connection = getConnection("root", "");
            //Erstellen einer CardBox mit veränderten Werten, aber gleicher ID
            CardBox clone = new CardBox(cardBox.CardBoxId, cardBoxName);
            string commandstring = "UPDATE `cardbox` SET `cardbox_name` = '" + clone.CardBoxName + "' " +
                                   "WHERE `cardbox`.`cardbox_ID` = "+ cardBox.CardBoxId + ";";

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

        //===================================================Users==================================================

        public User userLogIn(string userName, string password)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "SELECT user_ID, user_name, user_password " +
                                   "FROM `user` " +
                                   "WHERE user_name = '" + userName + "';";

            if(connection.State.ToString() == "Open")
            {
                MySqlCommand command = new MySqlCommand(commandstring, connection);
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        User user = null;
                        while(reader.Read())
                        {
                            if(reader.GetString(2) == password)
                            {
                                user = new User(reader.GetInt32(0), reader.GetString(1));
                            }                            
                        }
                        connection.Close();
                        return user;
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

        public User CreateNewUser(string username, string password)
        {
            User user = new User(username);
            MySqlConnection connection = getConnection("root", "");
            string commandstring = "INSERT INTO `user` (`user_ID`, `user_name`, `user_password`) " +
                                   "VALUES (NULL, '" + username + "', '" + password + "');";

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

            user = userLogIn(username, password);

            return user;
        }

        public void updateUser(User originalUser, bool isChangedValueTheUsername, string changedText)
        {
            MySqlConnection connection = getConnection("root", "");
            string commandstring = "";
            if(isChangedValueTheUsername)
            {
                User clone = new User(originalUser.UserId, changedText);
                commandstring = "UPDATE `user` " +
                                   "SET `user_name` = '" + clone.Username + "' " +
                                   "WHERE `user`.`user_ID` = " + clone.UserId + ";";
            }

            else
            {
                commandstring = "UPDATE `user` " +
                                   "SET `user_password` = '" + changedText + "' " +
                                   "WHERE `user`.`user_ID` = " + originalUser.UserId + ";";
            }

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


        //==============================================Learning Unit========================================================
        public void saveLearningUnitInDB(LearningUnit learningUnit, int userId)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "INSERT INTO `statistics` (`stat_ID`, `user_ID`, `stat_right`, `stat_wrong`, `stat_time`, `stat_round`) " +
                                   "VALUES(NULL, '" + userId + "', '" + learningUnit.AverageSuccessCB + "', '0', '" + learningUnit.Time + "', '0');";

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

        /*public List<LearningUnit> loadLearningUnitsFromDB(int userId)
        {
            MySqlConnection connection = getConnection("root", "");

            string commandstring = "SELECT stat_ID, user_ID, stat_right, stat_wrong, stat_rime, stat_round " +
                                   "FROM `statistics` WHERE user_ID = " + userId + ";";

            if(connection.State.ToString() == "Open")
            {
                MySqlCommand command = new MySqlCommand(commandstring, connection);
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();


                    if(reader.HasRows)
                    {
                        List<LearningUnit> learnings = new List<LearningUnit>();
                        while(reader.Read())
                        {
                            LearningUnit learning = new LearningUnit(reader.GetInt32(0),reader.GetInt32(1),reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4),reader.GetInt32(5));
                            learnings.Add(learning);
                        }

                        connection.Close();
                        return learnings;
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
        }*/



    }
}
