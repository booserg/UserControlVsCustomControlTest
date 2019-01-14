﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlsLib
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }

        public int MyControlValue
        {
            get
            {
                return (int)GetValue(MyControlValueProperty);
            }
            set
            {
                SetValue(MyControlValueProperty, value);
            }
        }

        public static readonly DependencyProperty MyControlValueProperty =
            DependencyProperty.Register("MyControlValue", typeof(int), typeof(MyControl), new PropertyMetadata(0, new PropertyChangedCallback(OnMyControlValueChanged)));

        private static void OnMyControlValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyControl;

            control.InternalText = ((int)e.NewValue).ToString();
        }

        internal string InternalText
        {
            get
            {
                return (string)GetValue(InternalTextProperty);
            }
            set
            {
                SetValue(InternalTextProperty, value);
            }
        }

        public static readonly DependencyProperty InternalTextProperty =
            DependencyProperty.Register("InternalText", typeof(string), typeof(MyControl), new PropertyMetadata("0", new PropertyChangedCallback(OnInternalTextChanged)));

        private static void OnInternalTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyControl;

            if (control != null)
            {
                int val;
                if (!int.TryParse((string)e.NewValue, out val))
                {
                    if (String.IsNullOrEmpty((string)e.NewValue))
                    {
                        control.InternalText = "0";
                    }
                    else if (!String.IsNullOrEmpty(e.OldValue as string))
                    {
                        control.InternalText = e.OldValue as string;
                    }
                    else
                    {
                        control.InternalText = "0";
                    }
                }

                control.MyControlValue = int.Parse(control.InternalText);
            }
        }
    }
}
