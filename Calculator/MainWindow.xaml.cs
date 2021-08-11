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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool add;
        bool subtract;
        bool multiply;
        bool divide;
        string value1;
        decimal dValue1;
        string value2;
        decimal dValue2;
        decimal dResult;
        string result;
        List<string> history = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (screen.Text.Length < 10)
            {
                screen.Text = screen.Text + b.Content;
            }
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            add = true;
            value1 = screen.Text;
            dValue1 = Convert.ToDecimal(value1);
            screen.Text = String.Empty;
            ButtonAdd.IsEnabled = false;
            NegativeDecimalReset();
            EnableNumbers();
            DisableOperators();
        }
        private void Button_Click_Subtract(object sender, RoutedEventArgs e)
        {
            subtract = true;
            value1 = screen.Text;
            dValue1 = Convert.ToDecimal(value1);
            screen.Text = String.Empty;
            ButtonSubtract.IsEnabled = false;
            NegativeDecimalReset();
            EnableNumbers();
            ButtonEquals.IsEnabled = true;
            DisableOperators();
        }
        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            multiply = true;
            value1 = screen.Text;
            dValue1 = Convert.ToDecimal(value1);
            screen.Text = String.Empty;
            ButtonMultiply.IsEnabled = false;
            NegativeDecimalReset();
            EnableNumbers();
            ButtonEquals.IsEnabled = true;
            DisableOperators();
        }
        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            divide = true;
            value1 = screen.Text;
            dValue1 = Convert.ToDecimal(value1);
            screen.Text = String.Empty;
            ButtonDivide.IsEnabled = false;
            NegativeDecimalReset();
            EnableNumbers();
            ButtonEquals.IsEnabled = true;
            DisableOperators();
        }
        private void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            value2 = screen.Text;
            dValue2 = Convert.ToDecimal(value2);

            if (add == true)
            {
                dResult = dValue1 + dValue2;
                history.Add($"{dValue1} + {dValue2} = {dResult}");
            }
            else if (subtract == true)
            {
                dResult = dValue1 - dValue2;
                history.Add($"{dValue1} - {dValue2} = {dResult}");
            }
            else if (multiply == true)
            {
                dResult = dValue1 * dValue2;
                history.Add($"{dValue1} x {dValue2} = {dResult}");
            }
            else if (divide == true)
            {
                dResult = dValue1 / dValue2;
                history.Add($"{dValue1} / {dValue2} = {dResult}");
            }

            result = Convert.ToString(dResult);
            screen.Text = result;
            dValue1 = dResult;
            ResetOperators();
            AddToHistory();
            ButtonNegative.IsEnabled = false;
            ButtonDecimal.IsEnabled = false;
            ButtonEquals.IsEnabled = false;
            DisableNumbers();
        }
        private void Button_Click_Negative(object sender, RoutedEventArgs e)
        {
            screen.Text = "-" + screen.Text;
            ButtonNegative.IsEnabled = false;
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            screen.Text = String.Empty;
            NegativeDecimalReset();
        }
        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Clear();
            EnableNumbers();
        }
        private void Button_Click_Square(object sender, RoutedEventArgs e)
        {
            value1 = screen.Text;
            dValue1 = Convert.ToDecimal(value1);
            dResult = dValue1 * dValue1;
            result = Convert.ToString(dResult);
            screen.Text = result;
            history.Add($"{dValue1} ^2 = {dResult}");
            ButtonNegative.IsEnabled = false;
            ButtonDecimal.IsEnabled = false;
            AddToHistory();
        }
        private void Button_Click_Sqrt(object sender, RoutedEventArgs e)
        {
            value1 = screen.Text;
            dValue1 = Convert.ToDecimal(value1);
            dResult = (decimal)Math.Sqrt((double)dValue1);
            result = Convert.ToString(dResult);
            screen.Text = result;
            history.Add($"Sq Rt {dValue1} = {dResult}");
            ButtonNegative.IsEnabled = false;
            ButtonDecimal.IsEnabled = false;
            AddToHistory();
        }
        private void Button_Click_Clear_History(object sender, RoutedEventArgs e)
        {
            historyBox.Clear();
            history = null;
            Clear();
        }
        private void Button_Click_Decimal(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            screen.Text = screen.Text + b.Content;
            ButtonDecimal.IsEnabled = false;
            EnableNumbers();
        }
        private void ResetOperators()
        {
            add = false;
            subtract = false;
            multiply = false;
            divide = false;
            ButtonAdd.IsEnabled = true;
            ButtonSubtract.IsEnabled = true;
            ButtonMultiply.IsEnabled = true;
            ButtonDivide.IsEnabled = true;
        }
        private void Clear()
        {
            screen.Text = String.Empty;
            ResetOperators();
            value1 = null;
            value2 = null;
            dValue1 = 0;
            dValue2 = 0;
            NegativeDecimalReset();
            EnableNumbers();
        }
        private void AddToHistory()
        {
            historyBox.Clear();
            foreach (string history in history)
            {
                historyBox.AppendText(history + Environment.NewLine);
            }
        }
        private void NegativeDecimalReset()
        {
            ButtonNegative.IsEnabled = true;
            ButtonDecimal.IsEnabled = true;
            ButtonSqRt.IsEnabled = true;
        }
        private void DisableNumbers()
        {
            Button0.IsEnabled = false;
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            Button5.IsEnabled = false;
            Button6.IsEnabled = false;
            Button7.IsEnabled = false;
            Button8.IsEnabled = false;
            Button9.IsEnabled = false;
        }
        private void EnableNumbers()
        {
            Button0.IsEnabled = true;
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;
            Button9.IsEnabled = true;
        }
        private void DisableOperators()
        {
            ButtonAdd.IsEnabled = false;
            ButtonSubtract.IsEnabled = false;
            ButtonDivide.IsEnabled = false;
            ButtonMultiply.IsEnabled = false;
        }
    }
}
