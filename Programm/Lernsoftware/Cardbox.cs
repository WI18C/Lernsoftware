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
        private static int cardBoxSuccessCounter = 0;
        private static int cbIdCounter = 1;
        private string cardBoxName;
        private int containingRegisters;
        private int containingFileCards;
       // private int containingFileCards;
        private List<Register> registers;
        private LearningUnit learningUnit;
        private CardBoxDesign cardBoxDesign;

        public CardBox(string cardboxName)
        {
            CardBoxId = CbIdCounter;
            CbIdCounter++;
            CardBoxName = cardboxName;
        }

        // Der Name einer Card Box wird geändert
        public void changeName(string newName)
        {
            this.cardBoxName = newName;
        }

        // Addiert die Erfolgszähler aller Register, um den Gesamterfolg zu ermitteln und gibt int-Wert zurück
        public int countRegistersSuccess()
        {
            foreach(var Register in registers)
            {
                cardBoxSuccessCounter = cardBoxSuccessCounter + Register.counterSuccess;
            }
            return cardBoxSuccessCounter;
        }

        // Neues Register wird hinzugefügt (Soll es eine maximale Anzahl geben?)
        public Boolean addRegister()
        {
            registers.Add(new Register("h"));
            return false; 
        }

        // Schiebt FileCard ein Register weiter
        
        public void moveFileCard(int movingFileCardId)
        {
            foreach(var Register in registers)
            {
                foreach(var FileCard in fileCards)
                {
                    if(FileCard.fileCardId == movingFileCardId)
                    {
                        if(Register.RIdCounter > Register.RegisterId)
                            {
                                
                                getRegisterById(Register.RegisterId + 1).Add(getFileCardById(movingFileCardId));
                                Register.Remove(getFileCardById(movingFileCardId));
                                break;
                            }
                        else{}
                    }
                }
            }
        }
        
        //Löscht FileCard aus dem Register
        public void deleteFileCard(int deletingFileCard)
        {
            foreach(var Register in registers)
            {
                foreach(var FileCard in fileCards)
                {
                    if(FileCard.fileCardId == deletingFileCard)
                    {
                        FileCard.Remove();
                    }
                    else{}
                }
            }
        }
       
        // Neue FileCard erstellen
        public FileCard createFileCard(string fquestion, string fanswer)
        {
            FileCard neueFileCard = new FileCard(fquestion, fanswer);

            return neueFileCard;
        }
        
        public void addNewFileCardIntoRegister(int regId)
        {
            if(Register.registerId == regId)
            {
                Register.fileCards.Add(createFileCard());
            }
        }
        
        public Register getRegisterById(int regId)
        {
            foreach(var Register in registers)
            {
                if(Register.RegisterId == regId)
                {
                    return Register;
                }
                else{}
            }
        }
        
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
        public static int CbIdCounter
        {
            get => cbIdCounter;
            set => cbIdCounter = value;
        }
    }
}
