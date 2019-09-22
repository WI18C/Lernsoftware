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
        private List<FileCard> fileCards;

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
            foreach(FileCard fileCard in fileCards)
            {
                if(fileCard.FileCardId == fileCardId)
                {
                    FileCards.Remove(fileCard);
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

        public void addToFileCards(string question, string answer)
        {
            this.fileCards.Add(new FileCard(question, answer));
        }
    }
}
