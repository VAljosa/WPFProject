   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections  H DDemoDiplomski, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DemoDiplomski.ViewControlDemoDiplomski.ViewControl f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity A%clr-namespace:DemoDiplomski.ViewModelDemoDiplomski.ViewModel Q-clr-namespace:DemoDiplomski.ViewModel.ModelVMDemoDiplomski.ViewModel.ModelVM 1&clr-namespace:System;assembly=mscorlibSystem  9!clr-namespace:DemoDiplomski.ModelDemoDiplomski.Model =#clr-namespace:DemoDiplomski.UtilityDemoDiplomski.Utility 5   /DemoDiplomski.ViewControl.KorisniciViewControls   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Bcol2clr-namespace:System.Collections;assembly=mscorlib     9local'clr-namespace:DemoDiplomski.ViewControl     ]e2cMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     4vm%clr-namespace:DemoDiplomski.ViewModel     =vmm-clr-namespace:DemoDiplomski.ViewModel.ModelVM     6sys&clr-namespace:System;assembly=mscorlib     3Model!clr-namespace:DemoDiplomski.Model     7Utility#clr-namespace:DemoDiplomski.Utility       � 	Resources   �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid��%�  '��       '�� l     '�� �     '�� �     '  %    �� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$
 Left=���  � ��$ 	0,20,0,20q��� " ��.���  � ��$ 	10,0,20,0q��� " ��.���  � ��$ 20����  � ��$	 100���� " ��.���  � ��$ 20,0,0,0q���  � ��$ 30����  � ��$ 30���� "  .���  � ��$ 10,0,0,0q�.���� $
��Auto=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�]� $��0��$��5,0,0,0q�.+��� $
��Left=�$��
Dostavnica���� $��Right=�$��5,5,0,0q��� $��1��$��0,20,0,0q�.+��� $��Broj dostavnice: ���� -    ��Name$ cbDostavnicaBroj�� �� 
IsEditable .  �� DisplayMemberPath$ Model.BrDostavnica������ *
Dostavnice+ �� SelectedItem �� *DostavnicaFilterBrDostavnica+�� $��Grad: ��$��	35,0,10,0q��� -   $ cbDostavnicaGodina�� . $��10,0,0,0q�$ Model.Korisnik.Grad������ *
Dostavnice+ �� *DostavnicaFilterGrad+�� -   	 ��Name$	 btnDostavnicaPretraga��
 � ToolTip$
 	Pretraži������ *FiltrirajDostavnica+.��]� .+��� $6��0/DemoDiplomski;component/Resources/icons/ok2.png��  -     Name$ dgDostavnice��$��2��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto $��	10,20,0,0q�$ �� IsSynchronizedWithCurrentItem$
 TrueY�   HeadersVisibility$ Column=�   AlternatingRowBackground
 �������. ! �� IsDeferredScrollingEnabled .    AutoGenerateColumns .  ���� *
Dostavnice+ �� *SelektovanaDostavnica+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Broj dostavnice��   Width$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Model.BrDostavnica+ �� Mode$ TwoWay=�  $ Datum��$
 Auto  �� *Model.Datum+ �� StringFormat$ {0:dd/MM/yyyy}��$ TwoWay=�  $ Naziv ustanove��$
 Auto  �� *Model.Korisnik.NazivUstanove+$ TwoWay=�  $	 PIB��$
 Auto  �� *Model.Korisnik.PIB+$ TwoWay=�  $ 	Odeljenje��$
 Auto  �� *Model.Korisnik.Laboratorija+$ TwoWay=�  $ Telefon��$
 Auto  �� *Model.Korisnik.Telefon+$ TwoWay=�  $ Adresa��$
 Auto  �� *Model.Korisnik.Adresa+$ TwoWay=�  $ Poštanski broj��$
 Auto  �� *Model.Korisnik.PostanskiBroj+$ TwoWay=�  $
 Grad��$
 Auto  �� *Model.Korisnik.Grad+$ TwoWay=�  $ Država��$
 Auto  �� *Model.Korisnik.Drzava+$ TwoWay=� � ContextMenu �� .@�m� $��Kreiraj dokument�� m� Command �� *DostavnicaMerge+ m� Icon �� $��21��$��21��$7��1/DemoDiplomski;component/Resources/icons/word.png��]� $��3��$��5,30,0,0q�.+��� $
