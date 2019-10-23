using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
    class LearningUnit
    {
        private int averageSuccessCB;
        private DateTime time;
        private int learningUnitId;
        CardBox cardBox;
        private List<Register> registerList;
        private int round; // Attribut muss in Register oder Cardbox
        static MySQLDao connection = new MySQLDao();
        public int AverageSuccessCB
        {
            get => averageSuccessCB;
            set => averageSuccessCB = value; 
        }
        public int LearningUnitId
        {
            get => learningUnitId;
            set => learningUnitId = value; 
        }
        public int Round
        {
            get => round;
            set => round = value; 
        }

        public DateTime Time
        {
            get => time;
            set => time = value; 
        }
        public LearningUnit(CardBox cb)
        {
            time = DateTime.Now;
            learningUnitId = idCounter;
            idCounter++;
            cardBox = cb;
            averageSuccessCB = cardBox.countRegistersSuccess(); //in CB ergänzen
            registerList = cardBox.Registers;
        }

        public void save(LearningUnit learningUnit, int userId)
        {
            connection.saveLearningUnitInDB(learningUnit, userId);
        }
        // Methode für den Aufruf der Register und einzelnen Averages
        public void showRegisters()
        {
            foreach (Register register in registerList)
            {
                Console.WriteLine(register.RegisterName + ": " +
                    (register.Counter/register.CounterSuccess)+"%");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            LearningUnit learningUnit = (LearningUnit)obj;
            if (learningUnit.LearningUnitId == this.LearningUnitId)
            {
                return true;
            }
            else
                return false;
        }

    }
    

}
