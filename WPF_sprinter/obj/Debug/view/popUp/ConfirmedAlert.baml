   M S B A M L   `   `   `  ����G  CWPF_sprinter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPF_sprinter.view.popUpWPF_sprinter.view.popUp  5   	   ,    &WPF_sprinter.view.popUp.ConfirmedAlert   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WPF_sprinter.view.popUp     5   	     � Title$  Notification��5   	   $	��278��6   $	��423��6+    � 
ResizeMode$ NoResize=�67    � Topmost . .��5	      �  � 	Resources 5
   
      ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name
 �� Triggers P� Property P� Value��%�  &	        �� 5      " ��6(   .�5      ��  � �� �#8B868267   �� 5       � �� �#fff67   �� 5       � �� �#8B86826J   �� 5       � ��$
 5,10q�63   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $ 6��6%   #��z��66   ._�5   "   �� $	 MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��	20,0,20,0q�6�   5      5      5      
 5      P� 5       �@J�IsMouseOver . . �5      ��  � �� �#0006?   �� 5       �@�Cursor$
 Hand��6;   5      P� 5       � {� .  . �5      ��  � �� �#5556?   �� 5        � �� �#8B89896?   5!      5#      5$      .+�5%   
   ]� .+�5&      �� $	��270��6   $��Right=�6%   $��	0,0,10,10q�6A   $��Bottom=�6T    �� Orientation$ 
Horizontal=�6l   .+�5'      �� -   5        $��50��5'      $	��100��6%   $��OK��61   #��[  6M   �� 5(      -   5        $��50��5(      $	��150��6%   $��Cancel��61   #��[  6V   5)      �� 5*      -   5        $��DataText��5*      $	��Top=�6(   $
��Sans)�6=   $��20(�6O   $
��Wrap=�6]    �� TextAlignment$ Center=�6q    �� Padding$ 30,20q�6�   ���#6676�   5+      5,      5-      