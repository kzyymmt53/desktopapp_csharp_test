   M S B A M L   `   `   `  ����?  ;Memo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MemoMemo  5   	       Memo.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Memo     5   	     � Title$  
MainWindow��5	   	   $	��400��6   $	��600��6)    +� FocusedElement 5   	   ��  �� ElementName$
 Memo��.��5
      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    .+�5      �� -   5         ��Name$
 Memo��5      $��1��6$    �� TextWrapping$
 Wrap=�61   $��UD Digi Kyokasho NK-R)�6E   " �� VerticalScrollBarVisibility$ Visible=�6h    �� AcceptsReturn$
 True��6�    �� 
AcceptsTab$
 True��6�   o� 5      .@�5      m� $��ファイル(_F)��6   .@�5      m� -   5        $��
開く(_O)��5      6/   m� 5      -   5        $"��名前を付けて保存(_A)��5      65   �� 5      m� 5      -   5        $��
終了(_X)��5      6/   5      m� 5      $��
表示(_V)��6   .@�5      	� -   5        $��文字サイズ標準��5   "   	 d� 	IsChecked$
	 TrueY�64   6E   	� 5      -   5        
 	�Name$

 Zoom��5   "   $��文字サイズ拡大��60   6B   5      m� 5      $��ヘルプ(_H)��6   .@�5      m� -   5        $��バージョン情報(_A)��5      64   5      5       �� 5!      $��2��6   .@�5"      �� -   5         ��Name$ 
StatusInfo��5"       �� 5#      $��UTF-8��6    $��Right=�60   $��5,0,15,0q�6L   5$      5%      5'      5(      