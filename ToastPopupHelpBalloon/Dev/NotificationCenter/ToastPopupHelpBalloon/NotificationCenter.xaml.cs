using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mantin.Controls.Wpf.Notification
{
    /// <summary>
    /// Interaction logic for NotificationCenter.xaml
    /// </summary>
    public partial class NotificationCenter : UserControl
    {
        private readonly List<ToastPopUp> toastList = new List<ToastPopUp>();

        public NotificationCenter()
        {
            InitializeComponent();
        }

        public void Add(ToastPopUp toastPopUp)
        {
            this.toastList.Add(toastPopUp);
            toastPopUp.Show();
            this.ImageNotifiication.Visibility = Visibility.Visible;
            this.Animate(true);
        }

        public void Animate(bool isVisible)
        {
            Storyboard sb = new Storyboard();

            var animation = new GridLengthAnimation
            {
                Duration = new Duration(new TimeSpan(0,0,0,0,500)),
                From = this.RowDetails.Height,
                To = new GridLength(isVisible ? 100 : 0, GridUnitType.Pixel)
            };

            // Set the target of the animation
            Storyboard.SetTarget(animation, this.GridDetails);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));

            // Kick the animation off
            sb.Children.Add(animation);
            sb.Begin();
        }
    }
}
