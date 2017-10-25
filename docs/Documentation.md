**Use the included "Demo Application" for details on features and code example.  The Notification controls includes the following:**

* **Help Balloon**
	* MVVM Support.
	* Has two types, "Help" and "Information".  Each has its own icon and color scheme.
	* Recognizes multiple screen boundaries and will react accordingly.
	* Properties:
		* Title - Optional bold, underlined title of the balloon.
		* Caption
		* BalloonType (Help/Information/Warning)
		* MaxHeight - Will auto display vertical scrollbars if content exceeds height.
		* MaxWidth - Sets the maximum width of the control.  This can be helpful if "AutoWidth" stretches the control.
		* AutoWidth - The default width is 250. When this property is set, the text will not wrap.
	* Fades in when the mouse is over the Help image.
	* Opacity remains at 1 while mouse over.
	* When mouse leaves the window, the window will fade and close when opacity reaches 0.
	* The height auto sizes to the content.
	* The Help Balloon will present itself on the right side by default and will shift to the left if extends past the screen.
	* Can "attach" a Balloon to any control.
	* Optionally show "Close" button.
	* Code Example:
		* Add this attribute to your Window
			* {{ xmlns:Notification="clr-namespace:Mantin.Controls.Wpf.Notification;assembly=Mantin.Controls.Wpf.Notification"}}
		* XAML Tag
			* {{ <Notification:HelpBalloon Caption="{Binding HelpText}" BalloonType="{Binding BalloonType}" MaxHeight="{Binding MaxHeight}"/> }}

* **Toast Popup**
	* Loads in the bottom right of the screen.
	* Uses animation to fade in and fade out.
	* Opacity remains at 1 while mouse over
	* The height auto sizes to the content.
	* Toast will stack on top of each other and will stack left if they reach the top of the screen.
	* As the toast close, they will fall to the bottom of the screen.
	* Has a close button (raises event).
	* Will fade out after a couple of seconds.
	* If the user mouses over the window, the opacity will return to 1.
	* Windows closes when opacity reaches 0.
	* Constructors accept:
		* Title - Title of your pop up.
		* Text - Content of the message to the user.  Also includes the ability to pass in a List<Inline> for rich text.
		* Hyperlink - (Optional) Text to display as a hyperlink (raises event when clicked.
		* Ability to override the image.
		* Notification Types:
			* Information
			* Warning
			* Error
	* Other Properties:
		* FontColor
		* BorderBrush
		* Background
		* MaxToast
	* Code Example:
		* {{
            // This example shows how to register the available events
            var toast = new ToastPopUp(
                "My Title",
                "This is the main content.",
                "Click this Hyperlink",
                NotificationType.Information);

            // This is what will be passed back through the HyperlinkClicked event.
            toast.HyperlinkObjectForRaisedEvent = new object(); 
            toast.HyperlinkClicked += this.ToastHyperlinkClicked;
            toast.ClosedByUser += this.ToastClosedByUser;
            toast.Show();

            // Passing rich text as inlines and overrides the image.
            var inlines = new List<Inline>();
            inlines.Add(new Run() { Text = "This is the first line of my main content." });
            inlines.Add(new Run() { Text = Environment.NewLine });
            inlines.Add(new Run("This text will be italic.") { FontStyle = FontStyles.Italic });

            new ToastPopUp(title, inlines, HyperLinkText, Properties.Resources.data_disk.ToBitmapImage());

            // If you don't need any events fired, you can do this.
            new ToastPopUp("My Title", "This is the main content.", NotificationType.Information)
            {
                Background = new LinearGradientBrush(Color.FromArgb(255, 4, 253, 82), Color.FromArgb(255, 10, 13, 248), 90),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                FontColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))
            }.Show();
}}