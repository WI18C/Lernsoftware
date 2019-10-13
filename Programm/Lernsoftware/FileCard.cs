using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
    class FileCard
    {
        private int fileCardId;
        private static int idCounter = 1;
        private string question;
        private string answer;
        private int tryCounter = 0;
        private int wrongCounter = 0;
        private int rightCounter = 0;
        private MySQLDao mySQLDao = new MySQLDao();

        
        public FileCard(string question, string answer)
        {
            fileCardId = idCounter;
            idCounter++;
            Question = question;
            Answer = answer;
        }

        public FileCard(int fileCardId, string question, string answer)
        {
            FileCardId = fileCardId;
            Question = question;
            Answer = answer;
        }

        public int FileCardId
        {
            get => fileCardId;
            set => fileCardId = value;
        }
        public static int IdCounter
        {
            get => idCounter;
            set => idCounter = value;
        }
        public string Question
        {
            get => question;
            set => question = value;
        }
        public string Answer
        {
            get => answer;
            set => answer = value;
        }

        //////////////For later statistics////////////////////
        
        public int TryCounter
        {
            get => tryCounter;
            set => tryCounter = value;
        }
        public int WrongCounter
        {
            get => wrongCounter;
            set => wrongCounter = value;
        }
        public int RightCounter
        {
            get => rightCounter;
            set => rightCounter = value;
        }

        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FileCard card = (FileCard)obj;
            if(card.FileCardId == this.FileCardId
                && card.Question == this.Question
                && card.Answer == this.Answer)
            {
                return true;
            }
            else
                return false;
        }


    }
}
