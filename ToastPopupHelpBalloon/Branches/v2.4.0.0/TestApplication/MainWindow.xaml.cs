﻿using System;
using System.Linq;
using System.Windows;
using Mantin.Controls.Wpf.Notification;

namespace DemoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Balloon balloon = null;
        ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this.viewModel;
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
                this.balloon = new Balloon(this.textBoxGeneralUse, "You have moused over this textbox.", this.viewModel.BalloonType, false);
                this.balloon.Show();
            }
        }
    }
}
