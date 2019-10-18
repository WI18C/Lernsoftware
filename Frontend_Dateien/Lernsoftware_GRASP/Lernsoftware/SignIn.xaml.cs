using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lernsoftware
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public static bool UserIsLoggedIn = false;

        public SignIn()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Password;

            if (userName == "" && password == "")
            {
                UserIsLoggedIn = true;

                // Adds navigation into Topbar
                ucTopBar topBarComponent = new ucTopBar();
                topBarComponent.ChangePageTo += TopBarComponent_ChangePageTo;
                topBarComponent.SignOut += Topbar_SignOut;
                topBar.Children.Add(topBarComponent);

                // Jumps to Home screen (first page)
                ChangeMainContent(new ucHome());
            }
            else
            {
                MessageBox.Show("User Name or Password incorrect. Please try again.");
            }
        }
        
        // Changes foreground of the main area
        public void ChangeMainContent(UIElement uIElement) {
            content.Children.Clear();
            sideBarGrid.Children.Clear();
            content.ColumnDefinitions.Clear();
            content.Children.Add(uIElement);
        }

        // Changes foreground of the side area
        public void ChangeSideBar(UIElement uIElement)
        {
            sideBarGrid.Children.Clear();
            sideBarGrid.Children.Add(uIElement);
        }

        // Offers a choice of pages to show in the foreground
        private void TopBarComponent_ChangePageTo(object sender, ChangePageEvent e)
        {
            switch (e.Target)
            {
                case TargetPages.Home:
                    ChangeMainContent(new ucHome());
                    break;
                case TargetPages.Training:
                    ChangeMainContent(new ucFileCardQuestion());
                    ChangeSideBar(new ucSideBar());
                    break;
                case TargetPages.Settings:
                    ChangeMainContent(new ucSettings());
                    break;
                case TargetPages.NewProject:
                    ChangeMainContent(new ucNewProject());
                    break;
                default:
                    break;
            }
        }

        // Switches back to Sign In
        private void Topbar_SignOut(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            this.Close();
        }

        private void TxtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
