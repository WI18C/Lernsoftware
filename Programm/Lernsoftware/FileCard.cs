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
        static int idCounter = 0;
        private string question;
        private string answer;
        private int tryCounter = 0;
        private int wrongCounter = 0;
        private int rightCounter = 0;

        public int FileCardId
        {
            get => fileCardId;
            set => fileCardId = value;
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
        ///////////////////////////////////////////////////////

        public FileCard(string question, string answer)
        {
            fileCardId = idCounter;
            idCounter++;
            this.Question = question;
            this.Answer = answer;
        }


    }
}
