using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AktienHandelSim.ViewModel;

namespace AktienHandelSim.Validations
{
    public class AbkuerzungDetailValidator : ValidationRule
    {
        private ObservableCollection<AktieViewModel> myLocalAktieViewModels;
        private bool abkuerzungExists = false;

        public AbkuerzungDetailValidator()
        {  
         
        }


        public override ValidationResult Validate
            (object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "value cannot be empty.");
            else
            {

                abkuerzungExists=MainViewModel.CallValidation(value.ToString());

                if (abkuerzungExists)

                {
                    return new ValidationResult
                        (false, "Name cannot be more than 3 characters long.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
