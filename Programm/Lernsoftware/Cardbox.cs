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
        
        /*public void moveFileCard(CardBox cardBox, int registerId, int fileCardId)
        {
            List<Register> registers = connection.loadRegistersInCardboxFromDB(cardBox);

            foreach(var Register in registers)
            {
                List<FileCard> fileCards = connection.loadFilecardsInResgisterFromDB(registerId);

                foreach(var FileCard in fileCards)
                {
                    if(FileCard.fileCardId == fileCardId)
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
        }*/
        
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
        
        /*public void addNewFileCardIntoRegister(int regId)
        {
            if(Register.registerId == regId)
            {
                Register.fileCards.Add(createFileCard());
            }
        }*/
        
        /*public Register getRegisterById(int regId)
        {
            foreach(var Register in registers)
            {
                if(Register.RegisterId == regId)
                {
                    return Register;
                }
                else{}
            }
        }*/
        
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
