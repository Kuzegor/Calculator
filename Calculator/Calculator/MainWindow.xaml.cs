using System;
using System.Collections.Generic;
using System.Data;
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
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement element in GridWithButtons.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
            outerBorder.MouseLeftButtonDown += OuterBorder_MouseLeftButtonDown;
            closeButton.Click += CloseButton_Click;
            minimizeButton.Click += MinimizeButton_Click;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OuterBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = ((Button)e.OriginalSource).Content.ToString();

            if (str=="AC")
            {
                textBlock.Text = "";
            }
            else if (str=="=")
            {
                try
                {
                    string value = new DataTable().Compute(textBlock.Text, null).ToString();
                    textBlock.Text = $"={value}";
                }
                catch (Exception)
                {
                    textBlock.Text = "<invalid expression>";
                }
            }
            else if (str=="BS")
            {
                textBlock.Text = textBlock.Text.Substring(0, textBlock.Text.Length - 1);
            }
            else
            {
                textBlock.Text += str;  
            }
        }
    }
}
