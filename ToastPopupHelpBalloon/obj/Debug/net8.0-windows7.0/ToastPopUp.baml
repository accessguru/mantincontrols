   M S B A M L   `   `   `  ����$   Mantin.Controls.Wpf.Notification1    +Mantin.Controls.Wpf.Notification.ToastPopUp   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   Gtelerik1http://schemas.telerik.com/2008/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NotificationWindow��5   	   $	��300��6$    � SizeToContent$ Height=�60    � ShowInTaskbar$ False��6G    � ShowActivated$ False��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��6   
������ .��5
      �  J� RenderTransformOrigin$	 0,1&�6    � 	Resources 5         GradientBackground �� EndPoint	 �� 
StartPoint
 � Color � Offset  
LinkButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  NotificationLinkButton �� BasedOn��%�  &	        &	 �     &	 ]    7  �� 5      $ 	0.504,1.5&�5   "   $	 
0.504,0.03&�5   "   .��5      � $
 	#FFFDD5A7��6   $ 0Q�6%   � 5      $
 	#FFFCE79F��6   $ 0.567Q�6%   5      �� 5      " ��6'   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      �� �� 5      5      5      5      �� 5       � ��
 ��  �6/   �� 5       �@�Cursor$
 Hand��6+    5      P� 5        �@J�IsMouseOver$
 True��65   . �5!      ��  � �� 5"      �� 5#   "   .R�5$   &   �� $��	Underline{�60   #��z��6L   5%   #   5'      5(      5*      �� 5,      " ��63   8   .�5-      ��  � ��$ 13(�6-   5.      5/      .+�50   
   �� -   5         ��Name$ borderBackground��52      $��2q�50      #��[  51      
������� �� CornerRadius$ 7��53   (   ._�54      �  � ColumnDefinitions 55      �� 56      $��60 �6'   �� 57      $��* �6'   �� 58      $��30 �6'    � RowDefinitions 5;      �� 5<      $
��Auto �6$   �� 5=      $
��Auto �6$   �� 5>      $
��Auto �6$   .+�5A      �� -   5         ��Name$ 	imageLeft��5G      $��0��5A      $��3��5B      $��Resources/information.png��5C      $��42��5D      $��42��5E      $��0,10,0,0q�5F      $	��Top=�5H      $��Center=�5I      �� 5K      -   5        $��2��5K      $��2��5L      $��Resources/delete24.png��5M      $��20��5N      $��20��5O      $��0,6,0,0q�5P      $	��Top=�5Q       � ToolTip$ Close��5R      $��Center=�5S       � Cursor$
 Hand��5T      6&   �� 5V      -   5         ��Name$ TextBoxTitle��5X      $��1��5V      $��0��5W      $��0,5,0,5q�5Y      $��Center=�5Z      $
��Wrap=�5[      $
��Left=�5\      $
��Bold"�5]      $��14(�6.   $��A Request has been Added��5^      �� 5`      -   5        $ TextBoxShortDescription��5a      $��1��5`      $��0,3,5,0q�5b      $��2��5c      $��1��5d      $
��Wrap=�5e      $��13(�5f      $��A Request has been Added��5g      �� 5i      -   5         ��Name$ 
buttonView��5p      $��0��5i      $��3��5j      $��2��5k      $��0,5,0,10q�5l      $��Center=�5m      $��Center=�5n      $��Click Here to View��5o      $y�	Collapsed=�5q      #��[ 5r      5s      5t      5u       � Triggers 5x   
   :� 5y       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5z      �� -   5         ��Name$ StoryboardLoad��5z   "   .��5{      �� .��5|      W�   �� TargetProperty$  (UIElement.Opacity)�6*   ! W� From! 0.06Z   	" W� To" 1.06e   # g� Duration$# 0:0:2D�6n   W� 5}      -   5        $  (UIElement.Opacity)�5}   *   ! 1.06Z   " 0.06e   $# 0:0:6D�6n   $ g� 	BeginTime	$ 0:0:56   6�   5~      5      5�      :� 5�      $ Mouse.MouseEnter��6   [�5�      �� 5�      % �� BeginStoryboardName$% StoryboardLoad��6'   �� 5�      $% StoryboardFade��6'   5�      :� 5�      $ Mouse.MouseLeave��6   .[�5�      �� -	   5        $ StoryboardFade��5�   "   .��5�      �� .��5�      W� -
   5        $  (UIElement.Opacity)�5�   *   ! 1.06Z   " 0.06e   $# 0:0:8D�6n   	$ 0:0:26   6�   5�      5�      5�      z�5�   
   �� 5�      & �� ScaleY$& 1Q�6   5�      5�      