   M S B A M L   `   `   `  ����J  FMemoryTilesGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MemoryTilesGameMemoryTilesGame  5   	        MemoryTilesGame.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MemoryTilesGame     5   	     � Title$  SignIn��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
   
   �� $
��Bold"�6    �� TextAlignment$ Center=�6&   $��25(�6=   Welcome, enjoy this game!6f   �� 5   
   -   5        $��PlayerListView��5      $��56,40,532,103q�6)    �� View 5      �� 5      .P�5      ��  �� DisplayMemberBinding 6%   �� *UserNameBinding+6X   5      5      �� 5   
   -   5        $��userProfilePicture��5      $
��Left=�6*   $	��176��6E   $��
507,51,0,0q�6R   $	��Top=�6f   $	��171��6~   A� 5   
    A� Rows$ 1��6    A� Columns$ 4��6   $��Center=�6+   $	��Top=�6H   $��66��6`   $��	0,338,0,0q�6l   $	��668��6   .+�5      �� -   5        $��newUserButton��5   (   $��New User��6   $��10q�6>   6J   �� 5      -   5        $��deleteUserButton��5   +   $��Delete User��6   $��10q�6D   6P   �� 5      -   5        $��
playButton��5   0   $
��Play��6   $��10q�6$   6B   �� 5      -   5        $��
exitButton��5   0   $
��Exit��6   $��10q�6$   6B   5      �� 5   
   -   5        $��previousUserButton��5   )   $��Previous User��6   $
��Left=�6C   $��507,249,0,0q�6^   $	��Top=�6s   6�   �� 5   
   -   5        $��nextUserButton��5   %   $��	Next User��6   $
��Left=�6;   $��625,249,0,0q�6V   $	��Top=�6k   6�   5      5      