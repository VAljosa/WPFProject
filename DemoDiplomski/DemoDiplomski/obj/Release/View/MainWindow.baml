   M S B A M L   `   `   `  ���� H  DDemoDiplomski, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DemoDiplomski.ModelDemoDiplomski.Model  A%clr-namespace:DemoDiplomski.ViewModelDemoDiplomski.ViewModel  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel A%clr-namespace:DemoDiplomski.ViewModelDemoDiplomski.ViewModel  E'clr-namespace:DemoDiplomski.ViewControlDemoDiplomski.ViewControl  =#clr-namespace:DemoDiplomski.UtilityDemoDiplomski.Utility  c6clr-namespace:DemoDiplomski.ViewControl.DijaloziZaUnos(DemoDiplomski.ViewControl.DijaloziZaUnos  -clr-namespace:DemoDiplomskiDemoDiplomski  #    DemoDiplomski.View.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     [ WXceed.Wpf.AvalonDock, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4h dXceed.Wpf.AvalonDock.Themes.Metro, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4g cXceed.Wpf.AvalonDock.Themes.Aero, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4i eXceed.Wpf.AvalonDock.Themes.VS2010, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4?avalon,http://schemas.xceed.com/wpf/xaml/avalondock     3model!clr-namespace:DemoDiplomski.Model     9utility%clr-namespace:DemoDiplomski.ViewModel     Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase     4vm%clr-namespace:DemoDiplomski.ViewModel     6vc'clr-namespace:DemoDiplomski.ViewControl     7Utility#clr-namespace:DemoDiplomski.Utility     Hvcdzu6clr-namespace:DemoDiplomski.ViewControl.DijaloziZaUnos     c	 _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 'localclr-namespace:DemoDiplomski 	 rResource 	 -     � Title$  Servis��$	��600��$	��800�� � 	Resources    FadeEfekatPoruke �� 
TargetName �� TargetProperty W� From	 W� To g� Duration �� DataType1   +DemoDiplomski.ViewModel.KorisnikUCViewModel5   /DemoDiplomski.ViewControl.KorisniciViewControls0   *DemoDiplomski.ViewModel.UredjajUCViewModel3   -DemoDiplomski.ViewControl.UredjajViewControls/   )DemoDiplomski.ViewModel.DeloviUCViewModel9   3DemoDiplomski.ViewControl.DeloviViewDataGridControl  korisnikUCViewModel �� 
TargetType	 �� Property
 �� Value �� 
TargetType  template �� Orientation ��Name  � 	CanGoBack � ToolTip  � CanGoForward  
logoSource �� 	UriSource �� BaseUri ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        (�� R     *, +)(�� d     *, +)(�� v     *, +)&	 �     '�� �     &	 �     &	 k    '�� �    '�� (    �� .��W� $ UIPoruka��$ (TextBlock.Opacity)�$ 1X�$ 0X�$ 0:0:7D��� "  .R�  �� "  .R�  �� "  .R�    �� " ��.��� 	 � ��

 ������� 	 � ��

 ������� 	 � ��

 �   ��� "  �.R�]� .+��� $��Center=�$ 
Horizontal=�$	��Top=�.+��� $ btnPrethodni��-   #{�z $ Nazad��$��35��$��35��.���� .+��� $@��:/DemoDiplomski;component/Resources/icons/backward-icon.png���� $ 
btnSledeci��-   #{�z $ Napred��$��3,0,0,0q�$��35��$��35��.���� .+��� $?��9/DemoDiplomski;component/Resources/icons/forward-icon.png���� $��Bottom=��� $7 1/DemoDiplomski;component/Resources/image/logo.png?�$7 1/DemoDiplomski;component/Resources/image/logo.png?��� " ��.��� 	 � ��
 �� " ��.R��� $ Border��$��1,1,1,0q�
���   �$ 5,5,0,0��$	��2,0q�._��� $ Sadrzaj��$��Center=�$��Center=�$��Header��$
��10,2q� P�  �@��
IsSelected . . ��� $ Border��	 � ��

 ��ح�P�  �@��
IsSelected .  . ��� $ Border��	 � ��

 ������� " ��.��� 	 � ��

 �   �.��� -    �Name$ grdRoditelj��.+�� -   $ grdMainGrid��
������� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��3* ��� $
��Auto �.+�o� -    o�Name$ mMeni��$��0��$��2������ .R�]� $
��Left=�.@�m� $��	_Projekat��.@�m� -   $��
_Novi unos�� m� Icon �� $��21��$��21��$9��3/DemoDiplomski;component/Resources/icons/dodaj0.png��m� $��_Otvori�� m� Command �� *Otvori+ �� $��21��$��21��$8��2/DemoDiplomski;component/Resources/icons/open4.png��m� $��	_Sačuvaj�� �� $��21��$��21��$<��6/DemoDiplomski;component/Resources/icons/save_menu.png��m� -   $��Izađi�� �� $��21��$��21��$8��2/DemoDiplomski;component/Resources/icons/exit2.png��m� $��_Alati��.@�m� -	    m�Name$ 	menuAlati��$��Podešavanja...�� �� $��21��$��21��$@��:/DemoDiplomski;component/Resources/icons/settings_grey.png��m� -
   $ menuKreiranjeNaloga��$��Kreiranje naloga�� �� $��21��$��21��$:��4/DemoDiplomski;component/Resources/icons/avatar1.png��m� $��Pomoć��.@�m� $��Dokumentacija�� �� *PrikazDokumentacije+ �� $��21��$��21��$>��8/DemoDiplomski;component/Resources/icons/orange_help.png��m� -   $��O Servis aplikaciji�� �� *
OEditoru+ �� $��21��$��21��$7��1/DemoDiplomski;component/Resources/icons/info.png��`� -     `�Name$  tbtToolBarTray��$��1��! `� IsLocked! .  $��Stretch=�.�c� -   " c�Name$" 
tbToolBar0��$
��Left=�# c� OverflowMode$# Always=�.@��� -   $ btnPrethodni��$ Nazad��$��35��$��35��.���� .+��� $@��:/DemoDiplomski;component/Resources/icons/backward-icon.png���� -   $ 
btnSledeci��$ Napred��$��3,0,0,0q�$��35��$��35��.���� .+��� $?��9/DemoDiplomski;component/Resources/icons/forward-icon.png���� $��5,0,0,0q��� -   .���� $ 
Horizontal=�.+��� $ Unesi��$7��1/DemoDiplomski;component/Resources/icons/add6.png��$��35��$��35���� $��Right=����� *Osvezi_Podatke+.���� $ 
Horizontal=�.+��� $ Osveži��$:��4/DemoDiplomski;component/Resources/icons/refresh.png��$��30��$��30���� $��Right=����� *Otvori+.���� $ 
Horizontal=�.+��� $ Otvori��$7��1/DemoDiplomski;component/Resources/icons/open.png��$��30��$��30���� ���� *	Sacuvaj+.���� $ 
Horizontal=�.+��� $ Sačuvaj��$7��1/DemoDiplomski;component/Resources/icons/save.png��$��0,3,3,0q�$��30��$��30��c� $��Stretch=�$# Always=�.@��� $ 
Horizontal=�$��40���� $��	10,0,10,0q��� -   $ btnOEditoru��$ O servis aplikaciji��$��35��$��35��.���� .+��� $7��1/DemoDiplomski;component/Resources/icons/info.png���� -   $ ��Name$$ UIPoruka��$��1��$��Center=�$��Right=�$��0,0,20,0q�
���  ��$
��Bold"�$��12(�$�� ��)  #Xceed.Wpf.AvalonDock.DockingManager  -   %  Name$% DockingManager��$��2��& J� RenderTransformOrigin$& 0.504,0.499&�'   Layout.' ,  &Xceed.Wpf.AvalonDock.Layout.LayoutRoot  (   	RootPanel.( -	  'Xceed.Wpf.AvalonDock.Layout.LayoutPanel	  �
  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]) 
  Children.) ;  5Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePaneGroup  *   Orientation$* Vertical=��  �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]+   	DockWidth$+ 1* ��  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]],   Children., 6  0Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePane  �  �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]-   
