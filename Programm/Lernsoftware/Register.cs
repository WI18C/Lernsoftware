using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
  class Register
  {
    #region parameter
    private int containingFileCards;
    private int counter;
    private int counterSuccess;
    private int registerId;
    private string registerName;
    private static int rIdCounter = 0;
    private List<FileCard> fileCards = new List<FileCard>();
    private int registerTryCounter;
    private int registerRightCounter;
    static MySQLDao connection = new MySQLDao();
    #endregion

    #region constructor
    public Register(string rName)
    {
      registerId = RIdCounter;
      RIdCounter++;
      RegisterName = rName;
    }

    //Konflikte bei Registererstellung noch nicht berücksichtigt (z.B. ID)
    public Register(int registerId, string registerName, int registerTryCounter, int registerRightCounter)
    {
      RegisterId = registerId;
      RegisterName = registerName;
      RegisterTryCounter = registerTryCounter;
      RegisterRightCounter = registerRightCounter;
    }
    #endregion

    #region get + set
    public int ContainingFileCards
    {
      get => containingFileCards;
      set => containingFileCards = value;
    }

    public int Counter
    {
      get => counter;
      set => counter = value;
    }

    public int CounterSuccess
    {
      get => counterSuccess;
      set => counterSuccess = value;
    }

    /*public FileCard getFileCardById(int cardId)
    {
        foreach(var FileCard in fileCards)
        {
            if(FileCard.FileCardId == cardId)
            {
                return FileCard;
            }
            else{}
        }
    }*/


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

    /*public int ContainingFileCards
    {
        get => containingFileCards;
        set => containingFileCards = value;
    }*/

    internal List<FileCard> FileCards
    {
      get => fileCards;
      set => fileCards = value;
    }
    public static int RIdCounter
    {
      get => rIdCounter;
      set => rIdCounter = value;
    }

    public int RegisterTryCounter
    {
      get => registerTryCounter;
      set => registerTryCounter = value;
    }

    public int RegisterRightCounter
    {
      get => registerRightCounter;
      set => registerRightCounter = value;
    }
    #endregion

    #region functions
    public void deleteFileCard(int fileCardId)
    {
      foreach (FileCard fileCard in fileCards)
      {
        if (fileCard.FileCardId == fileCardId)
        {
          fileCards.Remove(fileCard);
          break;
        }
      }
    }

    public void updateRegister(Register register, String registername)
    {
      connection.updateRegister(register, registerName);
    }

    //Setzt die static Variable "FileCard.idCounter" auf den höchsten ID Wert + 1, 
    //damit beim erstellen einer einzelnen Karte die korrekte ID verwendet wird 
    public void setIdCounter()
    {
      int highestId = 0;
      foreach (var fileCard in FileCards)
      {
        if (highestId <= fileCard.FileCardId)
        {
          highestId = fileCard.FileCardId + 1;
        }
      }
      FileCard.IdCounter = highestId;
    }

    public void saveRegister(int cardboxID, string registername)
    {
      connection.saveRegisterInDB(cardboxID, registername);
    }

    public void loadCardsInRegister(int registerID)
    {
      connection.loadFilecardsInResgisterFromDB(registerID);
    }

    public void changeName(string newName)
    {
      registerName = newName;
    }

    //Sortiert FileCards nach Zufallsprinzip neu in Liste ein
    public void shuffle(List<FileCard> fileCards)
    {
      int n = fileCards.Count;
      Random rnd = new Random();
      while (n > 1)
      {
        int k = (rnd.Next(0, n) % n);
        n--;
        FileCard value = fileCards[k];
        fileCards[k] = fileCards[n];
        fileCards[n] = value;
      }
    }

    public int rightCounter()
    {
      return counter;
    }

    public int tryCounter()
    {
      return counter;
    }
  }
}
#endregion
