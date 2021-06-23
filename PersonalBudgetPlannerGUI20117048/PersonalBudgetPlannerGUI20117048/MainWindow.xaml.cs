/* 
* 20117048 - Joshua Ochayon
* PROG6221 - POE Final (Task 3) (continuation of task 1 and 2) 
* VCSD2
* 
* Note: Both options (savings and graph) after obtaining permission.
* 
* Note: I have allowed the user to be able to input 0 for certain fields where it could be applicable such as tax (if someone earns less than min wage they will pay 0)
* 
* Assumptions: 
*  - estimated monthly tax deduction refers to a value amount not percentage
*  - total deposit refers to a value amount not percentage
*/


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

namespace PersonalBudgetPlannerGUI20117048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // check if log in details match defaults
            if (usernameText.Text.ToString() == "admin" && passwordBox.Password.ToString() == "admin")
            {
                // instantiate new object of next window and then show it
                CreateLoadReport clr = new CreateLoadReport();
                clr.Show();
                this.Close(); // close this window
            }
            else
            {
                // inform user of invalid input and reset input fields
                invalidCredLabel.Content = "Invalid credentials, please try again!";
                usernameText.Clear();
                passwordBox.Clear();
            }
        }
    }
}
