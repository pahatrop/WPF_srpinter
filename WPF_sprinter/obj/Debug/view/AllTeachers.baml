   M S B A M L   `   `   `  ����G  CWPF_sprinter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF_sprinter.viewWPF_sprinter.view  5          WPF_sprinter.AllTeachers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:WPF_sprinter.view     5      .��5	      � ���#fff  � 	Resources  5   
      ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers P� Property	 P� Value��%�  &	        �� 5      " ��6(   .�5      ��  � �� �#8B868267   �� 5       � �� �#fff67   �� 5       � �� �#8B86826J   �� 5       � ��$
 5,10q�63   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $ 6��6%   #��z��66   ._�5   "   �� $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��	20,0,20,0q�6�   5      5      5       5      P� 5       �@J�IsMouseOver	 . . �5      ��  � �� �#0006?   �� 5       �@�Cursor$
 Hand��6;   5      P� 5       � {�	 .  . �5       ��  � �� �#5556?   �� 5!       � �� �#8B89896?   5"      5$      5%      .+�5'   
   ]� .+�5(      ]� $	��Top=�6   ���#e6e6e6$��60��6B   .+�5)      �� $
��20,0q�6   ��6'   �� 
 �� Path$
 actionComeBack� �� Mode$ OneWay=���5*      �� 5+      .R�5,      �� $=��7pack://application:,,/source/iconControl/arrow-left.png��6$   $��40��6e   5-      5/      �� 50      $
��Left=�6   $��Center=�62   ���#8B8989$
��Sans)�6b   $��24(�6t   $��Teachers management��6�   51      �� 52       �� Orientation$ 
Horizontal=�6   $��Bottom=�62   $��60��6J   ���#eee.+�53      �� $	��Top=�6   $��30��6-   $-��'pack://application:,,/source/loader.png��6[   $
��10,0q�6�   y�69   �� *
Preloader4+6�   �� 54      $��Create��6�   #��[  6�   {�6   �� *canExecuteAddTeacher+��6D   �� $
 actionShowCreateTeacher�$ OneWay=�6�   �� 55      $
��Edit��6�   #��[  6�   {�6   �� *canExecuteEditTeacher+��6E   �� $
 actionShowEditTeacher�$ OneWay=�6�   �� 56      $��Remove��6�   #��[  6�   {�6   �� *canExecuteRemoveTeacher+��6G   �� $
 actionRemoveTeacher�$ OneWay=�6�   57      �� 58      ���#828282$	��Top=�6+   ���#fff$��0q�6�   ��6@   �� *AllTeachers+ �� SelectedIndex 6d   �� *SelectedTeacher+ �� UpdateSourceTrigger$ PropertyChanged=���59      �� 5:      .R�5;      � $	��100��6   $��5q�6,    � ColumnDefinitions 5<      �� 5=   "   $	��120 �63   �� 5>   "   �� 5?   "    � RowDefinitions 5A      �� 5B   "   �� 5C   "   �� 5D   "   .+�5F      �� $��5q�6(   $��0��63   $��3��6C    �� RadiusX$ 50��6T    �� RadiusY$ 50��6a   $��90��6n   $��90��6y   ��5G   "   �� 5H   &   	brush�� �� ImageSource 6@   �� $
 Avatar�5J      �� 5K      $��1��6)   $��0��69   $ 
Horizontal=�6F   .+�5L   "   �� $
��20,0q�6,   $��24(�6:   ���#4F4F4F��6H   �� $
 Lastname�6g   �� 5M   "   $��0q�6,   $��24(�67   ���#4F4F4F��6E   �� $
 	Firstname�6e   �� 5N   "   $
��20,0q�6,   $��24(�6:   ���#4F4F4F��6H   �� $
 
Middlename�6i   5O      �� 5P      $��1��6(   $��1��68   $��
20,10,20,0q�6E   $��16(�6Y   ��6g   �� $
 	Specialty�5Q      5R      ��5T      �� 5U      " ��6   .�5V      ��  � �� �#eee6C   �� 5W       � ��$ 0q�6?   �� 5X       � �� 5Y      �� 5Z   "   " ��62   .R�5[   &   ��  ��Name$ border��6-   ._�5\   *   �� 6=   5]   '    �� Triggers 5^   &   P� 5_   *    �@��
IsSelected	 . . �5`   .   ��  �� 
TargetName$ border��65    � �� �#8B86826r   �� 5a   .    � �� �#fff6K   5b   +   5d   #   5f      5g      5i      5j      5k      5l      