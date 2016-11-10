using System;
using System.Linq;

namespace Mantin.Controls.Wpf.Notification
{
    public class HyperLinkEventArgs : System.EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperLinkEventArgs"/> class.
        /// </summary>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyper link object for raised event.</param>
        public HyperLinkEventArgs(object hyperlinkObjectForRaisedEvent)
            :this()
        {
            this.HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperLinkEventArgs"/> class.
        /// </summary>
        public HyperLinkEventArgs()
            :base()
        { 
        }

        #endregion

        /// <summary>
        /// Gets or sets the hyper link object for raised event.  This object will be passed back when 
        /// the control raises the HyperlinkClicked event.
        /// </summary>
        /// <value>
        /// The hyper link object for raised event.
        /// </value>
        public object HyperlinkObjectForRaisedEvent { get; set; }
    }
}
