   M S B A M L   `   `   `  ����   DemoDiplomski%    DemoDiplomski.View.OptionDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit    � WindowStartupLocation$  CenterScreen=� � Title$ Personalizacija��$	��300��$	��300��.��]� .+��� $��Bottom=�$��Right=� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ btnOK�� �� 	IsDefault . $��OK������  �� ElementName$ 	btnCancel�� �� Path$ ActualWidth��� $��Cancel�� �� IsCancel . �� $��10q�$��10q�.@��� $��Opste��.���� $ 
Horizontal=�.+��� $��Prikazi toolBar: ���� -    ��Name$ 
chbToolBar��	 d� 	IsChecked$
	 TrueY��� $��Boja editora��.��� 
 � RowDefinitions
 �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��Komponente: ��$��0��$��0���� $��1��$��0��$��Foreground Color:��#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$ clpDisplayForegroundColor��$��1��$��1��   SelectedColor �� *ColorForeground+�� $��2��$��0��$��Background Color:��  -   $ clpDisplayBackgroundColor��$��2��$��1�� �� *ColorBackground+