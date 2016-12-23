using System;
using System.ComponentModel.DataAnnotations;
using Sniffo.Windows;

namespace Sniffo.DesktopClient.ViewModels
{
    public class CustomerViewModel : ViewModel
    {
        private string customerName;

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string CustomerName
        {
            get { return customerName; }

            set
            {
                customerName = value;
                NotifyPropertyChanged();
            }
        }

        protected override string OnValidate(string propertyName)
        {
            if (CustomerName != null && !CustomerName.Contains(" ")) 
                return "Customer name must include a first and a last name.";

            return base.OnValidate(propertyName);
        }
    }
}