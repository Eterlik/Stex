   M S B A M L   `   `   `  ���� V  RSuntoTexteditorExtensionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SuntoTexteditorExtensionWPF.Pages!SuntoTexteditorExtensionWPF.Pages  7    1SuntoTexteditorExtensionWPF.Pages.BrowseSongsForm   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Alocal/clr-namespace:SuntoTexteditorExtensionWPF.Pages     -     � Title$  Select a song to load��$	��500��$	��300�� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � ShowInTaskbar$ False�� � WindowStartupLocation$ CenterOwner=� +� FocusedElement ��  �� ElementName$ songsListView��.���  � RowDefinitions �� $
��425* ��� $	��59* �.+��� -    ��Name$ songsListView��$��0,0,0,59q�$��2���� -   $
��Load��	 �� 	IsDefault$
	 True��$��
10,0,310,0q�$��Center=�$��1��{��� $ songsListView��
 �� Path$
 SelectedItems.Count��� -    ��Name$ BrwosSongsForm��$��Cancel�� �� IsCancel$
 True��$��
294,0,10,0q�$��Center=�$��1��