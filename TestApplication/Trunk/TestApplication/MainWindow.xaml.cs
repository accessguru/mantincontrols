using Mantin.Controls.Wpf.Notification;
using System.Windows;

namespace DemoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
            if (this.balloon == null || !this.balloon.IsLoaded)
            {
                this.balloon = new Balloon(this.textBoxGeneralUse, "You have moussed over this textbox.", ((ViewModel)this.DataContext).BalloonType, false, ((ViewModel)this.DataContext).ShowBalloonCloseButton);
                this.balloon.Show();
            }
        }
    }
}
