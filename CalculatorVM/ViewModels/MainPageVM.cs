using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorVM.ViewModels
{
    internal class MainPageVM : INotifyPropertyChanged
    {
        #region Attributes
        private float num1 = 0;
        private float num2 = 0;
        private string selectedOp;
        private float res;
        private string displayText;
        private DelegateCommand<string> selectOp;
        private DelegateCommand<string> calculateNums;
        #endregion

        #region Properties
        public string DisplayText { get; }
        public DelegateCommand SelectOp { get; }
        public DelegateCommand CalculateNums { get; }
        public DelegateCommand StringifyToDisplay { get; }
        #endregion

        #region Constructor
        public MainPageVM()
        {
            selectOp = new DelegateCommand<string>(selectOp_execute, selectOp_canExecute);
            calculateNums = new DelegateCommand<string>(calculateNums_execute, calculateNums_canExecute);
        }
        #endregion

        #region Commands
        private void selectOp_execute(string symbol)
        {
            switch (symbol)
            {
                case "+":
                    break;
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
                case ".":
                    break;
                case "C":
                    break;
                case "=":
                    break;
            }
        }
        private bool selectOp_canExecute(string symbol)
        {
            return true;
        }
        private void calculateNums_execute(string num)
        {
            Button button = new Button();
            string parameter = (string)button.CommandParameter;
        }
        private bool calculateNums_canExecute(string num)
        {
            if (num1 == 0 || num2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void stringifyToDisplay()
        { 
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        #endregion

        #region ViewModel
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
