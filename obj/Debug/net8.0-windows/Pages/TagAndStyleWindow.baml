   M S B A M L   `   `   `  ����V  RSuntoTexteditorExtensionWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SuntoTexteditorExtensionWPF.Pages!SuntoTexteditorExtensionWPF.Pages  5   	   9    3SuntoTexteditorExtensionWPF.Pages.TagAndStyleWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:SuntoTexteditorExtensionWPF.Pages     5   	   -   5          � Title$  Tag Manager��5   	   $	��500��5
   	   $	��300��5   	   $	��500��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5   	    � ShowInTaskbar$ False��5   	    � WindowStartupLocation$ CenterOwner=�5   	   $	��477��5   K    +� FocusedElement 6	   ��  �� ElementName$ SearchTextBox��.��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5       � RowDefinitions 5      �� 5      $
��380* �6    �� 5      $	��67* �6    �� 5      $	��37* �6    .+�5       �� $��Search:��6   $
��Left=�6&   $��10,4,0,0q�6A   $	��Top=�6S   $��26��6k   $��48��6w   �� 5!      -   5        	 ��Name$	 SearchTextBox��5!      $��2��6K   $��
58,10,10,0q�6_   
 �� TextWrapping$

 Wrap=�6s   $	��Top=�6�   $��18��6�   �� 5"      -   5         ��Name$ ItemListBox��5"      $��2��6V   $��
10,35,10,0q�6j   �� 5$      -   5        $	 SelectionTextBox��5$      $��
10,10,10,0q�60   $

 Wrap=�6D   $�� ��6X   $	��Top=�6`   $��2��6x   $��1��6�   $��18��6�   �� 5%      -   5         ��Name$ 	AddButton��5%      $	��Add��6(   $��
10,38,10,0q�6O   $��1��6c   $��20��6p   $	��Top=�6|   �� 5&      -   5        $ DeleteButton��5&      $��Delete��6+   $��
10,38,10,0q�6X   $��1��6l   $��1��6y   $��20��6�   $	��Top=�6�   �� 5(      -   5        $ CloseButton��5(      $��Close��6*    �� IsCancel$
 True��6:   $��	10,4,10,0q�6e   $��2��6x   $��1��6�   $��20��6�   $	��Top=�6�   5)      5*      5+      