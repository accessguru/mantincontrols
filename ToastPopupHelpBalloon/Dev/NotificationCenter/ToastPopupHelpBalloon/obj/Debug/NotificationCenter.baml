   M S B A M L   `   `   `  ����$   Mantin.Controls.Wpf.Notification9    3Mantin.Controls.Wpf.Notification.NotificationCenter   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��30��5      $	��350��6   
������   � 	Resources  5
         ImageAnimation �� Triggers :� RoutedEvent �� TargetProperty g� 	BeginTime g� Duration W� From	 W� To g� RepeatBehavior	 g� AutoReverse��%   &	        �� 5   
    5      :� 5      $ Image.Loaded��6   .[�5      �� .��5      �� .��5      W� $ (Image.Opacity)�6.   $ 0:0:0X�6Z   $ 0:0:1D�6l   $	 1.0X�5   .   $	 0.0X�69   $ Forever��6B   	 . 6[   5      5      5      5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5      -   5         ��Name$ 
RowDetails��5   '   $��0 �6   6'   .+�5   
   ��  �� CornerRadius$ 15��6   $��28��6#   $	��350��6/   $��1q�6;   
�������$��0��6b   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5       �  � Color$ 	#FFFDFDFD��6#   � 5!      $ 	#FF989797��6#    � Offset$ 1Q�65   5"      ._�5$      �  � ColumnDefinitions 5%      �� 5&      $��* �6'   �� 5'      $
��Auto �6'   �� 5(      $
��Auto �6'   �� 5)      $
��Auto �6'   �� 5*      $
��Auto �6'   �� 5+      $��* �6'     5-       �� 
TargetType �� Property �� Value��%�   '��       �� 5.      " ��6   .�5/      ��  � ��$ 24��62   �� 50       � ��$ 24��63   �� 51       � �� 68   Z� �� 52       � ��
 ���� 67   �� 53       �@�Cursor$
 Hand��63   54      55      .+�56      �� -   5         ��Name$ ImageNotifiication��57      $��Resources/information.png��56      $��2,0,0,0q�58      $��24��59      $��24��5:      $��0��5;      $y�Hidden=�5<       � ToolTip$ New Notifications��5=      #��[  5>      $
��Left=�5?      �� 5@      $��1��6   $��0,0,0,0q�6)   .��5A      �� .+�5B      �� $#��Resources/media_beginning.png��6    5C      5D      �� 5E      $��2��6   $��4,0,0,0q�6)   .��5F      �� .+�5G      �� $ ��Resources/media_rewind.png��6    5H      5I      �� 5J      $��3��6   $��4,0,0,0q�6-   .��5K      �� .+�5L      �� $&�� Resources/media_fast_forward.png��6    5M      5N      �� 5O      $��4��6   $��4,0,0,0q�6-   .��5P      �� .+�5Q      �� $��Resources/media_end.png��6    5R      5S      �� 5T      $��5��6   $��Right=�6)   $��0,0,7,0q�6E   .��5U      �� .+�5V      �� $!��Resources/navigate_down.png��6    5W      5X      5Y      5Z      � 5[   
   -   5         �Name$ GridDetails��5[      
����  �$��0��66   $��1��6A   6P   5\      5]      