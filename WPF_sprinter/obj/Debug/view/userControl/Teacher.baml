   M S B A M L   `   `   `  ����  WPF_sprinter+    %WPF_sprinter.view.userControl.Teacher   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � ColumnDefinitions  5	   
   �� 5
      $	��152 �6   �� 5      $
��387* �6   �� 5      $	��18* �6    � RowDefinitions 5   
   �� 5      $��3 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��50* �6   .+�5   
   �� $��18(�6   $��10q�6"    �� Padding$ 10,0,0,0q�6.   $��0��6A   $��1��6Q   $��
Firstname:��6^   �� 5   
   $��18(�6   $��10q�6"   $ 10,0,0,0q�6.   $��0��6A   $��2��6Q   $��	Lastname:��6^   �� 5   
   $��18(�6   $��10q�6"   $ 10,0,0,0q�6.   $��0��6A   $��3��6Q   $��Middlename:��6^   �� 5   
   $��18(�6   $��10q�6"   $ 10,0,0,0q�6.   $��0��6A   $��4��6Q   $��
Specialty:��6^   �� 5   
   $��18(�6   $��10q�6"   $ 10,0,0,0q�6.   $��0��6A   $��5��6Q   $��Avatar:��6^   �� 5   
   ���#696969���#eee$��36��6:   $
��10,7q�6F   $��10q�6U   $��1��6a   $��1��6q   ��6~   �� *teacherFirstname+ �� UpdateSourceTrigger$ PropertyChanged=��� 5    
   ���#696969���#eee$��36��6:   $
��10,7q�6F   $��10q�6U   $��1��6a   $��2��6q   ��6~   �� *teacherLastname+$ PropertyChanged=��� 5!   
   ���#696969���#eee$��36��6:   $
��10,7q�6F   $��10q�6U   $��1��6a   $��3��6q   ��6~   �� *teacherMiddlename+$ PropertyChanged=��� 5"   
   ���#696969���#eee$��36��6:   $
��10,7q�6F   $��10q�6U   $��1��6a   $��4��6q   ��6~   �� *teacherSpecialty+$ PropertyChanged=��� 5#   
   $��28��6   $��80��6   $��3q�6(   $��10q�64   $��1��6@   $��5��6P   $��	Browse...��6�   ��6]   ��  �� Path$ actionAvatar� �� Mode$ OneWay=�6�   5%      5&      