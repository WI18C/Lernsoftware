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
        private List<Register> registers;
        private LearningUnit learningUnit;
        private CardBoxDesign cardBoxDesign;

        static MySQLDao connection = new MySQLDao();

        public CardBox(int cardBoxId, string cardboxName)
        {
            CardBoxId = cardBoxId;
            CardBoxName = cardboxName;
        }

        // Der Name einer Card Box wird geändert
        public void changeName(CardBox cardBox, string newName)
        {
            connection.updateCardboxInDB(cardBox, newName);
        }

        // Addiert die Erfolgszähler aller Register, um den Gesamterfolg zu ermitteln und gibt int-Wert zurück
        public int countRegistersSuccess(CardBox cardBox)
        {
            List<Register> registers = connection.loadRegistersInCardboxFromDB(cardBox.cardBoxId);

            foreach(var Register in registers)
            {
                cardBoxSuccessCounter = cardBoxSuccessCounter + (10 / 5);
            }
            cardBoxSuccessCounter = cardBoxSuccessCounter / registers.Count;
            return cardBoxSuccessCounter;
        }

        // Neues Register wird hinzugefügt (Soll es eine maximale Anzahl geben?)
        public void addRegister(CardBox cardBox, string name)
        {
            connection.saveRegisterInDB(cardBox.cardBoxId, name);
        }

        // Schiebt FileCard ein Register weiter
        
        public void moveFileCard(int oldRegisterId, int fileCardId)
        {
            registers = connection.loadRegistersInCardboxFromDB(this.cardBoxId);
            
            for (int i = 0; i < Registers.Count - 1; i++)
			{
                 if(registers[i].RegisterId == oldRegisterId && registers[i+1] != null)
                 {
                    int newRegisterId = registers[i+1].RegisterId;
                    connection.moveFileCardInRegister(newRegisterId, fileCardId);
                    break;
                 }
                else {}
			}
        }
        
        //Löscht FileCard aus dem Register
        /*public void deleteFileCard(int deletingFileCard)
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
        }*/
       
        // Neue FileCard erstellen
        public void createFileCard(string fquestion, string fanswer, int registerId)
        {
            FileCard neueFileCard = new FileCard(fquestion, fanswer);
            connection.saveSingleFileCardinDB(neueFileCard, registerId);
        }

        
        public Register getRegisterById(int registerId, int cardBoxId)
        {
            List<Register> registers = connection.loadRegistersInCardboxFromDB(cardBoxId);
            Register register = (from c in registers
                               where c.RegisterId == registerId
                               select c).FirstOrDefault(); 
            return register;
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
