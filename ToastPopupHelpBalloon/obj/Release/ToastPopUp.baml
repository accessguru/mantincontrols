   M S B A M L   `   `   `  ���� $   Mantin.Controls.Wpf.Notification1    +Mantin.Controls.Wpf.Notification.ToastPopUp   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  NotificationWindow��$	��300�� � SizeToContent$ Height=� � ShowInTaskbar .   � ShowActivated .   � WindowStyle$
 None=� � AllowsTransparency . 
������ .���  J� RenderTransformOrigin$	 0,1&� � 	Resources    GradientBackground �� EndPoint	 �� 
StartPoint
 � Color � Offset  
LinkButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  NotificationLinkButton �� BasedOn��%y  &	        &	 g     &	 /    7  �� $ 	0.504,1.5&�$	 
0.504,0.03&�.��� $
 	#FFFDD5A7��$ 0Q�� $
 	#FFFCE79F��$ 0.567Q��� " ��.���  � �� �� " ��.R��� �� ��  � ��
 ��  ���  �@�Cursor$
 Hand�� P�  �@J�IsMouseOver . . ���  � �� �� .R��� $��	Underline{�#��z���� " ��8   .���  � ��$ 13(�.+��� -    ��Name$ borderBackground��$��2q�#��[  
������� �� CornerRadius$ 7��._��  � ColumnDefinitions �� $��60 ��� $��* ��� $��30 � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ 	imageLeft��$��0��$��3��$��Resources/information.png��$��42��$��42��$��0,10,0,0q�$	��Top=�$��Center=��� -   $��2��$��2��$��Resources/delete24.png��$��20��$��20��$��0,6,0,0q�$	��Top=� � ToolTip$ Close��$��Center=� � Cursor$
 Hand���� -    ��Name$ TextBoxTitle��$��1��$��0��$��0,5,0,5q�$��Center=�$
��Wrap=�$
��Left=�$
��Bold"�$��14(�$��A Request has been Added���� -   $ TextBoxShortDescription��$��1��$��0,3,5,0q�$��2��$��1��$
��Wrap=�$��13(�$��A Request has been Added���� -    ��Name$ 
buttonView��$��0��$��3��$��2��$��0,5,0,10q�$��Center=�$��Center=�$��Click Here to View��$y�	Collapsed=�#��[  � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� -    ��Name$ StoryboardLoad��.���� .��W�   �� TargetProperty$  (UIElement.Opacity)�! W� From$	! 0.0X�	" W� To$	" 1.0X�# g� Duration$# 0:0:2D�W� -   $  (UIElement.Opacity)�$	! 1.0X�$	" 0.0X�$# 0:0:6D�$ g� 	BeginTime$$ 0:0:5X�:� $ Mouse.MouseEnter��[��� % �� BeginStoryboardName$% StoryboardLoad���� $% StoryboardFade��:� $ Mouse.MouseLeave��.[��� -	   $ StoryboardFade��.���� .��W� -
   $  (UIElement.Opacity)�$	! 1.0X�$	" 0.0X�$# 0:0:8D�$$ 0:0:2X�z��� & �� ScaleY$& 1Q