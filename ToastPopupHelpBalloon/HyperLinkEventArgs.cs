namespace Mantin.Controls.Wpf.Notification
{
    public class HyperLinkEventArgs : System.EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperLinkEventArgs"/> class.
        /// </summary>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyperlink object for raised event.</param>
        public HyperLinkEventArgs(object hyperlinkObjectForRaisedEvent)
            : this()
        {
            HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperLinkEventArgs"/> class.
        /// </summary>
        public HyperLinkEventArgs()
        {
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the hyperlink object for raised event.  This object will be passed back when
        /// the control raises the HyperlinkClicked event.
        /// </summary>
        /// <value>
        /// The hyperlink object for raised event.
        /// </value>
        public object HyperlinkObjectForRaisedEvent { get; set; }
    }
}