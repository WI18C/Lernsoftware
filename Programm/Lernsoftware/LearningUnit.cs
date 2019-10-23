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
        private String time;
        private int learningUnitId;
        CardBox cardBox;
        private int round; 
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

        public String Time
        {
            get => time;
            set => time = value; 
        }
        public CardBox CardBox
        {
            get => cardBox;
            set => cardBox = value; 
        }
        public LearningUnit(CardBox cb)
        {
            time = getDate(); 
            cardBox = cb;
            averageSuccessCB = cardBox.countRegistersSuccess(cardBox);
        }
        public void save(LearningUnit learningUnit, int userId)
        {
            connection.saveLearningUnitInDB(learningUnit, userId);
        }

        public String getDate ()
        {
            DateTime dt = new DateTime();
            return String.Format("{0:MM/dd/yyyy}",dt);
        }
        
        /*public List<LearningUnit> GetLearningUnits (int userId)
        {
            return connection.loadLearningUnitsFromDB(userId);
        }*/

        /*
        public List<String> getRegisterNames(CardBox cardBox)
        {
           List<Register> registers = cardBox.Registers; 
           List<string> names = new List<string>(); 
           foreach (Register register in registers)
            {
                names.Add(register.RegisterName);
            }
           return names; 
        }
        */
       
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
