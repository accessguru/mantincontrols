   M S B A M L   `   `   `  ����$   Mantin.Controls.Wpf.Notification.    (Mantin.Controls.Wpf.Notification.Balloon   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $��90��5   	   $	��250��6     � WindowStyle$
  None=�6!    � 
ResizeMode$ NoResize=�5   	    � ShowInTaskbar .   � Topmost . ��.   � OverridesDefaultStyle .   � SizeToContent$ Height=�5   	    � AllowsTransparency . 
������  � 	Resources 5       �� 
StartPoint	 �� EndPoint   HelpGradient
 �� RelativeTransform �� Angle �� CenterX �� CenterY � Color � Offset  InfoGradient��%�  &	        &	 �     �� 5   
   $	 0,0&�6   $		 1,0&�6/   
 5      �� 5      $ 90Q�6"   $	 0.7Q�6-   $	 0.7Q�6;   .��5      � $ 	#FFFDFDFD��6   $ .2Q�6-   � 5      $ 	#FFB6FB88��6   $ .8Q�6-   5      �� 5   
   $	 0,0&�6   $		 1,0&�6/   
 5      �� 5      $ 90Q�6"   $	 0.7Q�6-   $	 0.7Q�6;   .��5      � $ 	#FFFDFDFD��6   $ .2Q�6-   � 5      $ 	#FF88CEFB��6   $ .8Q�6-   5      5      .��5      �  J� RenderTransformOrigin$	 0,1&�6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6    5       �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity��%�  'F�       �� 5       " F�6   .�5!      ��  � �� �#fdfdfd61   �� 5"       �@��Stretch$
 Fill=�64   �� 5#       � ��$ 22��62   �� 5$       � ��$ 31��63   �� 5%       �@K�ZIndex$ 99��69   �� 5&       � ��$	 Top=�6>   �� 5'       �@J�Effect 5(        5)   "   $ 	#FF757575��63   $ .7Q�6E   5+      5,      5-      .+�5.      F� -   5         F�Name$ PathPointLeft��52      $
��Left=�5/      $��15,3,0,0q�50      '����W`��~Q�@�qO���  �	 �`�
  �E	52      F� 53      -   5        $ PathPointRight��57      $��Right=�54      $��	175,3,0,0q�55      1�����"��~Q�@�qObX9d�@�њ��^
@�`�
  �E	58      59      �� 5;      -   5         ��Name$ borderBalloon��5>      $��5,-3,5,5q�5;       �� CornerRadius$ 7��5<       K� ZIndex$	 100��6&   #��[ 5=      $	��Top=�5?       J� Effect 5@        5A      $ 	#FF757575��6'   $ .7Q�69   ._�5C      �  � ColumnDefinitions 5D      �� 5E      $
��Auto �6+   �� 5F      $��* �6+   .+�5I      �� -   5         ��Name$ 	imageType��5N      $��0��5I      $��35��5J      $��5q�5K      $	��Top=�5L      $��35��5M      $��Resources/information.png��5O      �� 5Q      -   5         ��Name$ scrollViewerCaption��5T   #   $��1��5Q   #   $��
0,10,10,10q�5R   #   $
��Auto=�5S   #   .��5U      �� -   5         ��Name$ textBlockCaption��5X      $
��Wrap=�5V      &   System.Windows.Media.TextOptions    TextFormattingMode$  Display=�5W      $��This is the caption��5Y      5Z      5[      5\      5]      ! � Triggers! 5`   
   :� 5a      " :� RoutedEvent$" FrameworkElement.Loaded��6   .[�5b      �� -   5        # ��Name$# StoryboardLoad��5b   "   .��5c      �� .��5d      W� $ �� TargetProperty$$ (UIElement.Opacity)�6*   % W� From$	% 0.0X�6Z   	& W� To$	& 1.0X�6e   ' g� Duration$' 0:0:2D�6n   W� 5e      -   5        $$ (UIElement.Opacity)�5e   *   $	% 1.0X�6Z   $	& 0.0X�6e   $' 0:0:3D�6n   ( g� 	BeginTime$( 0:0:3X�6   6�   5f      5g      5h      :� 5j      $" Mouse.MouseEnter��6   [�5k      �� 5l      ) �� BeginStoryboardName$) StoryboardLoad��6'   �� 5m      $) StoryboardFade��6'   5o      :� 5q      $" Mouse.MouseLeave��6   .[�5r      �� -	   5        $# StoryboardFade��5r   "   .��5s      �� .��5t      W� -
   5        $$ (UIElement.Opacity)�5t   *   $	% 1.0X�6Z   $	& 0.0X�6e   $' 0:0:1D�6n   $( 0:0:1X�6   6�   5u      5v      5w      z�5z   
   �� 5{      * �� ScaleY$* 1Q�6   5}      5~      