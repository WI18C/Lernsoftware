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
        private int containingFileCards;
        private List<FileCard> fileCards = new List<FileCard>();

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

        public void deleteFileCard(int fileCardId)
        {
            foreach (FileCard fileCard in fileCards)
            {
                if (fileCard.FileCardId == fileCardId)
                {
                    fileCards.Remove(fileCard);
                    break;
                }
            }
        }

        public void updateFileCard(int fileCardId, bool isQuestion, string questionOrAnswerText)
        {
            foreach (FileCard fileCard in fileCards)
            {
                if (isQuestion)
                {
                    if (fileCard.FileCardId == fileCardId)
                    {
                        fileCard.Question = questionOrAnswerText;
                    }
                }

                else
                {
                    if (fileCard.FileCardId == fileCardId)
                    {
                        fileCard.Answer = questionOrAnswerText;
                    }
                }
            }
        }

        public void addToListOfFileCards(string question, string answer)
        {
            for (int i = 0; i < FileCards.Count - 1; i++)
            {
               
            }           
        }

        public void saveListOfCards(List<FileCard> fileCards)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\Users\Adrian\Source\Repos\WI18C\Lernsoftware\Programm\Lernsoftware\FileCards.txt");

            foreach (var fileCard in fileCards)
            {
                string text = fileCard.FileCardId.ToString() + ";" + fileCard.Question + ";" + fileCard.Answer;
                writer.WriteLine(text);
            }

            writer.Close();
        }

        public void saveSingleCard(FileCard fileCard)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\Users\Adrian\Source\Repos\WI18C\Lernsoftware\Programm\Lernsoftware\FileCards.txt");
            string text = fileCard.FileCardId.ToString() + ";" + fileCard.Question + ";" + fileCard.Answer;
            writer.WriteLine(text);
            writer.Close();
        }

        public void loadCards()
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\Users\Adrian\Source\Repos\WI18C\Lernsoftware\Programm\Lernsoftware\FileCards.txt");
            string readLine;
            while ((readLine = reader.ReadLine()) != null)
            {
                string[] stringArr = readLine.Split(';');
                FileCard card = new FileCard(Convert.ToInt32(stringArr[0]), stringArr[1], stringArr[2]);
                fileCards.Add(card);
            }

            reader.Close();
        }
    }
}
