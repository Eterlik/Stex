   M S B A M L   `   `   `  ����V  RSuntoTexteditorExtensionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SuntoTexteditorExtensionWPF.Pages!SuntoTexteditorExtensionWPF.Pages  5   	   7    1SuntoTexteditorExtensionWPF.Pages.BrowseSongsForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:SuntoTexteditorExtensionWPF.Pages     5   	   -   5          � Title$  Select a song to load��5   	   $	��500��5
   	   $	��300��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5   	    � ShowInTaskbar$ False��5   	    � WindowStartupLocation$ CenterOwner=�5   	    +� FocusedElement 5   	   ��  �� ElementName$ songsListBox��.��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��425* �6   �� 5      $	��59* �6   .+�5   
   �� $��Search:��6   $
��Left=�6"   $��10,4,0,0q�6=   $	��Top=�6O   $��26��6g   $��48��6s   �� 5   
   -   5        	 ��Name$	 SearchTextBox��5      $��2��6G   $��
58,10,10,0q�6[   
 �� TextWrapping$

 Wrap=�6o   $	��Top=�6�   $��18��6�   �� 5    
   -   5         ��Name$ songsListBox��5       $��2��6H   $��
10,35,10,0q�6\   �� 5"   
   -   5         ��Name$ ConfirmButton��5"      $
��Load��6(    �� 	IsDefault$
 True��67   $��	10,0,10,0q�6�   $��Center=�6�   $��1��6�   $��20��6�   {�6`   �� $ songsListBox�� �� Path$ SelectedItems.Count�6�   �� 5#   
   -   5        $ BrwosSongsForm��5#      $��Cancel��6)    �� IsCancel$
 True��6:   $��	10,0,10,0q�6f   $��Center=�6y   $��1��6�   $��1��6�   $��20��6�   5%      5'      