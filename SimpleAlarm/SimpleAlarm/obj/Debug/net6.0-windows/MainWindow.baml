   M S B A M L   `   `   `  ����F  BSimpleAlarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SimpleAlarmSimpleAlarm  5   	       SimpleAlarm.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SimpleAlarm     5   	   -   5          � Title$  アラーム��5	   	   $	��250��6   $	��300��6#    � 
ResizeMode$ CanResizeWithGrip=�6/   
������� +� FocusedElement 5   	   ��  �� ElementName$ 	TimeInput�� � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       '�� s     �� 5   
   " ��6   .�5      ��  � ��$ 
10,15,10,2q�6'   �� 5       � ��$ 0q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ 
10,15,10,0q�6'   �� 5       � ��$
 10,0q�6(   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   	 � ColumnDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� .+�5      �� $��
時刻(_T)��6   
 �� Target
 6%   �� $ 	TimeInput���� 5       -   5         ��Name$ 	TimeInput��5       $	��120��6*    �� 
IsEditable$
 True��66   $��	10,0,10,0q�6H   $��Consolas)�6[   $
��Left=�6q   .@�5!      �� $��09:00��6   �� 5"      $��12:00��6   �� 5#      $��15:00��6   �� 5$      $��17:30��6   5%      �� 5&      -   5         ��Name$ 	AddButton��5&      $��追加(_A) →��6(    �� 	IsDefault$
 True��6;   6L   �� 5'      -   5        $��削除(_R) ←��5'      6(   �� 5(      -   5        $ 
SaveButton��5(      $%��アラーム一覧を保存(_S)��6)   6A   5)      � 5*   
   $��1��6   $��2��6    5+      �� 5,      $
��Auto �6    �� 5-      .+�5/      �� $��アラーム一覧(_L)��6   
 6)   �� $ 	AlarmList���� 50      -   5         ��Name$ 	AlarmList��50      $��1��6)   $��
10,0,10,15q�6b   $��Consolas)�6v   51      �� 52   
   -   5         ��Name$
 Mute��52      $��ミュート(_M)��6!   $��1��64   $��10,15q�6\   54      55      