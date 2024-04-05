using Mantin.Controls.Wpf.Notification;

namespace DemoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Balloon balloon;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Texts the box general use mouse enter.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private void TextBoxGeneralUseMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (balloon == null || !balloon.IsLoaded)
            {
                balloon = new Balloon(textBoxGeneralUse, "You have moussed over this textbox.", ((ViewModel)DataContext).BalloonType, false, ((ViewModel)DataContext).ShowBalloonCloseButton);
                balloon.Show();
            }
        }
    }
}