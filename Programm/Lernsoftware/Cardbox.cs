using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
    class CardBox
    {
        private int cardBoxId;
        private string cardBoxName;
        private int containingRegisters;
        private int containingFileCards;
        private List<Register> registers;
        private LearningUnit learningUnit;
        private CardBoxDesign cardBoxDesign;

        public int CardBoxId
        {
            get => cardBoxId;
            set => cardBoxId = value;
        }
        public string CardBoxName
        {
            get => cardBoxName;
            set => cardBoxName = value;
        }
        public int ContainingRegisters
        {
            get => containingRegisters;
            set => containingRegisters = value;
        }
        public int ContainingFileCards
        {
            get => containingFileCards;
            set => containingFileCards = value;
        }
        internal List<Register> Registers
        {
            get => registers;
            set => registers = value;
        }
        internal LearningUnit LearningUnit
        {
            get => learningUnit;
            set => learningUnit = value;
        }
        internal CardBoxDesign CardBoxDesign
        {
            get => cardBoxDesign;
            set => cardBoxDesign = value;
        }

    }
}
