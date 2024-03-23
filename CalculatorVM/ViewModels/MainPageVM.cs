using CalculatorVM.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculatorVM.ViewModels
{
    internal class MainPageVM : INotifyPropertyChanged
    {
        #region Attributes
        private float num1 = 0;
        private float num2 = 0;
        private string selectedOp = "";
        private float res = 0;
        private string displayText = "0";
        private DelegateCommand<string> selectOp;
        private DelegateCommand<string> calculateNums;
        private DelegateCommand calculateRes;
        #endregion

        #region Properties
        public string DisplayText { get { return displayText; } }
        public DelegateCommand<string> SelectOp { get { return selectOp; } }
        public DelegateCommand<string> CalculateNums { get { return calculateNums; } }
        public DelegateCommand CalculateRes { get { return calculateRes; } }
        #endregion

        #region Constructor
        public MainPageVM()
        {
            selectOp = new DelegateCommand<string>(selectOp_Execute, selectOp_CanExecute);
            calculateNums = new DelegateCommand<string>(calculateNums_Execute, calculateNums_CanExecute);
            calculateRes = new DelegateCommand(calculateRes_Execute, calculateRes_CanExecute);
        }
        #endregion

        #region Commands
        private void selectOp_Execute(string symbol)
        {
            switch (symbol)
            {
                case "+":
                    selectedOp = "+";
                    break;
                case "-":
                    selectedOp = "-";
                    break;
                case "*":
                    selectedOp = "*";
                    break;
                case "/":
                    selectedOp = "/";
                    break;
                case "C":
                    selectedOp = "";
                    num1 = 0;
                    num2 = 0;
                    res = 0;
                    displayText = "0";
                    break;
            }
            stringifyToDisplay(symbol);
        }
        private bool selectOp_CanExecute(string symbol)
        {
            if (string.IsNullOrEmpty(selectedOp)) return true;
            else return false;
        }
        private void calculateNums_Execute(string pressedNum)
        {
            if (selectedOp == "")
            {
                if (num1 == 0)
                {
                    string concat = pressedNum;
                    stringifyToDisplay(pressedNum);
                    float.TryParse(concat, out num1);
                }
                else
                {
                    string concat = num1.ToString() + pressedNum;
                    stringifyToDisplay(pressedNum);
                    float.TryParse(concat, out num1);
                }
            }
            else
            {
                if (num2 == 0)
                {
                    string concat = pressedNum;
                    stringifyToDisplay(pressedNum);
                    float.TryParse(concat, out num2);
                }
                else
                {
                    string concat = num2.ToString() + pressedNum;
                    stringifyToDisplay(pressedNum);
                    float.TryParse(concat, out num2);
                }
            }
        }
        private bool calculateNums_CanExecute(string num)
        {
            if (res != 0) return false;
            else return true;
        }
        private void calculateRes_Execute()
        {
            switch (selectedOp)
            {
                case "+":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    res = num1 / num2;
                    break;
            }
            stringifyToDisplay("="+res.ToString());
        }
        private bool calculateRes_CanExecute()
        {
            if (num1 == 0 || num2 == 0) return false;
            else return true;
        }
        #endregion

        #region Methods
        private void stringifyToDisplay(string parameter)
        {
            if (displayText == "0")
            {
                if (parameter == "+" || parameter == "-" || parameter == "*"|| parameter == "/" || parameter == "C") displayText = "0";
                else displayText = parameter;
            }
            else
            {
                displayText = displayText + parameter;
            }
            NotifyPropertyChanged("DisplayText");
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