��Left=�$��Revers���� $��Right=�$��5,5,0,0q��� $��4��.+��� $��Broj reversa: ���� -   $ cbReversBroj�� . $��20,0,0,0q�$ Model.BrRevers������ *	Reversi+ �� *ReversFilterBrRevers+�� $��Grad: ��$��
35,0,-10,0q��� -   $ cbReversGodina�� . $��30,0,0,0q�$ Model.Korisnik.Grad������ *	Reversi+ �� *ReversFilterGrad+�� -   $	 btnReversPretraga��$
 	Pretraži������ *FiltrirajRevers+.��]� .+��� $6��0/DemoDiplomski;component/Resources/icons/ok2.png��  -   $ dgRevers��$��5��$
 Auto $
��Auto��$ Column=�   SelectionMode$ Single=�$
 TrueY�   RowDetailsVisibilityMode$ VisibleWhenSelected=�
 ����� .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . ���� *	Reversi+ �� *SelektovaniRevers+   $ Broj reversa��$
 Auto  �� *Model.BrRevers+$ TwoWay=�  $ Datum��$
 Auto  �� *Model.Datum+$ {0:dd/MM/yyyy}��$ TwoWay=�  $ Naziv ustanove��$
 Auto  �� *Model.Korisnik.NazivUstanove+$ TwoWay=�  $	 PIB��$
 Auto  �� *Model.Korisnik.PIB+$ TwoWay=�  $ 	Odeljenje��$
 Auto  �� *Model.Korisnik.Laboratorija+$ TwoWay=�  $ Telefon��$
 Auto  �� *Model.Korisnik.Telefon+$ TwoWay=�  $ Adresa��$
 Auto  �� *Model.Korisnik.Adresa+$ TwoWay=�  $ Poštanski broj��$
 Auto  �� *Model.Korisnik.PostanskiBroj+$ TwoWay=�  $
 Grad��$
 Auto  �� *Model.Korisnik.Grad+$ TwoWay=�  $ Država��$
 Auto  �� *Model.Korisnik.Drzava+$ TwoWay=� �� .@�m� $��Kreiraj dokument�� �� *ReversMerge+ �� $��21��$��21��$7��1/DemoDiplomski;component/Resources/icons/word.png��]� $��6��$��5,30,0,0q�.+��� $
��Left=�$��Nalog���� $��Right=�$��5,5,0,0q��� $��7��.+��� $��Broj naloga: ���� -	   $ cbNalogBroj�� . $��20,0,0,0q�$ Model.BrRadNalog������ *RadniNalozi+ �� *NaloziFilterBrNalog+�� $��Vrsta servisa: ��$��5,0,0,0q��� -
   $ cbNalogServis�� . $��10,0,0,0q�$ Model.Komentar������ *RadniNalozi+ �� *ServisFilter+�� -   $	 btnNalogPretraga��$
 	Pretraži������ *FiltrirajNalog+.��]� .+��� $6��0/DemoDiplomski;component/Resources/icons/ok2.png��  -   $ dgRedovanServis��$��8��$
 Auto $
��Auto��$
 TrueY�
 �����$ Column=�$ Single=� .   .   .  ���� *RadniNalozi+ �� *SelektovaniNalog+   $ Broj radnog naloga��$
 Auto  �� *Model.BrRadNalog+$ TwoWay=�  $ Vrsta servisa��$
 Auto  �� *Model.Komentar+$ TwoWay=�  $ Datum��$
 Auto  �� *Model.Datum+$ {0:dd/MM/yyyy}��$ TwoWay=�  $ Naziv ustanove��$
 Auto  �� *Model.Korisnik.NazivUstanove+$ TwoWay=�  $	 PIB��$
 Auto  �� *Model.Korisnik.PIB+$ TwoWay=�  $ 	Odeljenje��$
 Auto  �� *Model.Korisnik.Laboratorija+$ TwoWay=�  $ Telefon��$
 Auto  �� *Model.Korisnik.Telefon+$ TwoWay=�  $ Adresa��$
 Auto  �� *Model.Korisnik.Adresa+$ TwoWay=�  $ Poštanski broj��$
 Auto  �� *Model.Korisnik.PostanskiBroj+$ TwoWay=�  $
 Grad��$
 Auto  �� *Model.Korisnik.Grad+$ TwoWay=�  $ Država��$
 Auto  �� *Model.Korisnik.Drzava+$ TwoWay=� �� .@�m� $��Kreiraj dokument�� �� *RadniNalogMerge+ �� $��21��$��21��$7��1/DemoDiplomski;component/Resources/icons/word.png��