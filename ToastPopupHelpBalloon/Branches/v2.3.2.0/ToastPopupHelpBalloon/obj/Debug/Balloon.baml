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
   ��  �� Orientation$ Vertical=�6   .+�5      �  � ColumnDefinitions 5      �� 5       $
��Auto �6'   �� 5!      $��* �6'    5#       �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity��%�  'F�       �� 5$      " F�6   .�5%      ��  � �� �#fdfdfd61   �� 5&       �@��Stretch$
 Fill=�64   �� 5'       � ��$ 22��62   �� 5(       � ��$ 31��63   �� 5)       �@K�ZIndex$ 99��69   �� 5*       � ��$	 Top=�6>   �� 5+       �@J�Effect 5,        5-   "   $ 	#FF757575��63   $ .7Q�6E   5/      50      51      .+�52      F� -   5         F�Name$ PathPointLeft��56      $��0��52      $
��Left=�53      $��15,3,0,0q�54      '����W`��~Q�@�qO���  �	 �`�
  �E	56      F� 57      -   5        $ PathPointRight��5;      $��1��57      $��Right=�58      $��0,3,15,0q�59      1�����"��~Q�@�qObX9d�@�њ��^
@�`�
  �E	5<      5=      �� 5?      -   5         ��Name$ borderBalloon��5B      $��5,-3,5,5q�5?       �� CornerRadius$ 7��5@       K� ZIndex$	 100��6&   #��[ 5A      $	��Top=�5C       J� Effect 5D        5E      $ 	#FF757575��6'   $ .7Q�69   ._�5G      �  5H      �� 5I      $
��Auto �6+   �� 5J      $��* �6+   .+�5M      �� -   5         ��Name$ 	imageType��5R      $��0��5M      $��35��5N      $��5q�5O      $	��Top=�5P      $��35��5Q      $��Resources/information.png��5S      �� 5U      -   5         ��Name$ scrollViewerCaption��5X   #   $��1��5U   #   $��
0,10,10,10q�5V   #   $
��Auto=�5W   #   .��5Y      �� -   5         ��Name$ textBlockCaption��5\      $
��Wrap=�5Z      &   System.Windows.Media.TextOptions    TextFormattingMode$  Display=�5[      $��This is the caption��5]      5^      5_      5`      5a      ! � Triggers! 5d   
   :� 5e      " :� RoutedEvent$" FrameworkElement.Loaded��6   .[�5f      �� -   5        # ��Name$# StoryboardLoad��5f   "   .��5g      �� .��5h      W� $ �� TargetProperty$$ (UIElement.Opacity)�6*   % W� From$	% 0.0X�6Z   	& W� To$	& 1.0X�6e   ' g� Duration$' 0:0:2D�6n   W� 5i      -   5        $$ (UIElement.Opacity)�5i   *   $	% 1.0X�6Z   $	& 0.0X�6e   $' 0:0:3D�6n   ( g� 	BeginTime$( 0:0:3X�6   6�   5j      5k      5l      :� 5n      $" Mouse.MouseEnter��6   [�5o      �� 5p      ) �� BeginStoryboardName$) StoryboardLoad��6'   �� 5q      $) StoryboardFade��6'   5s      :� 5u      $" Mouse.MouseLeave��6   .[�5v      �� -	   5        $# StoryboardFade��5v   "   .��5w      �� .��5x      W� -
   5        $$ (UIElement.Opacity)�5x   *   $	% 1.0X�6Z   $	& 0.0X�6e   $' 0:0:1D�6n   $( 0:0:1X�6   6�   5y      5z      5{      z�5~   
   �� 5      * �� ScaleY$* 1Q�6   5�      5�      