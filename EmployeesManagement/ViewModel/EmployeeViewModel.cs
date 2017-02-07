using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using EmployeeApplication.ViewModel.Command;
using EmployeeLib.Model;

namespace EmployeeApplication.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    OnPropertyChanged();
                }
            }
        }

        public LanguageSupportCommand ChangeLanguageCommand { get; set; }

        public EmployeeViewModel()
        {
            var employees = EmploymentAgency.GetEmployees();
            Employees = new ObservableCollection<Employee>(employees);
            ChangeLanguageCommand = new LanguageSupportCommand(ChangeLanguageAction);
        }

        private void ChangeLanguageAction(object obj)
        {
            var selectedCulture = obj as CultureInfo;
            Properties.CultureSupport.ChangeCulture(selectedCulture);      
        }
    }
}
