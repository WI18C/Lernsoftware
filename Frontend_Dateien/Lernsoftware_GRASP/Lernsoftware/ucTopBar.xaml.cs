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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lernsoftware
{
    /// <summary>
    /// Interaction logic for ucTopBar.xaml
    /// </summary>
    public partial class ucTopBar : UserControl
    {
        public event EventHandler SignOut;
        public event EventHandler<ChangePageEvent> ChangePageTo;
        public ucTopBar()
        {
            InitializeComponent();
        }

        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Good job! See you again soon.");
            SignOut(this, null);
        }
        private void ChangePageTo_Click(object sender, RoutedEventArgs e)
        {
            TargetPages target = (TargetPages)Enum.Parse(typeof(TargetPages), ((Button)sender).Name.Replace("btn", "").ToString());
            ChangePageTo(this, new ChangePageEvent(target));
        }
    }
    public class ChangePageEvent : EventArgs
    {
        public TargetPages Target;

        public ChangePageEvent(TargetPages target)
        {
            Target = target;
        }
    }
    public enum TargetPages
    {
        Home,
        Training,
        Settings,
        NewProject
    }
}
