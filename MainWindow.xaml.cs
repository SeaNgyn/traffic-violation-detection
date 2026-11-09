using System;
using System.Windows;
using System.Windows.Controls;

namespace TrafficViolationDetection
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button &&
                button.Tag is string page)
            {
                PageTitle.Text = page;

                MainFrame.Navigate(
                    new Uri(
                        $"Views/{page}View.xaml",
                        UriKind.Relative));
            }
        }
    }
}