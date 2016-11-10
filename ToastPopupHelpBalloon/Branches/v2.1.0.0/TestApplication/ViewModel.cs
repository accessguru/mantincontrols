using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Mantin.Controls.Wpf.Notification;

namespace TestApplication
{
    internal class ViewModel : ObservableBase
    {
        #region Members

        private string helpText = "Help Balloon will default to the bottom and right side unless it will move off of the screen, then it will shift to the left side.";
        private string hyperlinkText = "Click Me!";
        private EnumMember selectedNotificationType;
        private string text = "This is unobtrusive text that I want my user to see.";
        private string title = "My Title";

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.SelectedNotificationType = this.NotificationTypeList.First();
            this.PopToastCommand = new RelayCommand(param => this.PopToastExecute(param));
        }

        #endregion Constructor

        #region Public Properties

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
        /// Pops the toast execute.
        /// </summary>
        public void PopToastExecute(object param)
        {
            App.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(
                () =>
                {
                   NotificationType notificationType = (NotificationType)System.Enum.Parse(typeof(NotificationType), this.SelectedNotificationType.Value.ToString());

                    switch (param.ToString())
                    {
                        case "1":
                            var toast = new ToastPopUp(this.Title, this.Text, this.HyperlinkText, notificationType);
                            toast.HyperlinkClicked += this.ToastHyperlinkClicked;
                            toast.ClosedByUser += this.ToastClosedByUser;
                            toast.Show();

                            break;

                        case "2":
                            new ToastPopUp(this.Title, this.Text, this.HyperlinkText, Properties.Resources.disk_blue).Show();
                            break;

                        case "3":
                            var inlines = new List<Inline>();
                            inlines.Add(new Run() { Text = this.Text });
                            inlines.Add(new Run() { Text = Environment.NewLine });
                            inlines.Add(new Run("This text will be italic.") { FontStyle = FontStyles.Italic });

                            new ToastPopUp(this.Title, inlines,this.HyperlinkText, notificationType).Show();
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