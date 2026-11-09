using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationDetection.Services
{
    public class NavigationService
    {
        public event Action<string>? NavigationRequested;

        public void NavigateTo(string viewName)
        {
            if (string.IsNullOrWhiteSpace(viewName))
            {
                return;
            }

            NavigationRequested?.Invoke(viewName);
        }
    }
}