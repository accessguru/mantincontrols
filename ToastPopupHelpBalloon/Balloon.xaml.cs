using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace Mantin.Controls.Wpf.Notification
{
    public partial class Balloon
    {
        #region Members

        private readonly Control control;
        private readonly bool placeInCenter;
        public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register(nameof(ShowCloseButton), typeof(bool), typeof(Balloon), new PropertyMetadata(OnShowCloseButtonChanged));

        #endregion Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        public Balloon(Control control, string caption, BalloonType balloonType)
            : this(control, caption, balloonType, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="title">The title.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        public Balloon(Control control, string title, string caption, BalloonType balloonType)
            : this(control, caption, balloonType, 0, 0, false, true, true, title)
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
            : this(control, caption, balloonType, 0, 0, false, placeInCenter, showCloseButton)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="title">The title.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        /// <param name="placeInCenter">if set to <c>true</c> [place in center].</param>
        /// <param name="showCloseButton">if set to <c>true</c> [show close button].</param>
        public Balloon(Control control, string title, string caption, BalloonType balloonType, bool placeInCenter, bool showCloseButton)
            : this(control, caption, balloonType, 0, 0, false, placeInCenter, showCloseButton, title)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Balloon" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="balloonType">Type of the balloon.</param>
        /// <param name="maxHeight">The maximum height.</param>
        /// <param name="maxWidth">The maximum width.</param>
        /// <param name="autoWidth">if set to <c>true</c> [automatic width].</param>
        /// <param name="placeInCenter">if set to <c>true</c> [place in center].</param>
        /// <param name="showCloseButton">if set to <c>true</c> [show close button].</param>
        /// <param name="title">The title.</param>
        public Balloon(Control control,
            string caption,
            BalloonType balloonType,
            double maxHeight = 0,
            double maxWidth = 0,
            bool autoWidth = false,
            bool placeInCenter = true,
            bool showCloseButton = true,
            string title = null)
        {
            InitializeComponent();
            this.control = control;
            this.placeInCenter = placeInCenter;
            ShowCloseButton = showCloseButton;
            Owner = GetWindow(control);

            if (placeInCenter)
            {
                Owner!.LocationChanged += OwnerLocationChanged;
                control.LayoutUpdated += OwnerLocationChanged;
            }

            imageClose.Visibility = showCloseButton ? Visibility.Visible : Visibility.Collapsed;

            Owner!.Closing += OwnerClosing;
            LinearGradientBrush brush;

            switch (balloonType)
            {
                case BalloonType.Help:
                    imageType.Source = Properties.Resources.help.ToBitmapImage();
                    brush = FindResource("HelpGradient") as LinearGradientBrush;
                    break;

                case BalloonType.Information:
                    imageType.Source = Properties.Resources.Information.ToBitmapImage();
                    brush = FindResource("InfoGradient") as LinearGradientBrush;
                    break;

                default:
                    imageType.Source = Properties.Resources.Warning.ToBitmapImage();
                    brush = FindResource("WarningGradient") as LinearGradientBrush;
                    break;
            }

            borderBalloon.SetValue(BackgroundProperty, brush);

            if (autoWidth)
            {
                SizeToContent = SizeToContent.WidthAndHeight;
            }

            textBlockCaption.Text = caption;

            if (maxHeight > 0)
            {
                scrollViewerCaption.MaxHeight = maxHeight;
            }

            if (maxWidth > 0)
            {
                MaxWidth = maxWidth;
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                textBlockTitle.Text = title;
            }
            else
            {
                textBlockTitle.Visibility = Visibility.Collapsed;
                lineTitle.Visibility = Visibility.Collapsed;
            }

            CalcPosition();
        }

        #endregion Constructors

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
            get => (bool)GetValue(ShowCloseButtonProperty);
            private init => SetValue(ShowCloseButtonProperty, value);
        }

        #endregion Properties

        #region Private Methods

        /// <summary>
        /// Determines whether [is visible to user].
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">container</exception>
        public bool IsVisibleToUser()
        {
            if (!control.IsVisible)
            {
                return false;
            }

            var container = (FrameworkElement)VisualTreeHelper.GetParent(control);
            Rect bounds = control.TransformToAncestor(container!).TransformBounds(new Rect(0.0, 0.0, control.RenderSize.Width, control.RenderSize.Height));
            Rect rect = new(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.IntersectsWith(bounds);
        }

        /// <summary>
        /// Calculates the position.
        /// </summary>
        private void CalcPosition()
        {
            if (!IsVisibleToUser())
            {
                Close();
                return;
            }

            PresentationSource source = PresentationSource.FromVisual(control);

            if (source != null)
            {
                // Position balloon relative to the help image and screen placement
                // Compensate for the bubble point
                double captionPointMargin = PathPointLeft.Margin.Left;

                Point location = control.PointToScreen(new Point(0, 0));
                double leftPosition;

                if (placeInCenter)
                {
                    leftPosition = location.X + (control.ActualWidth / 2) - captionPointMargin;
                }
                else
                {
                    leftPosition = System.Windows.Forms.Control.MousePosition.X - captionPointMargin;

                    if (leftPosition < location.X)
                    {
                        leftPosition = location.X;
                    }
                    else if (leftPosition > location.X + control.ActualWidth)
                    {
                        leftPosition = location.X + control.ActualWidth - (captionPointMargin * 2);
                    }
                }

                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(new WindowInteropHelper(Application.Current.MainWindow!).Handle);

                // Check if the window is on the secondary screen.
                if ((leftPosition < 0 && screen.WorkingArea.Width + leftPosition + Width < screen.WorkingArea.Width) ||
                    leftPosition >= 0 && leftPosition + Width < screen.WorkingArea.Width)
                {
                    PathPointRight.Visibility = Visibility.Hidden;
                    PathPointLeft.Visibility = Visibility.Visible;
                    Left = leftPosition;
                }
                else
                {
                    PathPointLeft.Visibility = Visibility.Hidden;
                    PathPointRight.Visibility = Visibility.Visible;
                    Left = location.X + (control.ActualWidth / 2) + captionPointMargin - Width;
                }

                Top = location.Y + (control.ActualHeight / 2);
            }
        }

        #endregion Private Methods

        #region Event Handlers

        /// <summary>
        /// Called when [show close button changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnShowCloseButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Balloon balloon = (Balloon)d;
            balloon.imageClose.Visibility = balloon.ShowCloseButton ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Doubles the animation completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            if (!IsMouseOver)
            {
                Close();
            }
        }

        /// <summary>
        /// Mains the window location changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OwnerLocationChanged(object sender, EventArgs e)
        {
            CalcPosition();
        }

        /// <summary>
        /// Owners the closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private static void OwnerClosing(object sender, CancelEventArgs e)
        {
            const string name = nameof(Balloon);

            foreach (Window window in Application.Current.Windows)
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
        private void ImageCloseMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => Close();

        #endregion Event Handlers
    }
}