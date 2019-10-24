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
        private int userId; 
        CardBox cardBox;
        private String cardBoxName; 
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
        public int UserId
        {
            get => userId;
            set => userId = value; 
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
        public String CarddBoxName
        {
            get => cardBoxName;
            set => cardBoxName = value; 
        }
        //Konstruktor zum erstellen einer Learningunit zur Laufzeit 
        public LearningUnit(CardBox cb)
        {
            Time = getDate(); 
            CardBox = cb;
            CarddBoxName = CardBox.CardBoxName; 
            AverageSuccessCB = cardBox.countRegistersSuccess(cardBox);
        }
        //Konstruktor für ziehen der LearninngUnits aus der DB
        public LearningUnit(int stat_ID, int user_ID, int stat_average, String stat_time, String stat_cardboxname)
        {
            LearningUnitId = stat_ID; 
            UserId = user_ID; 
            AverageSuccessCB = stat_average; 
            Time = stat_time; 
            CarddBoxName = stat_cardboxname; 
        }
        
        //Speichert, falls zu Cardbox noch keine LU vorhanden neu, falls schon vorhanden wird LU überschrieben
        public void save(LearningUnit learningUnit, int userId)
        {
            List <LearningUnit> units = learningUnit.GetLearningUnits(userId);
            String cardboxname = learningUnit.CarddBoxName; 
            LearningUnit learning = (from c in units
                               where c.CarddBoxName == cardboxname
                               select c).FirstOrDefault();

            if(learning == null) {
                connection.saveLearningUnitInDB(learningUnit, userId);
            }
            
            else {
                connection.updateLearningUnit(learning, learningUnit.AverageSuccessCB, learningUnit.Time);
            }   
        }

        public String getDate ()
        {
             DateTime localDate = DateTime.Now;
             return  localDate.ToString(); 
        }
        
        public List<LearningUnit> GetLearningUnits (int userId)
        {
            return connection.loadLearningUnitsFromDB(userId);
        }

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
