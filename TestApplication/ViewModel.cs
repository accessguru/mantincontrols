using Mantin.Controls.Wpf.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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
        private string balloonTitle;
        private double maxWidth;
        private Color startColor;
        private Color endColor;
        private Color borderColor;
        private Color fontColor;
        private byte maxToast;
        private Status status;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            SelectedNotificationType = NotificationTypeList.First();
            SelectedBalloonType = BalloonTypeList.First();
            PopToastCommand = new RelayCommand(PopToastExecute);
            StartColor = Color.FromRgb(253, 213, 167);
            EndColor = Color.FromRgb(252, 231, 159);
            BorderColor = Color.FromRgb(169, 169, 169);
            FontColor = Color.FromRgb(0, 0, 0);
        }

        #endregion Constructor

        #region Public Properties

        public string EnumFile =>
            @"public enum Status
            {
                [StringValue(""-- Select --"")]
                None = 0,

                Active = 1,

                Inactive = 2,

                [StringValue(""Pending Authorization"")]
                PendingAuthorization = 3
            }";

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        ///  </value>
        public Status Status
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(() => Status);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>
        /// The color of the font.
        /// </value>
        public Color FontColor
        {
            get => fontColor;

            set
            {
                if (fontColor != value)
                {
                    fontColor = value;
                    OnPropertyChanged(() => FontColor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>
        /// The color of the border.
        /// </value>
        public Color BorderColor
        {
            get => borderColor;

            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    OnPropertyChanged(() => BorderColor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the end color.
        /// </summary>
        /// <value>
        /// The end color.
        /// </value>
        public Color EndColor
        {
            get => endColor;
            set
            {
                if (endColor != value)
                {
                    endColor = value;
                    OnPropertyChanged(() => EndColor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the start color.
        /// </summary>
        /// <value>
        /// The start color.
        /// </value>
        public Color StartColor
        {
            get => startColor;

            set
            {
                if (startColor != value)
                {
                    startColor = value;
                    OnPropertyChanged(() => StartColor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum width.
        /// </summary>
        /// <value>
        /// The maximum width.
        /// </value>
        public double MaxWidth
        {
            get => maxWidth;

            set
            {
                if (maxWidth != value)
                {
                    maxWidth = value;
                    OnPropertyChanged(() => MaxWidth);
                }
            }
        }

        /// <summary>
        /// Gets or sets the balloon title.
        /// </summary>
        /// <value>
        /// The balloon title.
        /// </value>
        public string BalloonTitle
        {
            get => balloonTitle;

            set
            {
                if (balloonTitle != value)
                {
                    balloonTitle = value;
                    OnPropertyChanged(() => BalloonTitle);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show balloon close button].
        /// </summary>
        /// <value>
        /// <c>true</c> if [show balloon close button]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowBalloonCloseButton
        {
            get => showBalloonCloseButton;

            set
            {
                if (showBalloonCloseButton != value)
                {
                    showBalloonCloseButton = value;
                    OnPropertyChanged(() => ShowBalloonCloseButton);
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
            get => autoWidth;

            set
            {
                if (autoWidth != value)
                {
                    autoWidth = value;
                    OnPropertyChanged(() => AutoWidth);
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
            get => maxHeight;

            set
            {
                if (maxHeight != value)
                {
                    maxHeight = value;
                    OnPropertyChanged(() => MaxHeight);
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
            get => balloonType;

            set
            {
                if (balloonType != value)
                {
                    balloonType = value;
                    OnPropertyChanged(() => BalloonType);
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
            get => helpText;

            set
            {
                if (helpText != value)
                {
                    helpText = value;
                    OnPropertyChanged(() => HelpText);
                }
            }
        }

        /// <summary>
        /// Gets or sets the hyperlink text.
        /// </summary>
        /// <value>
        /// The hyperlink text.
        /// </value>
        public string HyperlinkText
        {
            get => hyperlinkText;

            set
            {
                if (hyperlinkText != value)
                {
                    hyperlinkText = value;
                    OnPropertyChanged(() => HyperlinkText);
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
            get => selectedNotificationType;

            set
            {
                if (selectedNotificationType != value)
                {
                    selectedNotificationType = value;
                    OnPropertyChanged(() => SelectedNotificationType);
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
            get => selectedNotificationType;

            set
            {
                if (selectedBalloonType != value)
                {
                    selectedBalloonType = value;
                    OnPropertyChanged(() => SelectedBalloonType);

                    BalloonType = (BalloonType)Enum.Parse(typeof(BalloonType), value.Value.ToString());
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
            get => text;

            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged(() => Text);
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
            get => title;

            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(() => Title);
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum toast.
        /// </summary>
        /// <value>
        /// The maximum toast.
        /// </value>
        public byte MaxToast
        {
            get => maxToast;
            set
            {
                if (maxToast != value)
                {
                    maxToast = value;
                    OnPropertyChanged(() => MaxToast);
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
        public static List<EnumMember> NotificationTypeList => EnumMember.ConvertToList<NotificationType>();

        /// <summary>
        /// Gets the balloon type list.
        /// </summary>
        /// <value>
        /// The balloon type list.
        /// </value>
        public static List<EnumMember> BalloonTypeList => EnumMember.ConvertToList<BalloonType>();

        /// <summary>
        /// Pops the toast execute.
        /// </summary>
        public void PopToastExecute(object param)
        {
            var background = new LinearGradientBrush(StartColor, EndColor, 90);
            var brush = new SolidColorBrush(BorderColor);
            var font = new SolidColorBrush(fontColor);

            var notificationType = (NotificationType)Enum.Parse(typeof(NotificationType), SelectedNotificationType.Value.ToString());
            ToastPopUp toast;

            switch (param.ToString())
            {
                case "1":
                    toast = new ToastPopUp(Title, Text, HyperlinkText, notificationType)
                    {
                        Background = background,
                        BorderBrush = brush,
                        FontColor = font,
                        MaxToast = MaxToast
                    };

                    break;

                case "2":
                    toast = new ToastPopUp(Title, Text, HyperlinkText, Properties.Resources.disk_blue)
                    {
                        Background = background,
                        BorderBrush = brush,
                        FontColor = font,
                        MaxToast = MaxToast
                    };

                    break;

                case "3":
                    var inlines = new List<Inline>
                    {
                        new Run { Text = Text },
                        new Run { Text = Environment.NewLine },
                        new Run("This text will be italic.") { FontStyle = FontStyles.Italic }
                    };

                    toast = new ToastPopUp(Title, inlines, HyperlinkText, notificationType)
                    {
                        Background = background,
                        BorderBrush = brush,
                        FontColor = font,
                        MaxToast = MaxToast
                    };

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(param));
            }

            toast.HyperlinkClicked += ToastHyperlinkClicked;
            toast.ClosedByUser += ToastClosedByUser;
            toast.Show();
        }

        #endregion Public Methods

        #region Event Handlers

        /// <summary>
        /// Toasts the hyperlink clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void ToastHyperlinkClicked(object sender, EventArgs e) => MessageBox.Show("Hyper link clicked.");

        /// <summary>
        /// Toasts the closed by user.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void ToastClosedByUser(object sender, EventArgs e) => MessageBox.Show("User closed the toast.");

        #endregion Event Handlers
    }
}