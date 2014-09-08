using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Foundation.Common.Controls.Wpf.Notification
{
    public partial class HelpBalloon : UserControl
    {
        #region Members

        private Balloon balloon = null;

        public static readonly DependencyProperty TextBlockHeaderProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(HelpBalloon));

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
                return (string)GetValue(TextBlockHeaderProperty);
            }

            set
            {
                this.SetValue(TextBlockHeaderProperty, value);
            }
        }

        #endregion 

        #region Event Handlers

        /// <summary>
        /// Images the mouse enter.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void ImageMouseEnter(object sender, MouseEventArgs e)
        {
            if (balloon == null)
            {
                balloon = new Balloon(this, this.Caption);
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
