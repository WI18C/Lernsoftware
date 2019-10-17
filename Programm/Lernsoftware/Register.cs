using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
    class Register
    {
        private int registerId;
        private string registerName;
        private static int rIdCounter = 0;
        private int containingFileCards;
        private List<FileCard> fileCards = new List<FileCard>();

        public Register(string rName)
        {
            registerId = RIdCounter;
            RIdCounter++;
            RegisterName = rName;
        }

        public FileCard getFileCardById(int cardId)
        {
            foreach(var FileCard in fileCards)
            {
                if(FileCard.fileCardId == cardId)
                {
                    return FileCard;
                }
                else{}
            }
        }


        public int RegisterId
        {
            get => registerId;
            set => registerId = value;
        }

        public string RegisterName
        {
            get => registerName;
            set => registerName = value;
        }

        public int ContainingFileCards
        {
            get => containingFileCards;
            set => containingFileCards = value;
        }

        internal List<FileCard> FileCards
        {
            get => fileCards;
            set => fileCards = value;
        }
        public static int RIdCounter
        {
            get => rIdCounter;
            set => rIdCounter = value;
        }

        public void deleteFileCard(int fileCardId)
        {
            foreach(FileCard fileCard in fileCards)
            {
                if(fileCard.FileCardId == fileCardId)
                {
                    fileCards.Remove(fileCard);
                    break;
                }
            }
        }

        public void updateFileCard(int fileCardId, bool isQuestion, string questionOrAnswerText)
        {
            foreach(FileCard fileCard in fileCards)
            {
                if(isQuestion)
                {
                    if(fileCard.FileCardId == fileCardId)
                    {
                        fileCard.Question = questionOrAnswerText;
                    }
                }

                else
                {
                    if(fileCard.FileCardId == fileCardId)
                    {
                        fileCard.Answer = questionOrAnswerText;
                    }
                }
            }
        }

        //Setzt die static Variable "FileCard.idCounter" auf den höchsten ID Wert + 1, 
        //damit beim erstellen einer einzelnen Karte die korrekte ID verwendet wird 
        public void setIdCounter()
        {
            int highestId = 0;
            foreach(var fileCard in FileCards)
            {
                if(highestId <= fileCard.FileCardId)
                {
                    highestId = fileCard.FileCardId + 1;
                }
            }
            FileCard.IdCounter = highestId;
        }

        public void saveListOfCards(List<FileCard> fileCards)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\Users\AOT\source\repos\Lernsoftware\WI18C\Lernsoftware\Programm\Lernsoftware\" + this.RegisterName + ".txt");

            foreach(var fileCard in fileCards)
            {
                string text = fileCard.FileCardId.ToString() + ";" + fileCard.Question + ";" + fileCard.Answer;
                writer.WriteLine(text);
            }
            writer.Close();
        }

        public void loadCards()
        {
            //Erstellt einen Reader der eine Datei am angegebenen Pfad ausliest
            System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\Users\AOT\source\repos\Lernsoftware\WI18C\Lernsoftware\Programm\Lernsoftware\" + this.RegisterName + ".txt");
            string readLine;
            while((readLine = reader.ReadLine()) != null)
            {
                //Ein Array in dem die Strings gespeichert werden, die durch ";" getrennt wurden 
                string[] stringArr = readLine.Split(';');
                //Durch die Daten im Array, wird eine FileCard erzeugt
                FileCard card = new FileCard(Convert.ToInt32(stringArr[0]), stringArr[1], stringArr[2]);

                //Prüfung, ob die FileCard "card" schon existiert 
                bool isInList = false;
                foreach(var fileCard in FileCards)
                {
                    if(fileCard.Equals(card))
                    {
                        isInList = true;
                        break;
                    }
                }

                if(isInList == false)
                {
                    fileCards.Add(card);
                }      
            }
            reader.Close();           
            setIdCounter();
        }
    }
}
