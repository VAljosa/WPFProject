   M S B A M L   `   `   `  ����  DemoDiplomski%    DemoDiplomski.View.OptionDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Personalizacija��5   	   $	��300��6!   $	��300��6.   .��5      ]� .+�5   
   �� $��Bottom=�6   $��Right=�6-    �� Orientation$ 
Horizontal=�6I   .+�5	      �� -   5         ��Name$ btnOK��5	   &    �� 	IsDefault . $��OK��65   ��6B   ��  �� ElementName$ 	btnCancel�� �� Path$ ActualWidth�6|   �� 5
      $��Cancel��6    �� IsCancel . 6&   5      �� 5   
   $��10q�6   $��10q�6!   .@�5      �� $��Opste��6   .��5      �� $ 
Horizontal=�6   .+�5      �� $��Prikazi toolBar: ��6   �� 5      -   5         ��Name$ 
chbToolBar��5      	 d� 	IsChecked$
	 TrueY�63   5      5      �� 5      $��Boja editora��6   .��5      � 
 � RowDefinitions
 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5      �� $��Komponente: ��6   $��0��63   $��0��6@   �� 5      $��1��6   $��0��6)   $��Foreground Color:��69   #  Xceed.Wpf.Toolkit.ColorPicker  5       -   5          Name$ clpDisplayForegroundColor��5    (   $��1��6u   $��1��6�      SelectedColor 6K   �� *ColorForeground+6�   �� 5!      $��2��6   $��0��6)   $��Background Color:��69     5"      -   5        $ clpDisplayBackgroundColor��5"   (   $��2��6u   $��1��6�    6K   �� *ColorBackground+6�   5#      5$      5%      5&      5'      