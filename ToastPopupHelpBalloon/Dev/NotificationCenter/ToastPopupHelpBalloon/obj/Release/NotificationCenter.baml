   M S B A M L   `   `   `  ���� $   Mantin.Controls.Wpf.Notification9    3Mantin.Controls.Wpf.Notification.NotificationCenter   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��30��$	��350��
������   � 	Resources     ImageAnimation �� Triggers :� RoutedEvent �� TargetProperty g� 	BeginTime g� Duration W� From	 W� To g� RepeatBehavior	 g� AutoReverse��%�   &	        ��  :� $ Image.Loaded��.[��� .���� .��W� $ (Image.Opacity)�$ 0:0:0X�$ 0:0:1D�$	 1.0X�$	 0.0X�$ Forever��	 . .��� 
 � RowDefinitions
 �� $
��Auto ��� -    ��Name$ 
RowDetails��$��0 �.+���  �� CornerRadius$ 15��$��28��$	��350��$��1q�
�������$��0������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFFDFDFD��� $ 	#FF989797�� � Offset$ 1Q�._��  � ColumnDefinitions �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �   �� 
TargetType �� Property �� Value��%�   '��       �� " ��.���  � ��$ 24����  � ��$ 24����  � �� Z� ��  � ��
 ���� ��  �@�Cursor$
 Hand��.+��� -    ��Name$ ImageNotifiication��$��Resources/information.png��$��2,0,0,0q�$��24��$��24��$��0��$y�Hidden=� � ToolTip$ New Notifications��#��[  $
��Left=��� $��1��$��0,0,0,0q�.���� .+��� $#��Resources/media_beginning.png���� $��2��$��4,0,0,0q�.���� .+��� $ ��Resources/media_rewind.png���� $��3��$��4,0,0,0q�.���� .+��� $&�� Resources/media_fast_forward.png���� $��4��$��4,0,0,0q�.���� .+��� $��Resources/media_end.png���� $��5��$��Right=�$��0,0,7,0q�.���� .+��� $!��Resources/navigate_down.png��� -    �Name$ GridDetails��
����  �$��0��$��1��