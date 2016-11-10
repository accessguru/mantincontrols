using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace Mantin.Controls.Wpf.Notification
{
    public partial class Balloon : Window
    {
        #region Members

        private Control control;
        private bool placeInCenter;

        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(Balloon), new PropertyMetadata(new PropertyChangedCallback(OnShowCloseButtonChanged)));

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        public Balloon(Control control, string caption, BalloonType balloonType) 
            : this(control, caption, balloonType, 0, false, true, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        /// <param name="placeInCenter">if set to <c>true</c> [place in center].</param>
        /// <param name="showCloseButton">if set to <c>true</c> [show close button].</param>
        public Balloon(Control control, string caption, BalloonType balloonType, bool placeInCenter, bool showCloseButton)
            : this(control, caption, balloonType, 0, false, placeInCenter, showCloseButton)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        /// <param name="maxHeight">The maximum height.</param>
        /// <param name="autoWidth">if set to <c>true</c> [automatic width].</param>
        /// <param name="placeInCenter">if set to <c>true</c> [place in center].</param>
        /// <param name="showCloseButton">if set to <c>true</c> [show close button].</param>
        public Balloon(Control control, string caption, BalloonType balloonType, double maxHeight = 0, bool autoWidth = false, bool placeInCenter = true, bool showCloseButton = true)
        {
            InitializeComponent();
            this.control = control;
            this.placeInCenter = placeInCenter;
            this.ShowCloseButton = showCloseButton;

            if (placeInCenter)
            {
                Application.Current.MainWindow.LocationChanged += this.MainWindowLocationChanged;
                control.LayoutUpdated += this.MainWindowLocationChanged;
            }

            if (showCloseButton)
            {
                this.imageClose.Visibility = Visibility.Visible;
            }
            else
            {
                this.imageClose.Visibility = Visibility.Collapsed;
            }

            Application.Current.MainWindow.Closing += this.OwnerClosing;
            LinearGradientBrush brush;

            if (balloonType == BalloonType.Help)
            {
                this.imageType.Source = Properties.Resources.help.ToBitmapImage();
                brush = this.FindResource("HelpGradient") as LinearGradientBrush;
            }
            else if (balloonType == BalloonType.Information)
            {
                this.imageType.Source = Properties.Resources.Information.ToBitmapImage();
                brush = this.FindResource("InfoGradient") as LinearGradientBrush;
            }
            else
            {
                this.imageType.Source = Properties.Resources.Warning.ToBitmapImage();
                brush = this.FindResource("WarningGradient") as LinearGradientBrush;
            }

            this.borderBalloon.SetValue(Control.BackgroundProperty, brush);

            if (autoWidth)
            {
                this.SizeToContent = SizeToContent.WidthAndHeight;
                this.textBlockCaption.TextWrapping = TextWrapping.NoWrap;
            }

            this.textBlockCaption.Text = caption;

            if (maxHeight > 0)
            {
                this.scrollViewerCaption.MaxHeight = maxHeight;
            }

            this.CalcPosition();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [show close button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show close button]; otherwise, <c>false</c>.
        /// </value>
        [Description("Sets whether the Help Balloon's close button will be visible."), Category("Common Properties")]
        public bool ShowCloseButton
        {
            get
            {
                return (bool)GetValue(ShowCloseButtonProperty);
            }

            set
            {
                this.SetValue(ShowCloseButtonProperty, value);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Calculates the position.
        /// </summary>
        private void CalcPosition()
        {
            PresentationSource source = PresentationSource.FromVisual(this.control);

            if (source != null)
            {
                // Position balloon relative to the help image and screen placement
                // Compensate for the bubble point
                double captionPointMargin = this.PathPointLeft.Margin.Left;

                var screen = System.Windows.Forms.Screen.FromHandle(new WindowInteropHelper(Application.Current.MainWindow).Handle);
                Point location = this.control.PointToScreen(new System.Windows.Point(0, 0));

                double leftPosition = 0;

                if (this.placeInCenter)
                {
                    leftPosition = location.X + (this.control.ActualWidth / 2) - captionPointMargin;
                }
                else
                {
                    leftPosition = System.Windows.Forms.Control.MousePosition.X - captionPointMargin;

                    if (leftPosition < location.X)
                    {
                        leftPosition = location.X;
                    }
                    else if (leftPosition > location.X + this.control.ActualWidth)
                    {
                        leftPosition = location.X + this.control.ActualWidth - (captionPointMargin * 2);
                    }
                }

                // Check if the window is on the secondary screen.
                if (((leftPosition < 0 && screen.WorkingArea.Width + leftPosition + this.Width < screen.WorkingArea.Width)) ||
                    leftPosition >= 0 && leftPosition + this.Width < screen.WorkingArea.Width)
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
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Called when [show close button changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnShowCloseButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Balloon balloon = (Balloon)d;

            if (balloon.ShowCloseButton)
            {
                balloon.imageClose.Visibility = Visibility.Visible;
            }
            else
            {
                balloon.imageClose.Visibility = Visibility.Collapsed;
            }
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

        /// <summary>
        /// Images the close mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void ImageCloseMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
