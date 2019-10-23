using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
    class Register
    {
#region parameter
        private int containingFileCards;
        private int counter;
        private int counterSuccess;
        private int registerId;
        private string registerName;
        private static int rIdCounter = 0;
        private int containingFileCards;
        private List<FileCard> fileCards = new List<FileCard>();
        private int registerTryCounter;
        private int registerRightCounter;
#endregion

#region constructor
        public Register(string rName)
        {
            registerId = RIdCounter;
            RIdCounter++;
            RegisterName = rName;
        }

//Konflikte bei Registererstellung noch nicht berücksichtigt (z.B. ID)
        public Register(int registerId, string registerName, int registerTryCounter, int registerRightCounter)
        {
            RegisterId = registerId;
            RegisterName = registerName;
            RegisterTryCounter = registerTryCounter;
            RegisterRightCounter = registerRightCounter;
        }
#endregion

#region get + set
        // Großbuchstabe: Public, kleinbuchstabe: private

        public int ContainingFileCards
        {
            get => containingFileCards;
            set => containingFileCards = value;
        }

        public int Counter
        {
            get => counter;
            set => counter = value;
        }

        public int CounterSuccess
        {
            get => counterSuccess;
            set => counterSuccess = value;
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

         public int RegisterTryCounter
        {
            get => registerTryCounter;
            set => registerTryCounter = value;
        }

        public int RegisterRightCounter
        {
            get => registerRightCounter;
            set => registerRightCounter = value;
        }
#endregion

#region functions
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

        public void changeName(string newName)
        {
            registerName = newName;
        }
        
        //Sortiert FileCards nach Zufallsprinzip neu in Liste ein
        public static void Shuffle<FileCard>(this List<FileCard> fileCards) {
        int n = fileCards.Count;
        Random rnd = new Random();
            while (n > 1) {
                int k = (rnd.Next(0, n) % n);
                n--;
                FileCard value = fileCards[k];
                fileCards[k] = fileCards[n];
                fileCards[n] = value;
            }
            return fileCards;
        }
        
        public int rightCounter()
        {
            return counter;
        }

        public int tryCounter()
        {
            return counter;
        }
    }
}
#endregion
