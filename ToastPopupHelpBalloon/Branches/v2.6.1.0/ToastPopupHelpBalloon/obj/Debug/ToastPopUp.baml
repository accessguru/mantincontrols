   M S B A M L   `   `   `  ����$   Mantin.Controls.Wpf.Notification1    +Mantin.Controls.Wpf.Notification.ToastPopUp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NotificationWindow��5   	   $	��300��6$    � SizeToContent$ Height=�60    � ShowInTaskbar .   � ShowActivated .   � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������ .��5
      �  J� RenderTransformOrigin$	 0,1&�6    � 	Resources 5         GradientHeaderBackground �� EndPoint	 �� 
StartPoint
 � Color � Offset  
LinkButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  NotificationLinkButton �� BasedOn��%�  &	        &	 �     &	 L    7  �� 5      $ 	0.504,1.5&�6:   $	 
0.504,0.03&�6O   .��5      � $
 	#FFFDD5A7��6   $ 0Q�6%   � 5      $
 	#FFFCE79F��6   $ 0.567Q�6%   5      �� 5      " ��6'   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      �� �� 5      5      5      5      �� 5       � ��
 ��  �6/   �� 5       �@�Cursor$
 Hand��6+    5      P� 5       �@J�IsMouseOver . . �5      ��  � �� 5       �� 5!   "   .R�5"   &   �� $��	Underline{�60   #��z��6L   5#   #   5%      5&      5(      �� 5*      " ��63   8   .�5+      ��  � ��$ 13(�6-   5,      5-      .+�5.   
   �� $��2q�6   #��[  6%   
������� �� CornerRadius$ 7��6s   ._�5/      �  � ColumnDefinitions 50      �� 51      $��60 �6'   �� 52      $��* �6'   �� 53      $��30 �6'    � RowDefinitions 56      �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   �� 59      $
��Auto �6$   .+�5<      �� -   5         ��Name$ 	imageLeft��5B      $��0��5<      $��3��5=      $��Resources/information.png��5>      $��42��5?      $��42��5@      $��0,10,0,0q�5A      $	��Top=�5C      $��Center=�5D      �� 5F      -   5        $��2��5F      $��2��5G      $��Resources/delete24.png��5H      $��20��5I      $��20��5J      $��0,6,0,0q�5K      $	��Top=�5L       � ToolTip$ Close��5M      $��Center=�5N       � Cursor$
 Hand��5O      6&   �� 5Q      -   5         ��Name$ TextBoxTitle��5S      $��1��5Q      $��0��5R      $��0,5,0,5q�5T      $��Center=�5U      $
��Wrap=�5V      $
��Left=�5W      $
��Bold"�5X      $��14(�6.   $��A Request has been Added��5Y      �� 5[      -   5        $ TextBoxShortDescription��5\      $��1��5[      $��0,3,5,0q�5]      $��2��5^      $��1��5_      $
��Wrap=�5`      $��13(�5a      $��A Request has been Added��5b      �� 5d      -   5         ��Name$ 
buttonView��5k      $��0��5d      $��3��5e      $��2��5f      $��0,5,0,10q�5g      $��Center=�5h      $��Center=�5i      $��Click Here to View��5j      $y�	Collapsed=�5l      #��[ 5m      5n      5o      5p       � Triggers 5s   
   :� 5t       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5u      �� -   5         ��Name$ StoryboardLoad��5u   "   .��5v      �� .��5w      W�  �� TargetProperty$ (UIElement.Opacity)�6*     W� From$	  0.0X�6Z   	! W� To$	! 1.0X�6e   " g� Duration$" 0:0:2D�6n   W� 5x      -   5        $ (UIElement.Opacity)�5x   *   $	  1.0X�6Z   $	! 0.0X�6e   $" 0:0:6D�6n   # g� 	BeginTime$# 0:0:5X�6   6�   5y      5z      5{      :� 5}      $ Mouse.MouseEnter��6   [�5~      �� 5      $ �� BeginStoryboardName$$ StoryboardLoad��6'   �� 5�      $$ StoryboardFade��6'   5�      :� 5�      $ Mouse.MouseLeave��6   .[�5�      �� -   5        $ StoryboardFade��5�   "   .��5�      �� .��5�      W� -	   5        $ (UIElement.Opacity)�5�   *   $	  1.0X�6Z   $	! 0.0X�6e   $" 0:0:8D�6n   $# 0:0:2X�6   6�   5�      5�      5�      z�5�   
   �� 5�      % �� ScaleY$% 1Q�6   5�      5�      