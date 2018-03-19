using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mantin.Controls.Wpf.Notification
{
    public partial class HelpBalloon : UserControl
    {
        #region Members

        private Balloon balloon = null;

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(HelpBalloon));

        public static readonly DependencyProperty BalloonTypeProperty =
            DependencyProperty.Register("BalloonType", typeof(BalloonType), typeof(HelpBalloon), new PropertyMetadata(new PropertyChangedCallback(OnBalloonTypeChanged)));

        public static readonly DependencyProperty MaxHeightProperty =
            DependencyProperty.Register("MaxHeight", typeof(double), typeof(HelpBalloon));

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpBalloon"/> class.
        /// </summary>
        public HelpBalloon()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the maximum height constraint of the element.
        /// </summary>
        [Description("The maximum height of the Balloon caption."), Category("Common Properties")]
        public double MaxHeight
        {
            get
            {
                return (double)GetValue(MaxHeightProperty);
            }

            set
            {
                this.SetValue(MaxHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [Description("The caption displayed in the Help Balloon."), Category("Common Properties")]
        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }

            set
            {
                this.SetValue(CaptionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the balloon.
        /// </summary>
        /// <value>
        /// The type of the balloon.
        /// </value>
        [Description("The type of Balloon to display."), Category("Common Properties")]
        public BalloonType BalloonType
        {
            get
            {
                return (BalloonType)GetValue(BalloonTypeProperty);
            }

            set
            {
                this.SetValue(BalloonTypeProperty, value);
            }
        }

        #endregion 

        #region Event Handlers

        /// <summary>
        /// Called when [balloon type changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnBalloonTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HelpBalloon helpBalloon = (HelpBalloon)d;

            if (helpBalloon.BalloonType == BalloonType.Help)
            {
                helpBalloon.imageControl.Source = Properties.Resources.help20.ToBitmapImage();
            }
            else
            {
                helpBalloon.imageControl.Source = Properties.Resources.information20.ToBitmapImage();
            }
        }

        /// <summary>
        /// Images the mouse enter.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void ImageMouseEnter(object sender, MouseEventArgs e)
        {
            if (balloon == null)
            {
                balloon = new Balloon(this, this.Caption, this.BalloonType, this.MaxHeight);
                balloon.Closed += this.BalloonClosed;
                balloon.Show();
            }
        }

        /// <summary>
        /// Balloons the closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BalloonClosed(object sender, EventArgs e)
        {
            this.balloon = null;
        }

        #endregion
    }
}
