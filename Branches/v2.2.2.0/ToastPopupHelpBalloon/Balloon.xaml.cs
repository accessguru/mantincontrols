using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mantin.Controls.Wpf.Notification
{
    public partial class Balloon : Window
    {
        private Control control;

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        /// <param name="maxHeight">The maximum height.</param>
        public Balloon(Control control, string caption, BalloonType balloonType, double maxHeight = 0)
        {
            InitializeComponent();
            this.control = control;

            Application.Current.MainWindow.Closing += this.OwnerClosing;
            Application.Current.MainWindow.LocationChanged += this.MainWindowLocationChanged;
            control.LayoutUpdated += this.MainWindowLocationChanged;            

            LinearGradientBrush brush;

            if (balloonType == BalloonType.Help)
            {
                this.imageType.Source = Properties.Resources.help.ToBitmapImage();
                brush = this.FindResource("HelpGradient") as LinearGradientBrush;
            }
            else
            {
                this.imageType.Source = Properties.Resources.Information.ToBitmapImage();
                brush = this.FindResource("InfoGradient") as LinearGradientBrush;
            }

            this.borderBalloon.SetValue(Control.BackgroundProperty, brush);

            if (maxHeight > 0)
            {
                this.scrollViewerCaption.Height = maxHeight;
            }

            this.textBlockCaption.Text = caption;
            this.CalcPosition();
        }

        /// <summary>
        /// Calculates the position.
        /// </summary>
        /// <param name="control">The control.</param>
        private void CalcPosition()
        {
            // Position balloon relative to the help image and screen placement
            // Compensate for the bubble point
            double captionPointMargin = this.PathPointLeft.Margin.Left;

            Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            var location = this.control.PointToScreen(new System.Windows.Point(0, 0));

            double leftPosition = location.X + (this.control.ActualWidth / 2) - captionPointMargin;

            if (leftPosition + this.Width < workingArea.Width)
            {
                this.PathPointRight.Visibility = Visibility.Hidden;
                this.PathPointLeft.Visibility = Visibility.Visible;
                this.Left = leftPosition;
            }
            else
            {
                this.PathPointLeft.Visibility = Visibility.Hidden;
                this.PathPointRight.Visibility = Visibility.Visible;
                this.Left = location.X + (this.control.ActualWidth / 2) + captionPointMargin - this.Width;
            }

            this.Top = location.Y + (this.control.ActualHeight / 2);
        }

        /// <summary>
        /// Doubles the animation completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            if (!this.IsMouseOver)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Mains the window location changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainWindowLocationChanged(object sender, EventArgs e)
        {
            this.CalcPosition();
        }

        /// <summary>
        /// Owners the closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void OwnerClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string name = typeof(Balloon).Name;

            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowType = window.GetType().Name;
                if (windowType.Equals(name))
                {
                    window.Close();
                }
            }
        }
    }
}
