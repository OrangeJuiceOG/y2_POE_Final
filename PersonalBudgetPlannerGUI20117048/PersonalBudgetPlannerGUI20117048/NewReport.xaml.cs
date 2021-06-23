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
    /// Interaction logic for NewReport.xaml
    /// </summary>
    public partial class NewReport : Window
    {
        // Global declarations
        public static Dictionary<string, double> monthlyExpenses = new Dictionary<string, double>();
        public static double monthlyGross = 0;
        private static double monthlyAvailableAmount = 0;
        public static double totalExpenseAmount = 0;
        public static bool loanApproval = false;
        public static bool expenseAlert = false;
        public static double rentalAmount = 0;
        public static double homePurchasePrice = 0;
        public static double homeTotalDeposit = 0;
        public static double homeIntRatePercentage = 0;
        public static double homeMonths = 0;
        public static double homeLoanRepaymentAmount = 0;
        public static String vehicleMake;
        public static String vehicleModel;
        public static double vehiclePurchasePrice = 0;
        public static double vehicleTotalDeposit = 0;
        public static double vehicleIntRatePercentage = 0;
        public static double vehicleEstInsurancePremium = 0;
        public static double vehicleLoanRepayment = 0;
        public static String saveUpReason;
        public static double saveUpAmount = 0;
        public static DateTime saveUpDate;
        public static double saveUpIntRatePercentage = 0;
        public static double saveUpMonthlyAmount = 0;
        public static double countMonthsRounded = 0;


        // validation bools
        private static bool grossIncBool = false;
        private static bool taxBool = false;
        private static bool groceriesBool = false;
        private static bool waterBool = false;
        private static bool travelBool = false;
        private static bool cellBool = false;
        private static bool otherExpensesBool = false;
        private static bool accomBool = false;
        private static bool rentAmountBool = false;
        private static bool buyingPPBool = false;
        private static bool buyingTDBool = false;
        private static bool buyingIntBool = false;
        private static bool buyingMonthsBool = false;
        private static bool vehMakeBool = false;
        private static bool vehModelBool = false;
        private static bool vehPPBool = false;
        private static bool vehTDBool = false;
        private static bool vehIntBool = false;
        private static bool vehInsuranceBool = false;
        private static bool saveReasonBool = false;
        private static bool saveAmountBool = false;
        private static bool saveDateBool = false;
        private static bool saveIntBool = false;
        public static bool accomSelection = false; //  false = renting / true =  buying
        public static bool vehicleSelection = false;
        public static bool saveSelection = false;
        private static bool control = false;


        public NewReport()
        {

            InitializeComponent();
            // reset all control bools
            controlReset();
            // clear expense dictionary (mainly for when creating multiple reports)
            monthlyExpenses.Clear();

            // hide grids
            rentalGrid1.Visibility = Visibility.Hidden;
            buyingGrid.Visibility = Visibility.Hidden;
            vehiclePurchaseGrid.Visibility = Visibility.Hidden;
            saveUpGrid.Visibility = Visibility.Hidden;

            // Create and add expenses to dictionary (initialize to 0)
            monthlyExpenses.Add("Tax deduction", 0);
            monthlyExpenses.Add("Groceries", 0);
            monthlyExpenses.Add("Water & lights", 0);
            monthlyExpenses.Add("Travel costs", 0);
            monthlyExpenses.Add("Telephone", 0);
            monthlyExpenses.Add("Other expenses", 0);

            // test if a report is being loaded, if so call load method
            if (CreateLoadReport.loadBool == true)
            {
                loadReport();
            }

        }
        // =========================================== Income \/
        private void grossIncomeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(grossIncomeText.Text, out monthlyGross);
            if (monthlyGross <= 0)
            {
                // display validation error controls
                grossMonthlyErrorLabel.Content = "invalid input";
                grossIncomeText.Foreground = Brushes.Red;
                grossIncomeText.Background = Brushes.Bisque;
                grossIncBool = false;
            }
            else
            {
                // reset controls
                grossMonthlyErrorLabel.Content = "";
                grossIncomeText.Foreground = Brushes.Black;
                grossIncomeText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                grossIncBool = true;
            }
        }
        // =========================================== Income /\

        // =========================================== Expenses \/
        private void taxDeductionText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(taxDeductionText.Text);

                // NOTE: I have given the ability to enter 0 as a person could earn less than minimum wage and not pay any tax
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    taxErrorLabel.Content = "**warning";
                    taxDeductionText.Foreground = Brushes.Black;
                    taxDeductionText.Background = Brushes.LightCyan;
                    monthlyExpenses["Tax deduction"] = userInputTemp;
                    taxBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    taxErrorLabel.Content = "invalid input";
                    taxDeductionText.Foreground = Brushes.Red;
                    taxDeductionText.Background = Brushes.Bisque;
                    taxBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    taxErrorLabel.Content = "";
                    taxDeductionText.Foreground = Brushes.Black;
                    taxDeductionText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    monthlyExpenses["Tax deduction"] = userInputTemp;
                    taxBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                taxErrorLabel.Content = "invalid input";
                taxDeductionText.Foreground = Brushes.Red;
                taxDeductionText.Background = Brushes.Bisque;
                taxBool = false;
            }
        }

        private void groceriesText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(groceriesText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    groceriesErrorLabel.Content = "**warning";
                    groceriesText.Foreground = Brushes.Black;
                    groceriesText.Background = Brushes.LightCyan;
                    monthlyExpenses["Groceries"] = userInputTemp;
                    groceriesBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    groceriesErrorLabel.Content = "invalid input";
                    groceriesText.Foreground = Brushes.Red;
                    groceriesText.Background = Brushes.Bisque;
                    groceriesBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    groceriesErrorLabel.Content = "";
                    groceriesText.Foreground = Brushes.Black;
                    groceriesText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    monthlyExpenses["Groceries"] = userInputTemp;
                    groceriesBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                groceriesErrorLabel.Content = "invalid input";
                groceriesText.Foreground = Brushes.Red;
                groceriesText.Background = Brushes.Bisque;
                groceriesBool = false;
            }
        }

        private void waterAndLightsText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(waterAndLightsText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    waterErrorLabel.Content = "**warning";
                    waterAndLightsText.Foreground = Brushes.Black;
                    waterAndLightsText.Background = Brushes.LightCyan;
                    monthlyExpenses["Water & lights"] = userInputTemp;
                    waterBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    waterErrorLabel.Content = "invalid input";
                    waterAndLightsText.Foreground = Brushes.Red;
                    waterAndLightsText.Background = Brushes.Bisque;
                    waterBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    waterErrorLabel.Content = "";
                    waterAndLightsText.Foreground = Brushes.Black;
                    waterAndLightsText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    monthlyExpenses["Water & lights"] = userInputTemp;
                    waterBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                waterErrorLabel.Content = "invalid input";
                waterAndLightsText.Foreground = Brushes.Red;
                waterAndLightsText.Background = Brushes.Bisque;
                waterBool = false;
            }
        }

        private void travelCostsText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(travelCostsText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    travelErrorLabel.Content = "**warning";
                    travelCostsText.Foreground = Brushes.Black;
                    travelCostsText.Background = Brushes.LightCyan;
                    monthlyExpenses["Travel costs"] = userInputTemp;
                    travelBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    travelErrorLabel.Content = "invalid input";
                    travelCostsText.Foreground = Brushes.Red;
                    travelCostsText.Background = Brushes.Bisque;
                    travelBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    travelErrorLabel.Content = "";
                    travelCostsText.Foreground = Brushes.Black;
                    travelCostsText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    monthlyExpenses["Travel costs"] = userInputTemp;
                    travelBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                travelErrorLabel.Content = "invalid input";
                travelCostsText.Foreground = Brushes.Red;
                travelCostsText.Background = Brushes.Bisque;
                travelBool = false;
            }
        }

        private void telephoneText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(telephoneText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    cellErrorLabel.Content = "**warning";
                    telephoneText.Foreground = Brushes.Black;
                    telephoneText.Background = Brushes.LightCyan;
                    monthlyExpenses["Telephone"] = userInputTemp;
                    cellBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    cellErrorLabel.Content = "invalid input";
                    telephoneText.Foreground = Brushes.Red;
                    telephoneText.Background = Brushes.Bisque;
                    cellBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    cellErrorLabel.Content = "";
                    telephoneText.Foreground = Brushes.Black;
                    telephoneText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    monthlyExpenses["Telephone"] = userInputTemp;
                    cellBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                cellErrorLabel.Content = "invalid input";
                telephoneText.Foreground = Brushes.Red;
                telephoneText.Background = Brushes.Bisque;
                cellBool = false;
            }
        }

        private void otherExpensesText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(otherExpensesText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    otherExpenseErrorLabel.Content = "**warning";
                    otherExpensesText.Foreground = Brushes.Black;
                    otherExpensesText.Background = Brushes.LightCyan;
                    monthlyExpenses["Other expenses"] = userInputTemp;
                    otherExpensesBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    otherExpenseErrorLabel.Content = "invalid input";
                    otherExpensesText.Foreground = Brushes.Red;
                    otherExpensesText.Background = Brushes.Bisque;
                    otherExpensesBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    otherExpenseErrorLabel.Content = "";
                    otherExpensesText.Foreground = Brushes.Black;
                    otherExpensesText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    monthlyExpenses["Other expenses"] = userInputTemp;
                    otherExpensesBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                otherExpenseErrorLabel.Content = "invalid input";
                otherExpensesText.Foreground = Brushes.Red;
                otherExpensesText.Background = Brushes.Bisque;
                otherExpensesBool = false;
            }
        }
        // =========================================== Expenses /\

        // =========================================== Rent Property \/
        private void rentingRadio_Checked(object sender, RoutedEventArgs e)
        {
            accomBool = true;
            rentalGrid1.Visibility = Visibility.Visible;
            buyingGrid.Visibility = Visibility.Hidden;
            try // try add key to dictionary if it doesnt exist yet
            {
                monthlyExpenses.Add("Rental fee", 0);
                accomSelection = false;
            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Rental fee key already exists");
            }
            // separated so they can run independently
            try // try remove other radio dictionary key if exists
            {
                monthlyExpenses.Remove("Home loan");

            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Home Loan key does not exist yet");
            }
            // reset other radio option's values
            buyingPPText.Text = "";
            buyingPPErrorLabel.Content = "-";
            buyingTDText.Text = "";
            buyingTDErrorLabel.Content = "-";
            buyingIntRateText.Text = "";
            buyingIntRateErrorLabel.Content = "-";
            month240Radio.IsChecked = false;
            month360Radio.IsChecked = false;
            buyingPPText.Foreground = Brushes.Black;
            buyingPPText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            buyingTDText.Foreground = Brushes.Black;
            buyingTDText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            buyingIntRateText.Foreground = Brushes.Black;
            buyingIntRateText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            buyingPPBool = false;
            buyingTDBool = false;
            buyingIntBool = false;
            buyingMonthsBool = false;

        }

        private void rentalAmountText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(rentalAmountText.Text, out rentalAmount);
            if (rentalAmount <= 0)
            {
                rentalErrorLabel.Content = "invalid input";
                rentalAmountText.Foreground = Brushes.Red;
                rentalAmountText.Background = Brushes.Bisque;
                rentAmountBool = false;
            }
            else
            {
                rentalErrorLabel.Content = "";
                rentalAmountText.Foreground = Brushes.Black;
                rentalAmountText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                rentAmountBool = true;
            }
        }
        // =========================================== Rent Property /\

        // =========================================== Buy Property \/
        private void buyingRadio_Checked(object sender, RoutedEventArgs e)
        {
            accomBool = true;
            buyingGrid.Visibility = Visibility.Visible;
            rentalGrid1.Visibility = Visibility.Hidden;

            try // try add key to dictionary if it doesnt exist yet
            {
                monthlyExpenses.Add("Home loan", 0);
                accomSelection = true;
            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Home loan key already exists");
            }
            // separated so they can run independently
            try // try remove other radio dictionary key if exists
            {
                monthlyExpenses.Remove("Rental fee");

            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Rental fee key does not exist yet");
            }
            // reset other radio option's values
            rentalAmountText.Text = "";
            rentalErrorLabel.Content = "-";
            rentalAmountText.Foreground = Brushes.Black;
            rentalAmountText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            rentAmountBool = false;
        }

        private void buyingPPText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(buyingPPText.Text, out homePurchasePrice);
            if (homePurchasePrice <= 0)
            {
                buyingPPErrorLabel.Content = "invalid input";
                buyingPPText.Foreground = Brushes.Red;
                buyingPPText.Background = Brushes.Bisque;
                buyingPPBool = false;
            }
            else
            {
                buyingPPErrorLabel.Content = "";
                buyingPPText.Foreground = Brushes.Black;
                buyingPPText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                buyingPPBool = true;
            }
        }

        private void buyingTDText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(buyingTDText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    buyingTDErrorLabel.Content = "**warning";
                    buyingTDText.Foreground = Brushes.Black;
                    buyingTDText.Background = Brushes.LightCyan;
                    homeTotalDeposit = userInputTemp;
                    buyingTDBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    buyingTDErrorLabel.Content = "invalid input";
                    buyingTDText.Foreground = Brushes.Red;
                    buyingTDText.Background = Brushes.Bisque;
                    buyingTDBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    buyingTDErrorLabel.Content = "";
                    buyingTDText.Foreground = Brushes.Black;
                    buyingTDText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    homeTotalDeposit = userInputTemp;
                    buyingTDBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                buyingTDErrorLabel.Content = "invalid input";
                buyingTDText.Foreground = Brushes.Red;
                buyingTDText.Background = Brushes.Bisque;
                buyingTDBool = false;
            }
        }

        private void buyingIntRateText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(buyingIntRateText.Text, out homeIntRatePercentage);
            if (homeIntRatePercentage <= 0)
            {
                buyingIntRateErrorLabel.Content = "invalid input";
                buyingIntRateText.Foreground = Brushes.Red;
                buyingIntRateText.Background = Brushes.Bisque;
                buyingIntBool = false;
            }
            else
            {
                buyingIntRateErrorLabel.Content = "";
                buyingIntRateText.Foreground = Brushes.Black;
                buyingIntRateText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                buyingIntBool = true;
            }
        }

        private void month240Radio_Checked(object sender, RoutedEventArgs e)
        {
            homeMonths = 240; // set months value based on user selection
            buyingMonthsBool = true;
        }

        private void month360Radio_Checked(object sender, RoutedEventArgs e)
        {
            homeMonths = 360; // set months value based on user selection
            buyingMonthsBool = true;
        }
        // =========================================== Buy Property /\

        // =========================================== Buy Vehicle \/
        private void buyVehicleCheckBox_Checked(object sender, RoutedEventArgs e)
        {

            vehiclePurchaseGrid.Visibility = Visibility.Visible;
            vehicleSelection = true;
            try // try add key to dictionary if it doesnt exist yet
            {
                monthlyExpenses.Add("Vehicle loan", 0);
            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Vehicle loan key already exists");
            }

        }

        private void buyVehicleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            vehiclePurchaseGrid.Visibility = Visibility.Hidden;
            vehicleSelection = false;

            try // try remove other radio dictionary key if exists
            {
                monthlyExpenses.Remove("Vehicle loan");

            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Vehicle loan key does not exist yet");
            }

            vehicleMakeText.Clear();
            vehicleModelText.Clear();
            vehiclePPText.Clear();
            vehicleTDText.Clear();
            vehicleIntRateText.Clear();
            vehicleEstInsuranceText.Clear();
            vehiclePPText.Foreground = Brushes.Black;
            vehiclePPText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            vehicleTDText.Foreground = Brushes.Black;
            vehicleTDText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            vehicleIntRateText.Foreground = Brushes.Black;
            vehicleIntRateText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            vehicleEstInsuranceText.Foreground = Brushes.Black;
            vehicleEstInsuranceText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            vehiclePPErrorLabel.Content = "-";
            vehicleTDErrorLabel.Content = "-";
            vehicleIntRateErrorLabel.Content = "-";
            vehicleInsuranceErrorLabel.Content = "-";
            vehPPBool = false;
            vehTDBool = false;
            vehIntBool = false;
            vehInsuranceBool = false;
        }

        private void vehicleMakeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            vehicleMake = vehicleMakeText.Text;
            if(vehicleMake != "")
            {
                vehMakeBool = true;
            }
            else
            {
                vehMakeBool = false;
            }
        }

        private void vehicleModelText_TextChanged(object sender, TextChangedEventArgs e)
        {
            vehicleModel = vehicleModelText.Text;
            if (vehicleModel != "")
            {
                vehModelBool = true;
            }
            else
            {
                vehModelBool = false;
            }
        }

        private void vehiclePPText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(vehiclePPText.Text, out vehiclePurchasePrice);
            if (vehiclePurchasePrice <= 0)
            {
                vehiclePPErrorLabel.Content = "invalid input";
                vehiclePPText.Foreground = Brushes.Red;
                vehiclePPText.Background = Brushes.Bisque;
                vehPPBool = false;
            }
            else
            {
                vehiclePPErrorLabel.Content = "";
                vehiclePPText.Foreground = Brushes.Black;
                vehiclePPText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                vehPPBool = true;
            }
        }

        private void vehicleTDText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(vehicleTDText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    vehicleTDErrorLabel.Content = "**warning";
                    vehicleTDText.Foreground = Brushes.Black;
                    vehicleTDText.Background = Brushes.LightCyan;
                    vehicleTotalDeposit = userInputTemp;
                    vehTDBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    vehicleTDErrorLabel.Content = "invalid input";
                    vehicleTDText.Foreground = Brushes.Red;
                    vehicleTDText.Background = Brushes.Bisque;
                    vehTDBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    vehicleTDErrorLabel.Content = "";
                    vehicleTDText.Foreground = Brushes.Black;
                    vehicleTDText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    vehicleTotalDeposit = userInputTemp;
                    vehTDBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                vehicleTDErrorLabel.Content = "invalid input";
                vehicleTDText.Foreground = Brushes.Red;
                vehicleTDText.Background = Brushes.Bisque;
                vehTDBool = false;
            }
        }

        private void vehicleIntRateText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(vehicleIntRateText.Text, out vehicleIntRatePercentage);
            if (vehicleIntRatePercentage <= 0)
            {
                vehicleIntRateErrorLabel.Content = "invalid input";
                vehicleIntRateText.Foreground = Brushes.Red;
                vehicleIntRateText.Background = Brushes.Bisque;
                vehIntBool = false;
            }
            else
            {
                vehicleIntRateErrorLabel.Content = "";
                vehicleIntRateText.Foreground = Brushes.Black;
                vehicleIntRateText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                vehIntBool = true;
            }
        }

        private void vehicleEstInsuranceText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // initialize temp var to test user input before assigning to dictionary
                double userInputTemp = Convert.ToDouble(vehicleEstInsuranceText.Text);

                // NOTE: I have given the ability to enter 0
                // evaluate input
                if (userInputTemp == 0) // WARN USER IF VALUE IS 0
                {
                    vehicleInsuranceErrorLabel.Content = "**warning";
                    vehicleEstInsuranceText.Foreground = Brushes.Black;
                    vehicleEstInsuranceText.Background = Brushes.LightCyan;
                    vehicleEstInsurancePremium = userInputTemp;
                    vehInsuranceBool = true;
                }
                else if (userInputTemp < 0) // inform user of input error
                {
                    vehicleInsuranceErrorLabel.Content = "invalid input";
                    vehicleEstInsuranceText.Foreground = Brushes.Red;
                    vehicleEstInsuranceText.Background = Brushes.Bisque;
                    vehInsuranceBool = false;
                }
                else // assign acceptable value & reset textbox and error message
                {
                    vehicleInsuranceErrorLabel.Content = "";
                    vehicleEstInsuranceText.Foreground = Brushes.Black;
                    vehicleEstInsuranceText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                    vehicleEstInsurancePremium = userInputTemp;
                    vehInsuranceBool = true;
                }
            }
            catch (Exception InputException) // inform user of input error
            {
                vehicleInsuranceErrorLabel.Content = "invalid input";
                vehicleEstInsuranceText.Foreground = Brushes.Red;
                vehicleEstInsuranceText.Background = Brushes.Bisque;
                vehInsuranceBool = false;
            }
        }
        // =========================================== Buy Vehicle /\

        // =========================================== Save Up \/
        private void saveUpCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            saveUpGrid.Visibility = Visibility.Visible;
            saveSelection = true;

        }

        private void saveUpCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            saveUpGrid.Visibility = Visibility.Hidden;
            saveSelection = false;
            try // try remove other radio dictionary key if exists ** donno if this is needed **
            {
                monthlyExpenses.Remove(saveUpReason);

            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Save Up key does not exist yet");
            }

            saveReasonText.Clear();
            saveAmountText.Clear();
            saveDatePicker.SelectedDate = null;
            saveAmountText.Foreground = Brushes.Black;
            saveAmountText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            saveUpIntRateText.Foreground = Brushes.Black;
            saveUpIntRateText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            saveAmountBool = false;
            saveDateBool = false;
            saveIntBool = false;
            saveAmountErrorLabel.Content = "-";
            saveIntErrorLabel.Content = "-";
            dateThrough.Content = "-";


        }

        private void saveReasonText_TextChanged(object sender, TextChangedEventArgs e)
        {
            saveUpReason = saveReasonText.Text;
            if(saveUpReason != "")
            {
                saveReasonBool = true;
            }
            else
            {
                saveReasonBool = false;
            }
        }

        private void saveAmountText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(saveAmountText.Text, out saveUpAmount);
            if (saveUpAmount <= 0)
            {
                saveAmountErrorLabel.Content = "invalid input";
                saveAmountText.Foreground = Brushes.Red;
                saveAmountText.Background = Brushes.Bisque;
                saveAmountBool = false;
            }
            else
            {
                saveAmountErrorLabel.Content = "";
                saveAmountText.Foreground = Brushes.Black;
                saveAmountText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                saveAmountBool = true;
            }
        }

        private void saveDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                saveUpDate = saveDatePicker.SelectedDate.Value;
                DateTime currentDate = DateTime.Now;
                //TimeSpan countMonths = ;
                var countMonths = saveUpDate.Subtract(currentDate).Days / (360.25 / 12);
                countMonthsRounded = Math.Round(countMonths);
                dateThrough.Content = countMonthsRounded;
                saveDateBool = true;
            }
            catch (Exception DateError)
            {
                Console.WriteLine("Date value is back to null");
                saveDateBool = false;
            }

        }
        private void saveUpIntRateText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(saveUpIntRateText.Text, out saveUpIntRatePercentage);
            if (saveUpIntRatePercentage <= 0)
            {
                saveIntErrorLabel.Content = "invalid input";
                saveUpIntRateText.Foreground = Brushes.Red;
                saveUpIntRateText.Background = Brushes.Bisque;
                saveIntBool = false;
            }
            else
            {
                saveIntErrorLabel.Content = "";
                saveUpIntRateText.Foreground = Brushes.Black;
                saveUpIntRateText.Background = new SolidColorBrush(Color.FromRgb(238, 238, 238));
                saveIntBool = true;
            }
        }
        // =========================================== Save Up /\

        // Method to get total monthly expenses amount
        public static double calcMonthlyExpenseTotal()
        {
            totalExpenseAmount = 0; // reset var value (more so for when another budget is created)
            foreach (KeyValuePair<string, double> monthlyExpensesKVP in monthlyExpenses) totalExpenseAmount += monthlyExpensesKVP.Value; // calculate the total expense amount
            return totalExpenseAmount;
        }

        // Calculate monthly home loan repayment
        public double calcHomeLoanRepayment()
        {
            // Declarations
            double principalLoanAmount;
            double accumulatedLoanAmount;
            double interestRateConvert = homeIntRatePercentage / 100; //convert interest rate from percentage

            // Calculate principal loan amount ( P = purchase price - deposit )
            principalLoanAmount = homePurchasePrice - homeTotalDeposit;

            // Calculate accumulated loan amount ( A = P(1+in) ) - n is years (months divided by 12)
            accumulatedLoanAmount = principalLoanAmount * (1 + (interestRateConvert * (homeMonths / 12)));

            // Calculate monthly home loan repayment amount
            homeLoanRepaymentAmount = accumulatedLoanAmount / homeMonths;

            try
            {
                monthlyExpenses["Home loan"] = homeLoanRepaymentAmount;
            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Error with home loan calculation dictionary assignment");
            }

            if (homeLoanRepaymentAmount > (monthlyGross / 3))
            {
                MessageBox.Show("ALERT : Home loan approval is unlikely! Gross income too low!", "Alert");
                loanApproval = false; //update boolean (for text file use)

            }
            else
            {
                loanApproval = true; //update boolean (for text file use)
            }
            
            // return the value when called
            return homeLoanRepaymentAmount;
        }

        // method to calculate vehicle loan repayment - inherits the abstract Expense class as required
        public double calcVehicleLoanRepayment()
        {
            // Declarations
            double priceAfterDeposit;
            double accumulatedLoanAmount;
            double interestRateConvert = vehicleIntRatePercentage / 100; //convert interest rate from percentage
            double repaymentYears = 5; //fixed at 5 years

            // Calculate the price after deposit ( P = purchase price - deposit )
            priceAfterDeposit = vehiclePurchasePrice - vehicleTotalDeposit;

            // Calculate accumulated loan amount ( A = P(1+in) ) - n is years
            accumulatedLoanAmount = priceAfterDeposit * (1 + (interestRateConvert * (repaymentYears)));

            // Calculate monthly vehicle loan repayment amount including the estimated insurance premium
            vehicleLoanRepayment = accumulatedLoanAmount / (repaymentYears * 12) + vehicleEstInsurancePremium;

            try
            {
                monthlyExpenses["Vehicle loan"] = vehicleLoanRepayment;
            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Error with vehicle loan calculation dictionary assignment");
            }

            // return the value when called
            return vehicleLoanRepayment;
        }

        private void calcSavingsRepayment()
        {
            // calculate monthly saving amount using compound interest
            saveUpMonthlyAmount = saveUpAmount / ((Math.Pow((1 + ((saveUpIntRatePercentage / 100)) / countMonthsRounded), countMonthsRounded) - 1) / ((saveUpIntRatePercentage / 100) / countMonthsRounded));

            try
            {
                monthlyExpenses.Add(saveUpReason, saveUpMonthlyAmount); // add to dictionary
            }
            catch (Exception dictionaryError)
            {
                Console.WriteLine("Error with save up calculation dictionary assignment");
            }
        }

        private void createBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            // validate all user inputs
            validate();

            // if validation control is succesful
            if (control == true)
            {
                // test user inputs 
                if (buyingRadio.IsChecked == true)
                {
                    calcHomeLoanRepayment(); // call method
                }
                else
                {
                    monthlyExpenses["Rental fee"] = rentalAmount; // add to dictionary
                }

                if (buyVehicleCheckBox.IsChecked == true)
                {
                    calcVehicleLoanRepayment(); // call method
                }


                if (saveUpCheckBox.IsChecked == true)
                {
                    calcSavingsRepayment(); // call method
                }


                // open the show report window
                ShowReport sr = new ShowReport();
                sr.Show();
                this.Close(); // close this window
            }
            else
            {
                // display error message
                MessageBox.Show("Invalid inputs, please make sure all fields are filled in correctly and try again", "Error");
            }


        }

        public void validate()
        {
            control = true; // set as true initially - any issues will change it to false
            if (!grossIncBool || !taxBool || !groceriesBool || !waterBool || !travelBool || !cellBool || !otherExpensesBool)
            {
                control = false;
            }
            if (accomBool == true)
            {
                if (rentingRadio.IsChecked == true)
                {
                    if (!rentAmountBool)
                    {
                        control = false;
                    }
                }
                if (buyingRadio.IsChecked == true)
                {
                    if (!buyingPPBool || !buyingTDBool || !buyingIntBool || !buyingMonthsBool)
                    {
                        control = false;
                    }
                }
            }
            else
            {
                control = false;
            }
            if (buyVehicleCheckBox.IsChecked == true)
            {
                if (!vehMakeBool || !vehModelBool || !vehPPBool || !vehTDBool || !vehIntBool || !vehInsuranceBool)
                {
                    control = false;
                }
            }
            if (saveUpCheckBox.IsChecked == true)
            {
                if (!saveReasonBool || !saveAmountBool || !saveDateBool || !saveIntBool)
                {
                    control = false;
                }
            }
        }

        public void controlReset()
        {
            grossIncBool = false;
            taxBool = false;
            groceriesBool = false;
            waterBool = false;
            travelBool = false;
            cellBool = false;
            otherExpensesBool = false;
            accomBool = false;
            rentAmountBool = false;
            buyingPPBool = false;
            buyingTDBool = false;
            buyingIntBool = false;
            buyingMonthsBool = false;
            vehMakeBool = false;
            vehModelBool = false;
            vehPPBool = false;
            vehTDBool = false;
            vehIntBool = false;
            vehInsuranceBool = false;
            saveReasonBool = false;
            saveAmountBool = false;
            saveDateBool = false;

            monthlyGross = 0;
            monthlyAvailableAmount = 0;
            totalExpenseAmount = 0;
            loanApproval = false;
            expenseAlert = false;
            rentalAmount = 0;
            homePurchasePrice = 0;
            homeTotalDeposit = 0;
            homeIntRatePercentage = 0;
            homeMonths = 0;
            homeLoanRepaymentAmount = 0;
            vehicleMake = "";
            vehicleModel = "";
            vehiclePurchasePrice = 0;
            vehicleTotalDeposit = 0;
            vehicleIntRatePercentage = 0;
            vehicleEstInsurancePremium = 0;
            vehicleLoanRepayment = 0;
            saveUpReason = "";
            saveUpAmount = 0;
            saveDatePicker.SelectedDate = null;
            saveUpIntRatePercentage = 0;
            saveUpMonthlyAmount = 0;
            countMonthsRounded = 0;

            accomSelection = false; //  false = renting / true =  buying
            vehicleSelection = false;
            saveSelection = false;
            control = false;
        }

        public void loadReport()
        {

            String loadFilePath = @"C:\\Users\\" + Environment.UserName + "\\Documents\\20117048 - POE Final\\" + CreateLoadReport.reportToLoad + " - Budget Summary.txt";

            string loadMonthlyGross = File.ReadLines(loadFilePath).Skip(7).Take(1).First();
            grossIncomeText.Text = loadMonthlyGross.Substring(1);

            string loadTax = File.ReadLines(loadFilePath).Skip(10).Take(1).First();
            taxDeductionText.Text = loadTax.Substring(1);

            string loadGroceries = File.ReadLines(loadFilePath).Skip(12).Take(1).First();
            groceriesText.Text = loadGroceries.Substring(1);

            string loadWater = File.ReadLines(loadFilePath).Skip(14).Take(1).First();
            waterAndLightsText.Text = loadWater.Substring(1);

            string loadTravel = File.ReadLines(loadFilePath).Skip(16).Take(1).First();
            travelCostsText.Text = loadTravel.Substring(1);

            string loadCell = File.ReadLines(loadFilePath).Skip(18).Take(1).First();
            telephoneText.Text = loadCell.Substring(1);

            string loadOtherExpenses = File.ReadLines(loadFilePath).Skip(20).Take(1).First();
            otherExpensesText.Text = loadOtherExpenses.Substring(1);


            string loadAccom = File.ReadLines(loadFilePath).Skip(25).Take(1).First();
            if (loadAccom == "RENTING")
            {
                rentingRadio.IsChecked = true;
                string loadRentAmount = File.ReadLines(loadFilePath).Skip(28).Take(1).First();
                rentalAmountText.Text = loadRentAmount.Substring(1);
            }
            else if (loadAccom == "BUYING")
            {
                buyingRadio.IsChecked = true;
                string loadHomePP = File.ReadLines(loadFilePath).Skip(28).Take(1).First();
                buyingPPText.Text = loadHomePP.Substring(1);
                string loadHomeTD = File.ReadLines(loadFilePath).Skip(30).Take(1).First();
                buyingTDText.Text = loadHomeTD.Substring(1);
                string loadHomeInt = File.ReadLines(loadFilePath).Skip(32).Take(1).First();
                buyingIntRateText.Text = loadHomeInt;
                string loadHomeMonths = File.ReadLines(loadFilePath).Skip(34).Take(1).First();
                if (loadHomeMonths == "240")
                {
                    month240Radio.IsChecked = true;
                }
                else if (loadHomeMonths == "360")
                {
                    month360Radio.IsChecked = true;
                }
            }

            string loadVehicle = File.ReadLines(loadFilePath).Skip(45).Take(1).First();
            if (loadVehicle != "NO")
            {
                buyVehicleCheckBox.IsChecked = true;

                string loadVehMake = File.ReadLines(loadFilePath).Skip(48).Take(1).First();
                vehicleMakeText.Text = loadVehMake;
                string loadVehModel = File.ReadLines(loadFilePath).Skip(50).Take(1).First();
                vehicleModelText.Text = loadVehModel;
                string loadVehPP = File.ReadLines(loadFilePath).Skip(52).Take(1).First();
                vehiclePPText.Text = loadVehPP.Substring(1);
                string loadVehTD = File.ReadLines(loadFilePath).Skip(54).Take(1).First();
                vehicleTDText.Text = loadVehTD.Substring(1);
                string loadVehInt = File.ReadLines(loadFilePath).Skip(56).Take(1).First();
                vehicleIntRateText.Text = loadVehInt;
                string loadVehInsurance = File.ReadLines(loadFilePath).Skip(58).Take(1).First();
                vehicleEstInsuranceText.Text = loadVehInsurance.Substring(1);
            }

            string loadSave = File.ReadLines(loadFilePath).Skip(68).Take(1).First();
            if (loadSave != "NO")
            {
                saveUpCheckBox.IsChecked = true;

                string loadSaveReason = File.ReadLines(loadFilePath).Skip(71).Take(1).First();
                saveReasonText.Text = loadSaveReason;
                string loadSaveAmount = File.ReadLines(loadFilePath).Skip(73).Take(1).First();
                saveAmountText.Text = loadSaveAmount.Substring(1);
                string loadSaveDate = File.ReadLines(loadFilePath).Skip(75).Take(1).First();
                saveDatePicker.SelectedDate = DateTime.Parse(loadSaveDate);
                string loadSaveInt = File.ReadLines(loadFilePath).Skip(77).Take(1).First();
                saveUpIntRateText.Text = loadSaveInt;
                string loadSaveDatRounded = File.ReadLines(loadFilePath).Skip(79).Take(1).First();
                dateThrough.Content = loadSaveDatRounded;

            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            CreateLoadReport cr = new CreateLoadReport();
            cr.Show();
            this.Close();
        }
    }
}
