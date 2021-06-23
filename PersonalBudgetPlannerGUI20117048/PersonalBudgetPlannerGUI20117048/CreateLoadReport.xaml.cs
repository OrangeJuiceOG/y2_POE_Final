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
using System.Diagnostics;
using System.IO;
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

namespace PersonalBudgetPlannerGUI20117048
{
    /// <summary>
    /// Interaction logic for CreateLoadReport.xaml
    /// </summary>
    public partial class CreateLoadReport : Window
    {
        // global declarations
        public static String reportToLoad = "";
        public static bool loadBool = false;
        public CreateLoadReport()
        {
            InitializeComponent();
            loadBool = false; // reset bool
            refresh(); // refresh load report comboBox
        }

        // Create new report button click
        private void createReportButton_Click(object sender, RoutedEventArgs e)
        {
            // display the new report page
            NewReport nr = new NewReport();
            nr.Show();
            this.Close(); // close this page
        }

        private void loadReportButton_Click_1(object sender, RoutedEventArgs e)
        {
            reportToLoad = loadCombobox.Text; // parse the report name to load
            // validate input is not empty
            if(reportToLoad != "")
            {
                // set load control bool true before loading next window
                loadBool = true;
                // display the new report page
                NewReport nr = new NewReport();
                nr.Show();
                this.Close(); // close this page
            }
            else
            {
                MessageBox.Show("No report selected", "Alert"); // prompt user of error
            }
            
        }

        // method to refresh the load report combo box
        private void refresh()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(@"C:\\Users\\" + Environment.UserName + "\\Documents\\20117048 - POE Final"); //Assuming Test is your Folder

                FileInfo[] Files = directory.GetFiles("*.txt"); //Get the text files
                string str = "";
                string substr = "";

                loadCombobox.Items.Clear(); // reset values to avoid duplicates

                foreach (FileInfo file in Files)
                {
                    str = file.Name; // parse the files names into a string
                    substr = str.Substring(0, str.IndexOf(" -")); // substring them only to show the report name initially saved
                    loadCombobox.Items.Add(substr); // add substring name to combobox
                }
            }
            catch (Exception loadError)
            {
                MessageBox.Show("No saved reports found", "Alert");
            }
        }

        // method to open the user manual in default web browser in a github repo
        private void openUMButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // open URL
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/OrangeJuiceOG/y2_POE_Final/blob/main/User%20Manual%20-%20Person%20Budget%20Planner.pdf",
                    UseShellExecute = true
                });
            }
            catch(Exception UMerror)
            {
                MessageBox.Show("Error launching browser", "Error"); // prompt user of error
            }
            
        }
    }
}
