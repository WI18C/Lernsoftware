using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lernsoftware
{
    public partial class Form1 : Form
    {
        Register register = new Register("Testregister");
        MySQLDao dao = new MySQLDao();


        public Form1()
        {
            InitializeComponent();
            register.loadCards();
            try
            {
                MySQLDao dao = new MySQLDao();
                MySqlConnection c = dao.getConnection("root", "");

                if(c != null && c.State.ToString() == "Open")
                {
                    richTextBox1.Text = "Verbindung ist offen";
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSaveCard_Click(object sender, EventArgs e)
        {
            if(txtQuestion.Text != "" && txtAnswer.Text != "")
            {
                FileCard card = new FileCard(txtQuestion.Text, txtAnswer.Text);
                register.FileCards.Add(card);
                dao.saveSingleFileCardinDB(card);
            }           
        }

        //Testklasse, kann gelöscht werden
        void dummySaveListInDB()
        {
            List<FileCard> fileCards = new List<FileCard>();
            fileCards.Add(new FileCard("lalala", "blabla"));
            fileCards.Add(new FileCard("fjdkshs", "fjdghfkj"));
            dao.saveListOfFileCards(fileCards);
        }

        private void cmdReadFile_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            foreach(var fileCard in register.FileCards)
            {
                register.loadCards();
                string text;
                text = "ID = " + fileCard.FileCardId.ToString() + " | Frage = " + fileCard.Question + " | Antwort = " + fileCard.Answer + "\n";
                richTextBox1.AppendText(text);
            }
        }
    }
}
