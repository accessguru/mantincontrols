   M S B A M L   `   `   `  ����$   Mantin.Controls.Wpf.Notification1    +Mantin.Controls.Wpf.Notification.ToastPopUp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NotificationWindow��5   	   $	��300��6$    � SizeToContent$ Height=�60    � ShowInTaskbar .   � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������ .��5	      �  J� RenderTransformOrigin$	 0,1&�6    � 	Resources 5
         GradientHeaderBackground �� EndPoint �� 
StartPoint	 � Color
 � Offset  
LinkButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  NotificationLinkButton �� BasedOn��%�  &	        &	 �     &	 L    7  �� 5      $ 	0.504,1.5&�6:   $ 
0.504,0.03&�6O   .��5      � $	 	#FFFDD5A7��6   $
 0Q�6%   � 5      $	 	#FFFCE79F��6   $
 0.567Q�6%   5      �� 5      " ��6'   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      �� �� 5      5      5      5      �� 5       � ��
 ��  �6/   �� 5       �@�Cursor$
 Hand��6+    5      P� 5       �@J�IsMouseOver . . �5      ��  � �� 5      �� 5    "   .R�5!   &   �� $��	Underline{�60   #��z��6L   5"   #   5$      5%      5'      �� 5)      " ��63   8   .�5*      ��  � ��$ 13(�6-   5+      5,      .+�5-   
   �� $��2q�6   #��[  6%   
������� �� CornerRadius$ 7��6s   ._�5.      �  � ColumnDefinitions 5/      �� 50      $��60 �6'   �� 51      $��* �6'   �� 52      $��30 �6'    � RowDefinitions 55      �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   .+�5;      �� -   5         ��Name$ 	imageLeft��5A      $��0��5;      $��3��5<      $��Resources/information.png��5=      $��42��5>      $��42��5?      $��0,10,0,0q�5@      $	��Top=�5B      $��Center=�5C      �� 5E      -   5        $��2��5E      $��2��5F      $��Resources/delete24.png��5G      $��20��5H      $��20��5I      $��0,6,0,0q�5J      $	��Top=�5K       � ToolTip$ Close��5L      $��Center=�5M       � Cursor$
 Hand��5N      6&   �� 5P      -   5         ��Name$ TextBoxTitle��5R      $��1��5P      $��0��5Q      $��0,5,0,5q�5S      $��Center=�5T      $
��Wrap=�5U      $
��Left=�5V      $
��Bold"�5W      $��14(�6.   $��A Request has been Added��5X      �� 5Z      -   5        $ TextBoxShortDescription��5[      $��1��5Z      $��0,3,5,0q�5\      $��2��5]      $��1��5^      $
��Wrap=�5_      $��13(�5`      $��A Request has been Added��5a      �� 5c      -   5         ��Name$ 
buttonView��5j      $��0��5c      $��3��5d      $��2��5e      $��0,5,0,10q�5f      $��Center=�5g      $��Center=�5h      $��Click Here to View��5i      $y�	Collapsed=�5k      #��[ 5l      5m      5n      5o       � Triggers 5r   
   :� 5s       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5t      �� -   5         ��Name$ StoryboardLoad��5t   "   .��5u      �� .��5v      W�  �� TargetProperty$ (UIElement.Opacity)�6*    W� From$	 0.0X�6Z   	  W� To$	  1.0X�6e   ! g� Duration$! 0:0:2D�6n   W� 5w      -   5        $ (UIElement.Opacity)�5w   *   $	 1.0X�6Z   $	  0.0X�6e   $! 0:0:6D�6n   " g� 	BeginTime$" 0:0:5X�6   6�   5x      5y      5z      :� 5|      $ Mouse.MouseEnter��6   [�5}      �� 5~      # �� BeginStoryboardName$# StoryboardLoad��6'   �� 5      $# StoryboardFade��6'   5�      :� 5�      $ Mouse.MouseLeave��6   .[�5�      �� -   5        $ StoryboardFade��5�   "   .��5�      �� .��5�      W� -	   5        $ (UIElement.Opacity)�5�   *   $	 1.0X�6Z   $	  0.0X�6e   $! 0:0:8D�6n   $" 0:0:2X�6   6�   5�      5�      5�      z�5�   
   �� 5�      $ �� ScaleY$$ 1Q�6   5�      5�      