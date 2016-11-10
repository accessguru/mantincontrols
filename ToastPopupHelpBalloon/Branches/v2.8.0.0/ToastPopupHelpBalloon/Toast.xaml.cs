using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Foundation.Common.Controls.Wpf.ToastPopup
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Toast : UserControl
    {
        public static readonly DependencyProperty TextBlockHeaderProperty = DependencyProperty.Register("Text", typeof(string), typeof(Toast));

        public Toast()
        {
            InitializeComponent();
        }

        [Description("The text displayed in the Toast Pop up."), Category("Common Properties")]
        public string Text
        {
            get
            {
                return (string)GetValue(TextBlockHeaderProperty);
            }

            set
            {
                this.SetValue(TextBlockHeaderProperty, value);
            }
        }
    }
}
