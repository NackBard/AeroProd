   M S B A M L   `   `   `  ����C  ?AeroProd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AeroProdAeroProd  5          AeroProd.StaffList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:AeroProd     5        N� Title$  	StaffList��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��44* �6   �� 5      $	��73* �6   �� 5      $	��44* �6   �� 5      $	��73* �6   �� 5      $	��44* �6   �� 5      $	��73* �6   �� 5      $	��67* �6   �� 5      $
��110* �6   �� 5      $
��110* �6   �� 5      $
��110* �6   �� 5      $
��110* �6   .+�5   
   �� $��0��6   $��Имя��6!   $��0��6,   $��Stretch=�6<   $��Stretch=�6X   $'��!/AeroProd;component/Fonts/#Roboto)�6v   $��24(�6�   $��10q�6�   �� 5    
   -   5         ��Name$ NameBox��5       $��1��6#   $��0��60   $��Stretch=�6@   $��Stretch=�6\   $��10q�6{   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��24(�6�   �� 5!   
   $��2��6   $��Фамилия��6!   $��0��60   $��Stretch=�6@   $��Stretch=�6\   $'��!/AeroProd;component/Fonts/#Roboto)�6z   $��24(�6�   $��10q�6�   �� 5"   
   -   5        $ LastNameBox��5"      $��3��6'   $��0��64   $��Stretch=�6D   $��Stretch=�6`   $��10q�6   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��24(�6�   �� 5#   
   $��4��6   $��Должность��6!   $��0��62   $��Stretch=�6B   $��Stretch=�6^   $'��!/AeroProd;component/Fonts/#Roboto)�6|   $��24(�6�   $��10q�6�   �� 5$   
   -   5        $ PatronymicBox��5$      $��3��6)   $��1��66   $��Stretch=�6F   $��Stretch=�6b   $��10q�6�   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��24(�6�   �� 5%   
   $��2��6   $��Отчество��6!   $��1��61   $��Stretch=�6A   $��Stretch=�6]   $'��!/AeroProd;component/Fonts/#Roboto)�6{   $��24(�6�   $��10q�6�   �� 5&   
   $��6��6   $��Фильтр��6!   $��4��6/   $��Stretch=�6?   $��Stretch=�6[   $'��!/AeroProd;component/Fonts/#Roboto)�6y   $��36(�6�   $��10q�6�   �� 5'   
   -   5         ��Name$ PostBox��5'      $��5��6$   $��0��61   $��Stretch=�6A   $��Stretch=�6]   $��10q�6|   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��24(�6�   �� 5(   
   $��6��6   $)��#Список сотрудников��6!   $��0��6;   $��Stretch=�6K   $��Stretch=�6g   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��36(�6�   $��10q�6�   &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ EmployeeGrid��5)      $��7��6)   $��3��66   $��4��6J   $��10q�6[   $'��!/AeroProd;component/Fonts/#Roboto)�6g   6�   �� 5*   
   -   5        $ Filter��5*      $��3��6#   $��7��63   $��10q�6@   $'��!/AeroProd;component/Fonts/#Roboto)�6L   $��24(�6{   6�   �� 5+   
   -   5         ��Name$ UpdateButton��5+      $��3��6'   $��10��67   $��10q�6E   $��Изменить��6Q   $'��!/AeroProd;component/Fonts/#Roboto)�6d   $��24(�6�   ���#B5D3DA6�   �� 5,   
   -   5        $ 
ExitButton��5,      $��3��6%   $��1��65   $��
Выход��6B   $'��!/AeroProd;component/Fonts/#Roboto)�6R   $��24(�6�   ���#B5D3DA6�   5-      5.      