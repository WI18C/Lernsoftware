using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lernsoftware
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

        /*Testing CardBox Klasse

        // Test Methode changeName (CardBox):
        User user = new User();
        user = user.loginUser("Albert", "1234");
        user.createNewCardBox(user.UserId, "Schalke"); 
        CardBox tobias = user.getCardboxById(6, user.UserId);
        Console.WriteLine(tobias.CardBoxName);
        tobias.changeName(tobias, "Dönerteller");
        Console.WriteLine(tobias.CardBoxName);


            // Test Methode addRegister:
            User user = new User();
            user = user.loginUser("Albert", "1234");
            CardBox test = user.getCardboxById(6, user.UserId);
            test.addRegister(test, "Testregister");


            // Test Methode createFileCard:
            User user = new User();
            user = user.loginUser("Albert", "1234");
            CardBox test = user.getCardboxById(6, user.UserId);
            test.createFileCard("Veltins oder Teewors?", "Veltins", 10);
            
            */


        /* Testing Learningunit
          * 
        //Learningunit erstellen, save von Learning Unit mit überschreiben

        User user = new User();
        user = user.loginUser("Albert", "123");
        CardBox fabian = user.getCardboxById(6, user.UserId);
        LearningUnit learningUnit = new LearningUnit(fabian);
        learningUnit.save(learningUnit,1);

        */




        /* Testing User Klasse 

        //User erstellen
        User user = new User();
        user = user.newUser("Heinz", "1234")

        //Login User
        User user = new User();
        user = user.loginUser("Albert", "1234");

        //Login: User nicht vorhanden, wird ObjectDisposedException bei Null
        User user = new User();
        user = user.loginUser("jajaja", "4564646546546556");
        Console.WriteLine(user);


        //ChangeUsername
        User user = new User();
        user = user.loginUser("Albert", "1234");
        user.changeUsername(user, "Fabian"); 

        //ChangePWD
        User user = new User();
        user = user.loginUser("Albert", "1234");
        user.changePassword(user, "123");

        //Create Cardbox 
        User user = new User();
        user = user.loginUser("Albert", "1234");
        user.createNewCardBox(user.UserId, "Schalke"); 

        //Change Cardbox 
        User user = new User();
        user = user.loginUser("Albert", "1234");
        user.changeCardBox(user, "Schalke", "Fabianmieft"); */


        /*Testing Register Klasse

        //updateRegister (bringt erst was, wenn Weiterklicken möglich)
        User user = new User();
        user = user.loginUser("Albert", "1234");
        CardBox testCardBox = user.getCardboxById(1, user.UserId);
        testCardBox.addRegister( testCardBox, "Kadda was here");
        Register testRegister = testCardBox.getRegisterById(10, 1);
        testCardBox.createFileCard("Was ist das Linuxmaskottchen?", "Pinguin Tux", 10);
        testRegister.updateRegister(testRegister, "Kadda was here");
      
        //saveRegister
        User user = new User();
        user = user.loginUser("Albert", "1234");
        CardBox testCardBox = user.getCardboxById(1, user.UserId);
        testCardBox.addRegister(testCardBox, "asef");
        Register testRegister = new Register("neues Register");
        testRegister.saveRegister(1, "neues Register");

        //changeName
        User user = new User();
        user = user.loginUser("Albert", "1234");
        CardBox testCardBox = user.getCardboxById(1, user.UserId);
        testCardBox.addRegister(testCardBox, "Kadda was here");
        Register testRegister = testCardBox.getRegisterById(10, 1);
        testRegister.changeName("neuer Name");
      
        //shuffle (lässt sich erst testen, 
        User user = new User();
        user = user.loginUser("Albert", "1234");
        CardBox testCardBox = user.getCardboxById(1, user.UserId);
        testCardBox.addRegister(testCardBox, "Kadda was here");
        Register testRegister = testCardBox.getRegisterById(10, 1);
        testRegister.shuffle(fileCards:);
        */
    }
    }
}
