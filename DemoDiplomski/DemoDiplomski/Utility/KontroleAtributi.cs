using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DemoDiplomski.Utility
{
    //
    public class KontroleAtributi : ContentControl
    {
        public string LabelProperty
        {
            get { return (string)GetValue(LabelDependencyProperty); }
            set { SetValue(LabelDependencyProperty, value); }
        }

        public static DependencyProperty LabelDependencyProperty = DependencyProperty.RegisterAttached
            (
                "LabelProperty",
                typeof(string),
                typeof(KontroleAtributi)
            );

        public string LabelWidth
        {
            get { return (string)GetValue(LabelWidthDependencyProperty); }
            set { SetValue(LabelWidthDependencyProperty, value); }
        }

        public static DependencyProperty LabelWidthDependencyProperty = DependencyProperty.RegisterAttached
            (
                "LabelWidth",
                typeof(string),
                typeof(KontroleAtributi)
            );

        public string PropertyWidth
        {
            get { return (string)GetValue(PropertyWidthDependencyProperty); }
            set { SetValue(PropertyWidthDependencyProperty, value); }
        }

        public static DependencyProperty PropertyWidthDependencyProperty = DependencyProperty.RegisterAttached
            (
                "PropertyWidth",
                typeof(string),
                typeof(KontroleAtributi)
            );
    }
}
