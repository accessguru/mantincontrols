   M S B A M L   `   `   `  ���� $   Mantin.Controls.Wpf.Notification.    (Mantin.Controls.Wpf.Notification.Balloon   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     $��90��$	��250��  � WindowStyle$
  None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � Topmost . ��.   � OverridesDefaultStyle .   � SizeToContent$ Height=� � AllowsTransparency . 
������  � 	Resources  �� 
StartPoint	 �� EndPoint   HelpGradient
 �� RelativeTransform �� Angle �� CenterX �� CenterY � Color � Offset  InfoGradient��%  &	        &	 ~     �� $	 0,0&�$		 1,0&�
 �� $ 90Q�$	 0.7Q�$	 0.7Q�.��� $ 	#FFFDFDFD��$ .2Q�� $ 	#FFB6FB88��$ .8Q��� $	 0,0&�$		 1,0&�
 �� $ 90Q�$	 0.7Q�$	 0.7Q�.��� $ 	#FFFDFDFD��$ .2Q�� $ 	#FF88CEFB��$ .8Q�.���  J� RenderTransformOrigin$	 0,1&�.+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�  �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity��%�   'F�       �� " F�.���  � �� �#fdfdfd��  �@��Stretch$
 Fill=���  � ��$ 22����  � ��$ 31����  �@K�ZIndex$ 99����  � ��$	 Top=���  �@J�Effect   $ 	#FF757575��$ .7Q�.+�F� -    F�Name$ PathPointLeft��$
��Left=�$��15,3,0,0q�'����W`��~Q�@�qO���  �	 �`�
  �E	F� -   $ PathPointRight��$��Right=�$��	175,3,0,0q�1�����"��~Q�@�qObX9d�@�њ��^
@�`�
  �E	�� -    ��Name$ borderBalloon��$��5,-3,5,5q� �� CornerRadius$ 7�� K� ZIndex$	 100��#��[ $	��Top=� J� Effect   $ 	#FF757575��$ .7Q�._��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ 	imageType��$��0��$��35��$��5q�$	��Top=�$��35��$��Resources/information.png���� -    ��Name$ scrollViewerCaption��$��1��$��
0,10,10,10q�$
��Auto=�.���� -    ��Name$ textBlockCaption��$
��Wrap=�&   System.Windows.Media.TextOptions    TextFormattingMode$  Display=�$��This is the caption��! � Triggers! :� " :� RoutedEvent$" FrameworkElement.Loaded��.[��� -   # ��Name$# StoryboardLoad��.���� .��W� $ �� TargetProperty$$ (UIElement.Opacity)�% W� From$	% 0.0X�	& W� To$	& 1.0X�' g� Duration$' 0:0:2D�W� -   $$ (UIElement.Opacity)�$	% 1.0X�$	& 0.0X�$' 0:0:3D�( g� 	BeginTime$( 0:0:3X�:� $" Mouse.MouseEnter��[��� ) �� BeginStoryboardName$) StoryboardLoad���� $) StoryboardFade��:� $" Mouse.MouseLeave��.[��� -	   $# StoryboardFade��.���� .��W� -
   $$ (UIElement.Opacity)�$	% 1.0X�$	& 0.0X�$' 0:0:1D�$( 0:0:1X�z��� * �� ScaleY$* 1Q