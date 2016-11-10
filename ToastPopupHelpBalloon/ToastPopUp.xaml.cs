using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Mantin.Controls.Wpf.Notification
{
    public partial class ToastPopUp : Window
    {
        #region Members

        private readonly string name = typeof(ToastPopUp).Name;
        private volatile object lockObject = new object();
        private string title;

        #endregion Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="notificationType">Type of the notification.</param>
        public ToastPopUp(string title, string text, NotificationType notificationType)
            : this(title, notificationType)
        {
            this.TextBoxShortDescription.Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="notificationType">Type of the notification.</param>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyperlink object for raised event.</param>
        public ToastPopUp(string title, string text, string hyperlinkText, NotificationType notificationType, object hyperlinkObjectForRaisedEvent = null)
            : this(title, text, notificationType)
        {
            this.HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
            this.SetHyperLinkButton(hyperlinkText);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="textInlines">The inlines.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyperlink object for raised event.</param>
        public ToastPopUp(string title, List<Inline> textInlines, string hyperlinkText, ImageSource imageSource, object hyperlinkObjectForRaisedEvent = null) 
            : this(title)
        {
            this.imageLeft.Source = imageSource;
            this.TextBoxShortDescription.Inlines.AddRange(textInlines);
            this.SetHyperLinkButton(hyperlinkText);
            this.HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="textInlines">The inlines.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyperlink object for raised event.</param>
        public ToastPopUp(string title, List<Inline> textInlines, string hyperlinkText, Bitmap imageSource, object hyperlinkObjectForRaisedEvent = null)
            : this(title, textInlines, hyperlinkText, imageSource.ToBitmapImage(), hyperlinkObjectForRaisedEvent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="textInlines">The text inlines.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="notificationType">Type of the notification.</param>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyperlink object for raised event.</param>
        public ToastPopUp(string title, List<Inline> textInlines, string hyperlinkText, NotificationType notificationType, object hyperlinkObjectForRaisedEvent = null)
            : this(title, notificationType)
        {           
            this.HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
            this.TextBoxShortDescription.Inlines.AddRange(textInlines);
            this.SetHyperLinkButton(hyperlinkText);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyperlink object for raised event.</param>
        public ToastPopUp(string title, string text, string hyperlinkText, Bitmap imageSource, object hyperlinkObjectForRaisedEvent = null)
            : this(title)
        {
            this.TextBoxShortDescription.Text = text;
            this.SetHyperLinkButton(hyperlinkText);
            this.imageLeft.Source = imageSource.ToBitmapImage();
            this.HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="imageSource">The image source.</param>
        public ToastPopUp(string title, string text, ImageSource imageSource)
            : this(title)
        {
            this.TextBoxShortDescription.Text = text;
            this.imageLeft.Source = imageSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="imageSource">The image source.</param>
        public ToastPopUp(string title, string text, Bitmap imageSource)
            : this(title, text, imageSource.ToBitmapImage())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hyperlinkObjectForRaisedEvent">The hyperlink object for raised event.</param>
        public ToastPopUp(string title, string text, string hyperlinkText, ImageSource imageSource, object hyperlinkObjectForRaisedEvent = null)
            : this(title)
        {
            this.TextBoxShortDescription.Text = text;
            this.HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
            this.SetHyperLinkButton(hyperlinkText);
            this.imageLeft.Source = imageSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="notificationType">Type of the notification.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">notificationType</exception>
        private ToastPopUp(string title, NotificationType notificationType)
            : this(title)
        {
            switch (notificationType)
            {
                case NotificationType.Error:
                    this.imageLeft.Source = Properties.Resources.Error.ToBitmapImage();
                    break;

                case NotificationType.Information:
                    this.imageLeft.Source = Properties.Resources.Information.ToBitmapImage();
                    break;

                case NotificationType.Warning:
                    this.imageLeft.Source = Properties.Resources.Warning.ToBitmapImage();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("notificationType");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        private ToastPopUp(string title)
            : base()
        {
            this.InitializeComponent();
            System.Windows.Application.Current.MainWindow.Closing += this.MainWindowClosing;

            this.TextBoxTitle.Text = title;
            this.title = title;
        }
        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the hyperlink object for raised event.  This object will be passed back when
        /// the control raises the HyperlinkClicked event.
        /// </summary>
        /// <value>
        /// The hyperlink object for raised event.
        /// </value>
        public object HyperlinkObjectForRaisedEvent { get; set; }

        #endregion Public Properties

        #region Events

        /// <summary>
        /// Occurs when [closed by user].
        /// </summary>
        public event EventHandler<System.EventArgs> ClosedByUser;

        /// <summary>
        /// Occurs when [hyperlink clicked].
        /// </summary>
        public event EventHandler<HyperLinkEventArgs> HyperlinkClicked;

        #endregion Events

        #region Public Methods

        /// <summary>
        /// Opens a window and returns without waiting for the newly opened window to close.
        /// </summary>
        public new void Show()
        {
            this.Topmost = true;
            base.Show();

            this.Owner = System.Windows.Application.Current.MainWindow;
            this.Closed += this.NotificationWindowClosed;
            this.AdjustWindows();
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <exception cref="System.NotImplementedException">ShowDialog() is not supported.  Use Show() instead.</exception>
        public new void ShowDialog()
        {
            throw new NotImplementedException("ShowDialog() is not supported.  Use Show() instead.");
        }

        #endregion
        
        #region Event Handlers

        /// <summary>
        /// Raises the <see cref="E:ClosedByUser" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnClosedByUser(EventArgs e)
        {
            EventHandler<System.EventArgs> onClosedByUser = ClosedByUser;
            if (onClosedByUser != null)
            {
                onClosedByUser(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:HyperlinkClicked" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnHyperlinkClicked(HyperLinkEventArgs e)
        {
            EventHandler<HyperLinkEventArgs> onHyperlinkClicked = HyperlinkClicked;
            if (onHyperlinkClicked != null)
            {
                onHyperlinkClicked(this, e);
            }
        }

        /// <summary>
        /// Buttons the view click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonViewClick(object sender, RoutedEventArgs e)
        {
            this.OnHyperlinkClicked(new HyperLinkEventArgs() { HyperlinkObjectForRaisedEvent = this.HyperlinkObjectForRaisedEvent });
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
        /// Images the mouse up.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void ImageMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.OnClosedByUser(new EventArgs());
            this.Close();
        }

        /// <summary>
        /// Mains the window closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowType = window.GetType().Name;
                if (windowType.Equals(this.name))
                {
                    window.Close();
                }
            }
        }

        /// <summary>
        /// Notifications the window closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NotificationWindowClosed(object sender, EventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowName = window.GetType().Name;

                if (windowName.Equals(this.name) && window != this)
                {
                    // Adjust any windows that were above this one to drop down
                    if (window.Top < this.Top &&  window.Left == this.Left)
                    {
                        window.Top = window.Top + this.ActualHeight;

                        if (!WindowsExistToTheRight(this.Left))
                        {
                            window.Left = window.Left + this.ActualWidth;
                        }
                    }
                }
            }

            this.AdjustWindows();
        }

        #endregion Event Handlers

        #region Private Methods

        /// <summary>
        /// Dow windows exist to the right.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <returns></returns>
        private bool WindowsExistToTheRight(double left)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowName = window.GetType().Name;

                if (windowName.Equals(this.name) &&
                    window != this &&
                    left == Screen.PrimaryScreen.WorkingArea.Width - this.Width)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adjusts the windows.
        /// </summary>
        private void AdjustWindows()
        {
            lock (lockObject)
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

                this.Left = SystemParameters.WorkArea.Width - this.ActualWidth;
                double top = SystemParameters.WorkArea.Height - this.ActualHeight;

                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    string windowName = window.GetType().Name;

                    if (windowName.Equals(this.name) && window != this)
                    {
                        window.Topmost = true;

                        if (this.Left == window.Left)
                        {
                            top = top - window.ActualHeight;
                        }

                        if (top < 0)
                        {
                            this.Left = this.Left - this.ActualWidth;
                            top = workingArea.Bottom - this.ActualHeight;
                        }
                    }
                }

                this.Top = top;
            }
        }

        /// <summary>
        /// Sets the hyperlink button.
        /// </summary>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        private void SetHyperLinkButton(string hyperlinkText)
        {
            if (!string.IsNullOrWhiteSpace(hyperlinkText))
            {
                this.buttonView.Content = hyperlinkText;
                this.buttonView.Visibility = Visibility.Visible;
            }
        }

        #endregion Private Methods
    }
}