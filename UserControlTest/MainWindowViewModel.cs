﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserControlTest
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public ICommand SetCommandUserControl => setCommandUserControl;
        private DelegateCommand setCommandUserControl;

        public ICommand SetCommandCustomControl => setCommandCustomControl;
        private DelegateCommand setCommandCustomControl;

        public MainWindowViewModel()
        {
            SomeValueUserControl = 10;

            setCommandUserControl = new DelegateCommand(() => { SomeValueUserControl = 11; });

            SomeValueCustomControl = 14;

            setCommandCustomControl = new DelegateCommand(() => { SomeValueCustomControl = 13; });
        }

        private int someValueUserControl;
        public int SomeValueUserControl
        {
            get
            {
                return someValueUserControl;
            }
            set
            {
                someValueUserControl = value;
                NotifyPropertyChanged("SomeValueUserControl");
            }
        }

        private int someValueCustomControl;
        public int SomeValueCustomControl
        {
            get
            {
                return someValueCustomControl;
            }
            set
            {
                someValueCustomControl = value;
                NotifyPropertyChanged("SomeValueCustomControl");
            }
        }

        public string this[string columnName]
        {
            get
            {
                if(columnName == "SomeValueUserControl")
                {
                    if (someValueUserControl > 20)
                        return "Out of the range (should be less then 20)";
                }
                else if (columnName == "SomeValueCustomControl")
                {
                    if (someValueCustomControl > 40)
                        return "Out of the range (should be less then 40)";
                }
                return "";
            }
        }

        public string Error
        {
            get
            {
                return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            // Check if a valid propertyName has been specified
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
