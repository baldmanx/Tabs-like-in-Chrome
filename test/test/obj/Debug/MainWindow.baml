   M S B A M L   `   `   `  ����?  ;test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:testtest  5   	       test.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:test     5   	     � Title$
  Test��5   	   $	��200��6   $	��800��6#    � 	Resources 5
         buttonOnTabItem �� 
TargetType �� Property �� Value �� 
TargetType �� Stretch �� Triggers P� Property	 P� Value
 �� 
TargetName  tabItemWithButton � ColumnDefinitions��%w  &	        &	 ~    7   �� 5   
   " ��6(   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      A� $��BG��6&   F� 5      $
��PATH��6#   
�������$��2��6=   $
 Fill=�6Q   =����        ��� �� �`�
 `�
 ��� `�
 �`�
 �� �@B @B 	5      5       5      P� 5       �@J�IsMouseOver	 . . �5   "   �� $
 BG��6)    � �� �#DB44376I   �� 5   "   $

 PATH��6)    � ��
 �����6M   5      P� 5       � ��	 . . �5   "   �� $
 BG��6)    � �� �#A8352A6I   �� 5   "   $

 PATH��6)    � ��
 �����6M   5      5      5       5!      �� 5#   
   " ��6*   .�5$      ��  �@J�	AllowDrop . 6*   -   5        �� 5'       � �� 5(      �� 5)      .R�5*      � $
��Left=�6   $��2q�6:   $	��100��6E    5+      �� 5,   "   �� 5-   "   ��63   �� *	myWidth+.+�5/      �� $��0��6C   $
��Left=�50   '   ��5/   /   �� 50   '   �� 51      -   5        $��Stretch=�51   %   $��15��6C   $��15��6N   $��0��6Z   8��  52      53      54      56      57      58      .��5;      � $��0,0,2,0q�6   .+�5<   
   �� -   5         ��Name$ test_tab��5<       �� TabStripPlacement$	 Top=�6'   $��	0,0,0,108q�6b   �� 5>   
   -   5         ��Name$	 add��5>      $	��Add��6   $��Center=�6F   $��0,66,0,0q�6c   $	��790��6u   5@      5A      