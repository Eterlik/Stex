   M S B A M L   `   `   `  ���� V  RSuntoTexteditorExtensionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SuntoTexteditorExtensionWPFSuntoTexteditorExtensionWPF  2    ,SuntoTexteditorExtensionWPF.Pages.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:SuntoTexteditorExtensionWPF       � Title$
  Stex��$	��865��$	��683��.���  � ColumnDefinitions �� $
��483* ��� $
��200* � � RowDefinitions �� $	��79* ��� $
��151* ��� $
��177* ��� $
��442* �.+�o� $��2��$��18��$	��Top=�.@�m� -    m�Name$ MenuItemFile��$
��File��.@�m� -   $ 
saveButton��$
��Save��m� -   $ 
loadButton��$
��Load���� $��Songname��$��	10,36,0,0q�$	��Top=�$��26��$
��Left=�$��67���� -    ��Name$ titleTextBox�� �� 	MaxLength$ 80��$��Unnamed�� �� 	IsEnabled$
 True��$��Center=�$��
82,30,10,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��39���� -    ��Name$ titleCharCountLabel��$
��8/80��$��Right=�$��	0,41,10,0q�$	��Top=�$��47��$��Right=�$��26���� -   	 ��Name$	 lyricsTextBox��$
 True��$��10,79,10,10q�$��4��
 � 	Resources
  �� 
TargetType �� Property �� Value��%3   'J�       �� " J�.���  �@��Margin$ 0q�. �/� .T�J� .*�.*��� $� ���� -   $ lyricsCharCountLabel��$��0/3000��$��Right=�$��	0,0,10,10q�$��77��$��Right=�$��3��$��26��$��Bottom=�� -    �Name$ lyricsPopup������  �� ElementName$ lyricsTextBox�� �� Mode$ OneWay=� �� Path$ IsKeyboardFocused� � PlacementTarget �� $ lyricsTextBox��.���� -	    ��Name$ lyricsPopupList���� $��1��$��Style of Music��$
��Left=�$��	50,43,0,0q�$	��Top=�$��26��$��84���� -
   $	 stylesTextBox��$
 True��$��
0,79,10,10q�$��1��$��2��
 ��%3   'J�       �� " J�.���  �@��Margin$ 0q�. �/� .T�J� .*�.*��� $� ���� -   $ stylesCharCountLabel��$��0/120��$��Right=�$��	0,0,10,10q�$��56��$��Right=�$��1��$��1��$��26��$��Bottom=�� -   $ stylesPopup������ $ stylesTextBox��$ OneWay=�$ IsKeyboardFocused�.���� -   $ stylesPopupList���� $��1��$��Excluded Styles��$
��Left=�$��50,1,0,0q�$	��Top=�$��2��$��26��$��90���� -   $	 excludedStylesTextBox��$
 True��$��
0,32,10,10q�$��1��$��2��
 ��%3   'J�       �� " J�.���  �@��Margin$ 0q�. �/� .T�J� .*�.*��� $� ���� -   $" excludedStylesCharCountLabel��$��0/120��$��Right=�$��	0,0,10,10q�$��56��$��Right=�$��1��$��2��$��26��$��Bottom=�� -   $ excludedStylesPopup������ $ excludedStylesTextBox��$ OneWay=�$ IsKeyboardFocused� �� $ excludedStylesTextBox��.���� -   $ excludedStylesPopupList���� $��1��$	��( )��$��0,18,0,0q�$	��Top=�$
��Left=�$��21��$��3��$��20���� $��1��$��AA / aa��$��0,43,0,0q�$	��Top=�$
��Left=�$��43��$��3��$��20��