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
            /*
           Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); 
            */
            User user = new User(1,"Schalke");
            CardBox cardBox = new CardBox("Schalke");
            LearningUnit learningUnit = new LearningUnit(cardBox);
            learningUnit.save(learningUnit,1);

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

            



        }
    }
}
