   M S B A M L   `   `   `  ����V  RSuntoTexteditorExtensionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SuntoTexteditorExtensionWPF.Pages!SuntoTexteditorExtensionWPF.Pages  5   	   ;    5SuntoTexteditorExtensionWPF.Pages.DisplayLyricsEditor   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:SuntoTexteditorExtensionWPF.Pages     5   	   -   5          � Title$  Display Lyrics Editor��5   	   $	��500��5
   	   $	��600��5   	   $	��500��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5   	    � ShowInTaskbar$ False��5   	    � WindowStartupLocation$ CenterOwner=�5   	   $	��477��5   	    +� FocusedElement 5   	   ��  �� ElementName$ DisplayLyricsTextBox��.��5      �  � ColumnDefinitions 5   
   �� 5      $
��361* �6   �� 5      $
��239* �6   .+�5   
   �� -   5        $��Reload Lyrics��5   3   $
��Left=�6K   $��	10,13,0,0q�6f   $	��Top=�6y   $��20��6�   $��72��6�   �� 5   
   -   5         ��Name$ DisplayLyricsTextBox��5      $��10,41,10,10q�60   	 �� TextWrapping$
	 Wrap=�6E   $�� ��6Y   
 �� AcceptsReturn$

 True��6a   �� 5   
   -   5         ��Name$ RemoveTagsCheckBox��5       d� 	IsChecked$
 TrueY�6/   $��1��6@   $��Remove Tags��6P   $
��Left=�6f   $��	15,41,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ RemoveBracketsCheckBox��5      $
 TrueY�63   $��1��6D   $��Remove Brackets��6T   $
��Left=�6n   $��	16,61,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ RemovePunctuationCheckBox��5      $
 TrueY�66   $��1��6G   $��Remove Punctuation��6W   $
��Left=�6t   $��	16,81,0,0q�6�   $	��Top=�6�   �� 5    
   -   5        $ LowerCaseCheckBox��5       $
 TrueY�6.   $��1��6?   $��Switch to lower case��6O   $
��Left=�6n   $��
15,101,0,0q�6�   $	��Top=�6�   �� 5!   
   -   5        $ FirstLetterCheckBox��5!      $
 TrueY�60   $��1��6A   $��Make first letter big��6Q   $
��Left=�6q   $��
15,121,0,0q�6�   $	��Top=�6�   �� 5"   
   -	   5        $��1��5"   ,   $��Apply��6<   $
��Left=�6L   $��
54,141,0,0q�6g   $	��Top=�6{   �� 5$   
   -
   5        $��1��5$   +   $
��Save��6;   $
��Left=�6J   $��	10,0,0,10q�6e   $��20��6x   $��Bottom=�6�   �� 5%   
   -   5         �� IsCancel$
 True��5%   -   $��1��6=   $��Cancel��6M   $��	0,0,11,10q�6^   $��20��6q   $��Bottom=�6}   $��Right=�6�   $��39��6�   �� 5&   
   $��Display Lyrics��6   $��Center=�6)   $��0,10,0,0q�6F   $	��Top=�6X   5'      5(      