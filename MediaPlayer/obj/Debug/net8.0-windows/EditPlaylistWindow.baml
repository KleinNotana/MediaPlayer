   M S B A M L   `   `   `  ����H  DMyMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyMediaPlayerMyMediaPlayer  5   	   &     MyMediaPlayer.EditPlaylistWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   'localclr-namespace:MyMediaPlayer  5   	     � Title$  Window1��5	   	   $	��400��6   $	��600��6&    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������ .��5      ��  �� CornerRadius$ 10��6   $��2q�5       J� Opacity$
 0.95Q�5      ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �    winBorderColor1 � Color# [  6   	 � Offset$	 0Q�6H   � 5        winBorderColor2# [ 6   $
	 0.75Q�6H   � 5        winBorderColor3# [ 6   $	 1Q�6H   5      ��5   
   �� 5      $	 0,1&�6"   $	 1,0&�63   .��5      �   primaryBackColor1# [ 6   $	 0Q�6J   � 5        primaryBackColor2# [ 6   $	 1Q�6J   5      ._�5"   
   � 
 � RowDefinitions
 5#      �� 5$      $��30 �6    �� 5%      .+�5'      � -   5        $��0��5'       � ColumnDefinitions 5(      �� 5)      �� 5*      $��25 �6'   �� 5+      $��25 �6'   �� 5,      $��5 �6'   .+�5.      �� $��EDIT PLAYLIST��6     titleColor2#��[ 5/      $��10(�50      $��
Montserrat)�51      $��0��52      $��Center=�53      $��10,0,0,0q�54      �� 55      -   5         ��Name$ btnMinimize��55      $��0q�56      $��-��57        titleColor1#��[ 58      $��16(�59      $��
Montserrat)�5:       � Cursor$
 Hand��5;      $��1��5<      ��5>      �� 5?       �� 
TargetType" ��6    .�5@      ��  �� Property � �� 
 color8 �� Value# [ 6;    �� Triggers 5A      P� 5B   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5C   &   ��  � �� 
 color2# [ 6C   5D   #   5F      ��5H      �� 5I       �� 
TargetType" ��6*   .R�5J      �� $��18��6%   $��18��60   $ 9��5K   %   #��z��5L   %   ._�5M   "   �� $��Center=�63   $��Center=�5N   $   5O      5P      5R      �� 5S      -   5        $ btnClose��5S      $��0q�5T      $��X��5U      #��[ 5V      $��12(�5W      $��
Montserrat)�5X      $
 Hand��5Y      $��2��5Z      $��30��5[   0   $	��Top=�6<   ��5\      �� 5]      " ��6    .�5^      ��  � �� 
	 color7# [	 6;    5_      P� 5`   "    �@J�IsMouseOver$
 True��6A   . �5a   &   ��  � �� 

 color4# [
 6C   5b   #   5d      ��5f      �� 5g      " ��6*   .R�5h      �� $��18��6%   $��18��60   $ 9��5i   %   #��z��5j   %   ._�5k   "   �� $��Center=�63   $��Center=�5l   $   5m      5n      5p      5q      � 5s      $��1��6    5t      �� 5u      $	��300 �6'   �� 5v      $��* �6'   .+�5y      �� $��0��6   $��Center=�6-   $��Center=�6H   .+�5z      �� $	��200��6   $	��200��6(   ��65   �� *ThumbnailPath+  RelativeToAbsoluteConverter �� 	Converter# [ 5{      �� 5}      $��1��6   $��Center=�6-   $
��Left=�6H   .+�5~      �� $
��Name��6    #��[ 5      $��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0,20,0,0q�5�      �� 5�      -   5         ��Name$ txtDescription��5�      $��13(�5�      $��Medium"�5�      $��
Montserrat)�5�      $	��200��5�      #��[ 5�       �� 
CaretBrush
 �����#��[ 5�      $��0,0,0,2q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      $��20,0,0,0q�5�      ��5�      �� *Name+ �� Mode$ TwoWay=�.��5�   ,   ��5�      �� 5�       j� Stretch$
 None=�5�   !    j� 
AlignmentX$
 Left=�5�   !   .��5�   .   5�      �� 5�      -   5        $ 	btnUpload��5�        normalButton#��[ 60   
 � Tag# [ 5�      $��0,20,0,0q�6<   $
��Left=�5�      .��5�      ��  �� Orientation$ 
Horizontal=�6%   .+�5�      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Upload=�6+      
Foreground# [ 69   $��15��6c   $��15��6n   $��0,0,5,0q�6z   �� 5�      $��Select Thumbnail��6(   #��[ 6@   $��12(�6j   $��
Montserrat)�6x   5�      5�      �� 5�      -   5        $
 Save��5�      #��[ 6+   # [ 5�      $��0,40,0,0q�6A   .��5�      �� $
��Save��6$   5�      5�      5�      5�      5�      5�      