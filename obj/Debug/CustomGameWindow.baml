   M S B A M L   `   `   `  ����J  FMemoryTilesGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MemoryTilesGameMemoryTilesGame  5   	   &     MemoryTilesGame.CustomGameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MemoryTilesGame     5   	     � Title$  CustomGameWindow��5   	   $	��450��6"   $	��800��6/   .��5	      � .+�5
   
   � $��Center=�6   $	��329��6,   $��0,95,0,0q�69   $	��Top=�6K   $	��712��6c   �� 5   
   $
��Left=�6   $��	44,22,0,0q�6/   $
��Wrap=�6B   $+��%Please introduce the number of rows :��6V   $	��Top=�6�   $	��217��6�   �� 5   
   $
��Left=�6   $��	44,54,0,0q�6/   $
��Wrap=�6B   $-��'Please introduce the number of columns:��6V   $	��Top=�6�   $	��229��6�   �� 5   
   -   5        $��RowsTextBox��5      $
��Left=�6%   $��
266,22,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   $��16��6�   �� 5   
   -   5        $��ColumnsTextBox��5      $
��Left=�6(   $��
280,54,0,0q�6C   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��120��6�   $��16��6�   �� 5   
   -   5        $��submitInputButton��5   (   $��Submit input��6   $
��Left=�6A   $��
441,22,0,0q�6\   $	��Top=�6p   $��40��6�   $��77��6�   6�   �� 5   
   -   5        $��CustomGameTimer��5      $
��Left=�6+   $��
571,34,0,0q�6F   $
��Wrap=�6Z   $�� ��6n   $
��Bold"�6v   $	��Top=�6�   $��24��6�   $	��185��6�   �� 5   
   -   5        $��CustomGameBlockLevel��5      $
��Left=�60   $��
444,82,0,0q�6K   $
��Wrap=�6_   $
��Bold"�6s   $�� ��6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��70��6�   z�5      V� 5      .~�5      ��  �� ScaleX$ 1Q�6%   �� 5      �� 5      T� 5      5      5      � 5   
   -   5        $��CustomGameGrid��5      5      5      5      