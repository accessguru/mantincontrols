   M S B A M L   `   `   `  ����$   Mantin.Controls.Wpf.Notification.    (Mantin.Controls.Wpf.Notification.Balloon   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $��90��5   	   $	��250��6     � WindowStyle$
  None=�6!    � 
ResizeMode$ NoResize=�5   	    � ShowInTaskbar$ False��6    � ShowActivated$ False��5   	    � Topmost$
 True��5   	   $��False��6    � OverridesDefaultStyle$ False��5   	    � SizeToContent$ Height=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � 	Resources 5      	 �� 
StartPoint
 �� EndPoint   HelpGradient �� RelativeTransform �� Angle �� CenterX �� CenterY � Color � Offset  InfoGradient  WarningGradient��%�  &	        &	 �     &	 �    �� 5   
   $		 0,0&�6   $	
 1,0&�6/    5      �� 5      $ 90Q�6"   $	 0.7Q�6-   $	 0.7Q�6;   .��5      � $ 	#FFFDFDFD��6   $ .2Q�6-   � 5      $ 	#FFB6FB88��6   $ .8Q�6-   5      �� 5   
   $		 0,0&�6   $	
 1,0&�6/    5      �� 5      $ 90Q�6"   $	 0.7Q�6-   $	 0.7Q�6;   .��5      � $ 	#FFFDFDFD��6   $ .2Q�6-   � 5      $ 	#FF88CEFB��6   $ .8Q�6-   5      �� 5   
   $		 0,0&�6   $	
 1,0&�6/    5      �� 5      $ 90Q�6"   $	 0.7Q�6-   $	 0.7Q�6;   .��5!      � $ 	#FFFDFDFD��6   $ .2Q�6-   � 5"      $ 	#FFF7FB88��6   $ .8Q�6-   5#      5$      .��5%      �  J� RenderTransformOrigin$	 0,1&�6   .+�5&   
   ��  �� Orientation$ Vertical=�6   .+�5'      �  � ColumnDefinitions 5(      �� 5)      $
��Auto �6'   �� 5*      $��* �6'    5,       �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity��%�  'F�       �� 5-      " F�6   .�5.      ��  � �� �#fdfdfd61   �� 5/       �@��Stretch$
 Fill=�64   �� 50       � ��$ 22��62   �� 51       � ��$ 31��63   �� 52       �@K�ZIndex$ 99��69   �� 53       � ��$	 Top=�6>   �� 54       �@J�Effect 55        56   "   $ 	#FF757575��63   $ .7Q�6E   58      59      5:      .+�5;      F� -   5         F�Name$ PathPointLeft��5?      $��0��5;      $
��Left=�5<      $��15,3,0,0q�5=      '����W`��~Q�@�qO���  �	 �`�
  �E	5?      F� 5@      -   5        $ PathPointRight��5D      $��1��5@      $��Right=�5A      $��0,3,15,0q�5B      1�����"��~Q�@�qObX9d�@�њ��^
@�`�
  �E	5E      5F      �� 5H      -   5         ��Name$ borderBalloon��5K      $��5,-3,5,5q�5H       �� CornerRadius$ 7��5I       K� ZIndex$	 100��6&   #��[ 5J      $	��Top=�5L       J� Effect 5M        5N      $ 	#FF757575��6'   $ .7Q�69   ._�5P      �  5Q      �� 5R      $
��Auto �6+   �� 5S      $��* �6+   �� 5T      $
��Auto �6+   .+�5W      �� -   5         ��Name$ 	imageType��5\      $��0��5W      $��35��5X      $��5q�5Y      $	��Top=�5Z      $��35��5[      $��Resources/information.png��5]      �� 5_      -   5        $ 
imageClose��5`      $��Resources/delete24.png��5_       � ToolTip$ Close��5a      $	��Top=�5b      $��2��5c      $��16��5d      $��16��5e      $��0,5,5,5q�5f      $��1��5g        � Cursor$
  Hand��5h      5i      �� 5k      $ Vertical=�6!   $��1��68   $��0,5,5,5q�6H   .+�5l      �� -   5        ! ��Name$! textBlockTitle��5o   $   &   System.Windows.Media.TextOptions"   TextFormattingMode$" Display=�5l   $   $
��Bold"�5m   $   $��14(�5n   $   $��This is the Title��5p   $   �� 5q      -   5        # ��Name$# 	lineTitle��5q   D   $ �� Stretch$
$ Fill=�6   
���   �	% �� X2$% 1��6=   6D   �� 5s      -   5        & ��Name$& scrollViewerCaption��5t   '   $
��Auto=�5s   '   .��5u      �� -	   5        $! textBlockCaption��5x   !   $
��Wrap=�5v   !   $" Display=�5w   !   $��This is the caption��5y   !   5z      5{      5|      5}      5~      ' � Triggers' 5�   
   :� 5�      ( :� RoutedEvent$( FrameworkElement.Loaded��6   .[�5�      �� -
   5        ) ��Name$) StoryboardLoad��5�   "   .��5�      �� .��5�      W� * �� TargetProperty$* (UIElement.Opacity)�6*   + W� From+ 0.06Z   	, W� To, 1.06e   - g� Duration$- 0:0:2D�6n   W� 5�      -   5        $* (UIElement.Opacity)�5�   *   + 1.06Z   , 0.06e   $- 0:0:3D�6n   . g� 	BeginTime	. 0:0:36   6�   5�      5�      5�      :� 5�      $( Mouse.MouseEnter��6   [�5�      �� 5�      / �� BeginStoryboardName$/ StoryboardLoad��6'   �� 5�      $/ StoryboardFade��6'   5�      :� 5�      $( Mouse.MouseLeave��6   .[�5�      �� -   5        $) StoryboardFade��5�   "   .��5�      �� .��5�      W� -   5        $* (UIElement.Opacity)�5�   *   + 1.06Z   , 0.06e   $- 0:0:1D�6n   	. 0:0:16   6�   5�      5�      5�      z�5�   
   �� 5�      0 �� ScaleY$0 1Q�6   5�      5�      