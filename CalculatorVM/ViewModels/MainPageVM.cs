using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorVM.ViewModels
{
    internal class MainPageVM : INotifyPropertyChanged
    {
        #region Attributes
        private float num1;
        private float num2;
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
            selectOp = new DelegateCommand<string>(selectOp_execute);
            calculateNums = new DelegateCommand<string>(calculateNums_execute);
        }
        #endregion

        #region Commands
        private void selectOp_execute(string symbol)
        {
        }
        private void calculateNums_execute(string num)
        {
        }
        private void stringifyToDisplay()
        { 
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region ViewModel
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
