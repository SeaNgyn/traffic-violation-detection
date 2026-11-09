using System.Collections.Generic;
using System.Windows.Controls;

namespace TrafficViolationDetection.Views
{
    public partial class DashboardView : Page
    {
        public DashboardView()
        {
            InitializeComponent();

            DataContext = new { };
        }
    }
}