DockHeight$- 2* ��  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]].   Children.. 2  ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable  -   
Editor��/   AutoHideWidth$	/ 250Q�/  )Xceed.Wpf.AvalonDock.Layout.LayoutContent0   Content.0 �� -   1 ��Name$1 
tabControl��$	��250��$��0,10,0,0q�.@��� $��	Korisnici��
����  �$
��Bold"�
�������. 	 (System.Windows.Interactivity.Interaction2   Triggers2 / 	 )System.Windows.Interactivity.EventTrigger  3   	EventName$ 3 PreviewMouseLeftButtonDown��. 	 (System.Windows.Interactivity.TriggerBase4   Actions.4 6 	 0System.Windows.Interactivity.InvokeCommandAction  5   Command5 �� *UcKorisnikTab+.���� $ Vertical=�.+��� -   6 ��Name$6 lstKorisnik��$7 �� IsSynchronizedWithCurrentItem$
7 TrueY�$
��Auto=���. !8 �� IsDeferredScrollingEnabled8 . 9 �� SelectionMode$9 Single=����� *(&KorisnikViewModelUC.KorisniciKolekcija+: �� SelectedItem: �� *)'KorisnikViewModelUC.SelektovaniKorisnik+; �� View; �� .P��� $��Naziv ustanove��< �� DisplayMemberBinding< �� *Model.NazivUstanove+�� $��	Odeljenje��< �� *Model.Laboratorija+= � ContextMenu= �� .@�m� -   $��Dodaj novog korisnika�� �� *$"KorisnikViewModelUC.DodajAzurirajK+ �� $��21��$��21��$9��3/DemoDiplomski;component/Resources/icons/dodaj0.png��m� -   $%��Ažuriraj postojećeg korisnika�� �� *$"KorisnikViewModelUC.DodajAzurirajK+ �� $��22��$��22��$<��6/DemoDiplomski;component/Resources/icons/edit-icon.png��m� $��Izbriši�� �� *KorisnikViewModelUC.Izbrisi+ �� $��21��$��21��$:��4/DemoDiplomski;component/Resources/icons/delete1.png���� -   $6 lstDostavnice��$
��Auto=����� > �� ElementName$> lstKorisnik��? �� Path$#? SelectedItem.Model.Dostavnice�; �� .P��� $��Broj dostavnice��< �� *BrDostavnica+�� $��Datum��< �� *Datum+@ �� StringFormat$@ {0:dd/MM/yyyy}���� -   $6 
lstReversi��$
��Auto=����� $> lstKorisnik��$ ? SelectedItem.Model.Reversi�; �� .P��� $��Broj reversa��< �� *
BrRevers+�� $��Datum��< �� *Datum+$@ {0:dd/MM/yyyy}���� -   $6 lstRadniNalozi��$
��Auto=����� $> lstKorisnik��$? SelectedItem.Model.Nalozi�; �� .P��� $��Broj radnog naloga��< �� *
BrRadNalog+�� $��Datum��< �� *Datum+$@ {0:dd/MM/yyyy}���� $��Servis��< �� *
Komentar+�� -   $6 lstUredjaji����. $
��Auto=�8 . ���� $> lstKorisnik��$!? SelectedItem.Model.Uredjaji�; �� .P��� $��Serijski broj��< �� *S_N+�� $	��Tip��< �� *Tip+�� $��Uređaji��
���  ��$
��Bold"�
�������2   $ 3 PreviewMouseLeftButtonDown��.4   5 �� *UcUredjajTab+.���� $ Vertical=�.+��� -   $6 
lstUredjaj��$
7 TrueY�$9 Single=����� *&$UredjajViewModelUC.UredjajiKolekcija+: �� *'%UredjajViewModelUC.SelektovaniUredjaj+A �� Mode$A TwoWay=�; �� .P��� $��Serijski broj��< �� *	Model.S_N+�� $��Tip uredjaja��< �� *	Model.Tip+�� $��Detalji��< �� *Model.Detalji+= �� .@�m� -   $��Dodaj novi uređaj�� �� *!UredjajViewModelUC.DodajUredjaj+ �� $��21��$��21��$9��3/DemoDiplomski;component/Resources/icons/dodaj0.png��m� -   $"��Ažuriraj postojeći uređaj�� �� *UredjajViewModelUC.AzurirajU+ �� $��22��$��22��$<��6/DemoDiplomski;component/Resources/icons/edit-icon.png��m� $��Izbriši uređaj�� �� *UredjajViewModelUC.IzbrisiU+ �� $��21��$��21��$:��4/DemoDiplomski;component/Resources/icons/delete1.png���� -    $6 lstVandresniServisi������ $> 
lstUredjaj��$)? #SelectedItem.Model.VandredniServisi�; �� .P��� $��Datum servisa��< �� *DatumServisa+$@ {0:dd/MM/yyyy}���� $��Broj naloga��< �� *Nalog.BrRadNalog+�� -!   $6 lstRedovniServisi������ $> 
lstUredjaj��$'? !SelectedItem.Model.RedovniServisi�; �� .P��� $��Datum servisa��< �� *DatumServisa+$@ {0:dd/MM/yyyy}���� $��Datum sledećeg servisa��< �� *DatumSledecegServisa+$@ {0:dd/MM/yyyy}���� $��Broj naloga��< �� *Nalog.BrRadNalog+�� $��Inventar��
��� � �$
��Bold"�
�������2   $ 3 PreviewMouseLeftButtonDown��.4   5 �� *UcInventarTab+.���� $ Vertical=�.+��� -"   $6 lstInventar��$
7 TrueY�$9 Single=����� * DeoViewModelUC.DeloviKolekcija+: �� *DeoViewModelUC.SelektovaniDeo+$A TwoWay=�; �� .P��� $��Kataloski broj��< �� *Model.K_Broj+�� $��Naziv��< �� *Model.Naziv+�� $��	Na stanju��< �� *Model.NaStanju+�� $��Kolicina��< �� *Model.Kolicina+= �� .@�m� -#   $��Unesi nov deo�� �� *DeoViewModelUC.DodajDeo+ �� $��21��$��21��$9��3/DemoDiplomski;component/Resources/icons/dodaj0.png��m� -$   $��Ažuriraj postojeći deo�� �� *DeoViewModelUC.AzurirajD+ �� $��22��$��22��$<��6/DemoDiplomski;component/Resources/icons/edit-icon.png��m� $��Izbriši deo�� �� *DeoViewModelUC.IzbrisiD+ �� $��21��$��21��$:��4/DemoDiplomski;component/Resources/icons/delete1.png���� -%   $6 lstUredjajiInventar������ $> lstInventar��$!? SelectedItem.Model.Uredjaji�; �� .P��� $��Broj uredjaja��< �� *S_N+�� $	��Tip��< �� *Tip+  $+ 2* �.,   ..   .0  � -&   B  �Name$B ccEditor��C  � NavigationUIVisibility$C Hidden=�$��0��$��1��$��4��$��5��#��[ ���� *
TekuciUC+�� $��3������ .R�� D � ColumnDefinitionsD �� $��1* ��� $
��Auto �.@��� $��0���� $��2��$��Right=�.���� $��Redovan servis��$
��Auto��
��� � �