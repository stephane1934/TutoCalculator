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

namespace TutoCalculator
{
    public partial class MainWindow : Window
    {
        double lastNumber,result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            pourcentageButton.Click += PourcentageButton_Click;
            egualButton.Click += EgualButton_Click;
        }

        private void PourcentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0) tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void EgualButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustraction:
                        result = SimpleMath.Sustraction(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(),out lastNumber))
            {
                lastNumber = lastNumber /100;
                resultLabel.Content = lastNumber.ToString();
            }

        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            lastNumber = 0;
            result = 0;
        }

        private void OperationButton_Click(object sender,RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplierButton) selectedOperator = SelectedOperator.Multiplication;
            if (sender == moinsButton) selectedOperator = SelectedOperator.Sustraction;
            if (sender == plusButton) selectedOperator = SelectedOperator.Addition;
            if (sender == divisionButton) selectedOperator = SelectedOperator.Division;
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains(",")) resultLabel.Content = $"{resultLabel.Content},";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton) selectedValue = 0;
            if (sender == unButton) selectedValue = 1;
            if (sender == deuxButton) selectedValue = 2;
            if (sender == troisButton) selectedValue = 3;
            if (sender == quatreButton) selectedValue = 4;
            if (sender == cinqButton) selectedValue = 5;
            if (sender == sixButton) selectedValue = 6;
            if (sender == septButton) selectedValue = 7;
            if (sender == huitButton) selectedValue = 8;
            if (sender == neufButton) selectedValue = 9;

            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            } else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,Sustraction,Multiplication,Division
    }

    public class SimpleMath
    {
        public static double Add(double n1,double n2)
        {
            return n1 + n2;
        }
        public static double Sustraction(double n1,double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1,double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1,double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by zero is Not supported","Wrong operation",MessageBoxButton.OK,MessageBoxImage.Error);
                return 0;
            }
                return n1 / n2;
        }
    }
}
