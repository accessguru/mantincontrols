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
        
        public new static readonly DependencyProperty MaxHeightProperty =
            DependencyProperty.Register("MaxHeight", typeof(double), typeof(HelpBalloon));
        
        public static readonly DependencyProperty AutoWidthProperty =
            DependencyProperty.Register("AutoWidth", typeof(bool), typeof(HelpBalloon));

        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(HelpBalloon));
        
        #endregion
        
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpBalloon"/> class.
        /// </summary>
        public HelpBalloon()
        {
            InitializeComponent();
            this.ShowCloseButton = true;
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
        
        /// <summary>
        /// Gets or sets the maximum height constraint of the element.
        /// </summary>
        [Description("The maximum height of the Balloon caption."), Category("Common Properties")]
        public new double MaxHeight
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
        /// Gets or sets the width of the element.
        /// </summary>
        [Description("Sets whether the Help Balloon's width will be auto set."), Category("Common Properties")]
        public bool AutoWidth
        {
            get
            {
                return (bool)GetValue(AutoWidthProperty);
            }
            
            set
            {
                this.SetValue(AutoWidthProperty, value);
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
            
            switch (helpBalloon.BalloonType)
            {
                case BalloonType.Help:
                    helpBalloon.imageControl.Source = Properties.Resources.help20.ToBitmapImage();
                    break;
                case BalloonType.Information:
                    helpBalloon.imageControl.Source = Properties.Resources.information20.ToBitmapImage();
                    break;
                case BalloonType.Warning:
                    helpBalloon.imageControl.Source = Properties.Resources.warning20.ToBitmapImage();
                    break;
                default:
                    throw new InvalidOperationException("unsupported BalloonType");
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
                balloon = new Balloon(this, this.Caption, this.BalloonType, this.MaxHeight, this.AutoWidth, true, this.ShowCloseButton);
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
