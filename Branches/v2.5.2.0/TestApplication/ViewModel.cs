using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Mantin.Controls.Wpf.Notification;
using TestApplication;

namespace DemoApplication
{
    internal class ViewModel : ObservableBase
    {
        #region Members

        private string helpText = "Help Balloon will default to the bottom and right side unless it will move off of the screen, then it will shift to the left side.  Setting the Max Height property will auto enable vertical scrollbars.";
        private string hyperlinkText = "Click Me!";
        private EnumMember selectedNotificationType;
        private EnumMember selectedBalloonType;
        private BalloonType balloonType;
        private string text = "This is unobtrusive text that I want my user to see.";
        private string title = "My Title";
        private double maxHeight;
        private bool autoWidth;
        private bool showBalloonCloseButton = true;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.SelectedNotificationType = this.NotificationTypeList.First();
            this.SelectedBalloonType = this.BalloonTypeList.First();
            this.PopToastCommand = new RelayCommand(param => this.PopToastExecute(param));
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [show balloon close button].
        /// </summary>
        /// <value>
        /// <c>true</c> if [show balloon close button]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowBalloonCloseButton
        {
            get
            {
                return this.showBalloonCloseButton;
            }

            set
            {
                if (this.showBalloonCloseButton != value)
                {
                    this.showBalloonCloseButton = value;
                    this.OnPropertyChanged(() => this.ShowBalloonCloseButton);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic width].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic width]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoWidth
        {
            get
            {
                return this.autoWidth;
            }

            set
            {
                if (this.autoWidth != value)
                {
                    this.autoWidth = value;
                    this.OnPropertyChanged(() => this.AutoWidth);
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum height.
        /// </summary>
        /// <value>
        /// The maximum height.
        /// </value>
        public double MaxHeight
        {
            get
            {
                return this.maxHeight;
            }

            set
            {
                if (this.maxHeight != value)
                {
                    this.maxHeight = value;
                    this.OnPropertyChanged(() => this.MaxHeight);
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the balloon.
        /// </summary>
        /// <value>
        /// The type of the balloon.
        /// </value>
        public BalloonType BalloonType
        {
            get
            {
                return this.balloonType;
            }

            set
            {
                if (this.balloonType != value)
                {
                    this.balloonType = value;
                    this.OnPropertyChanged(() => this.BalloonType);
                }
            }
        }

        /// <summary>
        /// Gets or sets the help text.
        /// </summary>
        /// <value>
        /// The help text.
        /// </value>
        public string HelpText
        {
            get
            {
                return this.helpText;
            }

            set
            {
                if (this.helpText != value)
                {
                    this.helpText = value;
                    this.OnPropertyChanged(() => this.HelpText);
                }
            }
        }

        /// <summary>
        /// Gets or sets the hyper link text.
        /// </summary>
        /// <value>
        /// The hyper link text.
        /// </value>
        public string HyperlinkText
        {
            get
            {
                return this.hyperlinkText;
            }

            set
            {
                if (this.hyperlinkText != value)
                {
                    this.hyperlinkText = value;
                    this.OnPropertyChanged(() => this.HyperlinkText);
                }
            }
        }

        /// <summary>
        /// Gets or sets the pop toast command.
        /// </summary>
        /// <value>
        /// The pop toast command.
        /// </value>
        public ICommand PopToastCommand { get; set; }

        /// <summary>
        /// Gets or sets the type of the selected notification.
        /// </summary>
        /// <value>
        /// The type of the selected notification.
        /// </value>
        public EnumMember SelectedNotificationType
        {
            get
            {
                return this.selectedNotificationType;
            }

            set
            {
                if (this.selectedNotificationType != value)
                {
                    this.selectedNotificationType = value;
                    this.OnPropertyChanged(() => this.SelectedNotificationType);
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the selected balloon.
        /// </summary>
        /// <value>
        /// The type of the selected balloon.
        /// </value>
        public EnumMember SelectedBalloonType
        {
            get
            {
                return this.selectedNotificationType;
            }

            set
            {
                if (this.selectedBalloonType != value)
                {
                    this.selectedBalloonType = value;
                    this.OnPropertyChanged(() => this.SelectedBalloonType);

                    this.BalloonType = (BalloonType)System.Enum.Parse(typeof(BalloonType), value.Value.ToString());
                }
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnPropertyChanged(() => this.Text);
                }
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.OnPropertyChanged(() => this.Title);
                }
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the notification type list.
        /// </summary>
        /// <value>
        /// The notification type list.
        /// </value>
        public List<EnumMember> NotificationTypeList
        {
            get { return EnumMember.ConvertToList<NotificationType>(); }
        }

        /// <summary>
        /// Gets the balloon type list.
        /// </summary>
        /// <value>
        /// The balloon type list.
        /// </value>
        public List<EnumMember> BalloonTypeList
        {
            get { return EnumMember.ConvertToList<BalloonType>(); }
        }

        /// <summary>
        /// Pops the toast execute.
        /// </summary>
        public void PopToastExecute(object param)
        {
            App.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                () =>
                {
                   NotificationType notificationType = (NotificationType)System.Enum.Parse(typeof(NotificationType), this.SelectedNotificationType.Value.ToString());
                   ToastPopUp toast;
                    switch (param.ToString())
                    {
                        case "1":
                            toast = new ToastPopUp(this.Title, this.Text, this.HyperlinkText, notificationType);
                            toast.HyperlinkClicked += this.ToastHyperlinkClicked;
                            toast.ClosedByUser += this.ToastClosedByUser;
                            toast.Show();

                            break;
                        case "2":
                            toast = new ToastPopUp(this.Title, this.Text, this.HyperlinkText, DemoApplication.Properties.Resources.disk_blue);
                            toast.HyperlinkClicked += this.ToastHyperlinkClicked;
                            toast.ClosedByUser += this.ToastClosedByUser;
                            toast.Show();

                            break;
                        case "3":
                            var inlines = new List<Inline>();
                            inlines.Add(new Run() { Text = this.Text });
                            inlines.Add(new Run() { Text = Environment.NewLine });
                            inlines.Add(new Run("This text will be italic.") { FontStyle = FontStyles.Italic });

                            toast = new ToastPopUp(this.Title, inlines,this.HyperlinkText, notificationType);
                            toast.HyperlinkClicked += this.ToastHyperlinkClicked;
                            toast.ClosedByUser += this.ToastClosedByUser;
                            toast.Show();

                            break;
                    }

                }));
        }

        #endregion Public Methods

        #region Event Handlers

        /// <summary>
        /// Toasts the hyper link clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToastHyperlinkClicked(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("Hyper link clicked.");
        }

        /// <summary>
        /// Toasts the closed by user.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToastClosedByUser(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("User closed the toast.");
        }

        #endregion Event Handlers
    }
}