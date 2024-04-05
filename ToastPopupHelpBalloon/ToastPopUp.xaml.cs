using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Mantin.Controls.Wpf.Notification
{
    public partial class ToastPopUp
    {
        #region Members

        private const string name = nameof(ToastPopUp);
        private volatile object lockObject = new();

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
            TextBoxShortDescription.Text = text;
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
            HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
            SetHyperLinkButton(hyperlinkText);
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
            imageLeft.Source = imageSource;
            TextBoxShortDescription.Inlines.AddRange(textInlines);
            SetHyperLinkButton(hyperlinkText);
            HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
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
            HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
            TextBoxShortDescription.Inlines.AddRange(textInlines);
            SetHyperLinkButton(hyperlinkText);
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
            TextBoxShortDescription.Text = text;
            SetHyperLinkButton(hyperlinkText);
            imageLeft.Source = imageSource.ToBitmapImage();
            HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hyperlinkClick">The hyperlink click.</param>
        public ToastPopUp(string title, string text, string hyperlinkText, ImageSource imageSource, Action hyperlinkClick)
            : this(title)
        {
            TextBoxShortDescription.Text = text;
            SetHyperLinkButton(hyperlinkText);
            buttonView.Click += delegate { hyperlinkClick(); };
            imageLeft.Source = imageSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hyperlinkClick">The hyperlink click.</param>
        public ToastPopUp(string title, string text, string hyperlinkText, Bitmap imageSource, Action hyperlinkClick)
            : this(title, text, hyperlinkText, imageSource.ToBitmapImage(), hyperlinkClick)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="hyperlinkText">The hyperlink text.</param>
        /// <param name="hyperlinkClick">The hyperlink click.</param>
        public ToastPopUp(string title, string text, string hyperlinkText, Action hyperlinkClick)
            : this(title)
        {
            TextBoxShortDescription.Text = text;
            SetHyperLinkButton(hyperlinkText);
            buttonView.Click += delegate { hyperlinkClick(); };
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
            TextBoxShortDescription.Text = text;
            imageLeft.Source = imageSource;
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
            TextBoxShortDescription.Text = text;
            HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
            SetHyperLinkButton(hyperlinkText);
            imageLeft.Source = imageSource;
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
                    imageLeft.Source = Properties.Resources.Error.ToBitmapImage();
                    break;

                case NotificationType.Information:
                    imageLeft.Source = Properties.Resources.Information.ToBitmapImage();
                    break;

                case NotificationType.Warning:
                    imageLeft.Source = Properties.Resources.Warning.ToBitmapImage();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(notificationType));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToastPopUp"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        private ToastPopUp(string title)
        {
            InitializeComponent();
            if (System.Windows.Application.Current.MainWindow != null)
            {
                System.Windows.Application.Current.MainWindow.Closing += MainWindowClosing;
            }

            TextBoxTitle.Text = title;
            Title = title;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the maximum toast to pop.  Setting to 0 will not limit the count.
        /// </summary>
        /// <value>
        /// The maximum toast.
        /// </value>
        public byte MaxToast { get; set; }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>
        /// The color of the font.
        /// </value>
        public System.Windows.Media.Brush FontColor
        {
            get => TextBoxTitle.Foreground;

            set
            {
                TextBoxTitle.Foreground = value;
                TextBoxShortDescription.Foreground = value;
            }
        }

        /// <summary>
        /// Gets or sets a brush that describes the border background of a control.
        /// </summary>
        public new System.Windows.Media.Brush BorderBrush
        {
            get => borderBackground.BorderBrush;
            set => borderBackground.BorderBrush = value;
        }

        /// <summary>
        /// Gets or sets a brush that describes the background of a control.
        /// </summary>
        public new System.Windows.Media.Brush Background
        {
            get => borderBackground.Background;
            set => borderBackground.Background = value;
        }

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
        public event EventHandler<EventArgs> ClosedByUser;

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
            int toastCount = System.Windows.Application.Current.Windows.OfType<ToastPopUp>().Count();

            if (MaxToast > 0 && toastCount > MaxToast)
            {
                Close();
                return;
            }

            IInputElement focusedElement = Keyboard.FocusedElement;

            Topmost = true;
            base.Show();

            Owner = System.Windows.Application.Current.MainWindow;
            Closed += NotificationWindowClosed;
            AdjustWindows();

            if (focusedElement != null)
            {
                // Restore keyboard focus to the original element that had focus. That way if someone
                // was typing into a control we don't steal keyboard focus away from that control.
                focusedElement.Focusable = true;
                Keyboard.Focus(focusedElement);
            }
        }

        #endregion Public Methods

        #region Event Handlers

        /// <summary>
        /// Raises the <see cref="E:ClosedByUser" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnClosedByUser(EventArgs e)
        {
            ClosedByUser?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:HyperlinkClicked" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnHyperlinkClicked(HyperLinkEventArgs e)
        {
            HyperlinkClicked?.Invoke(this, e);
        }

        /// <summary>
        /// Buttons the view click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonViewClick(object sender, RoutedEventArgs e)
        {
            OnHyperlinkClicked(new HyperLinkEventArgs { HyperlinkObjectForRaisedEvent = this.HyperlinkObjectForRaisedEvent });
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
        /// Images the mouse up.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void ImageMouseUp(object sender, MouseButtonEventArgs e)
        {
            OnClosedByUser(EventArgs.Empty);
            Close();
        }

        /// <summary>
        /// Mains the window closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private static void MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
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
        /// Notifications the window closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NotificationWindowClosed(object sender, EventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowName = window.GetType().Name;

                if (windowName.Equals(name) && window != this)
                {
                    // Adjust any windows that were above this one to drop down
                    if (window.Top < Top && window.Left == Left)
                    {
                        window.Top += ActualHeight;

                        if (!WindowsExistToTheRight(Left))
                        {
                            window.Left += ActualWidth;
                        }
                    }
                }
            }

            AdjustWindows();
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

                if (windowName.Equals(name) &&
                    !Equals(window, this) &&
                    left == Screen.PrimaryScreen!.WorkingArea.Width - Width)
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
                Rectangle workingArea = Screen.PrimaryScreen!.WorkingArea;

                Left = workingArea.Width - ActualWidth;
                double top = workingArea.Height - ActualHeight;

                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    string windowName = window.GetType().Name;

                    if (windowName.Equals(name) && !Equals(window, this))
                    {
                        window.Topmost = true;

                        if (Left == window.Left)
                        {
                            top -= window.ActualHeight;
                        }

                        if (top < 0)
                        {
                            Left -= ActualWidth;
                            top = workingArea.Bottom - ActualHeight;
                        }
                    }
                }

                Top = top;
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
                buttonView.Content = hyperlinkText;
                buttonView.Visibility = Visibility.Visible;
            }
        }

        #endregion Private Methods
    }
}