   M S B A M L   `   `   `  ����C  ?AeroProd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AeroProdAeroProd  5          AeroProd.AdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:AeroProd     5        N� Title$  	AdminPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��179* �6   �� 5      $
��301* �6    � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   � $��0��6   $��1��6    5      �� 5      �� 5      �� 5      �� 5       5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    $��72��6.   .+�5       �� $��4��6   $
��Wrap=�6,   $)��#Список сотрудников��6@   $��Stretch=�6Z   $��Stretch=�6y   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��36(�6�   �� 5!      -   5         ��Name$ DeleteEmployeeButton��5!      $��2��63   ���#B5D3DA$��Удалить��6U   $'��!/AeroProd;component/Fonts/#Roboto)�6h   $��22(�6�   $��Stretch=�6�   $��Stretch=�6�   6�   �� 5"      -   5        $ AddEmployeeButton��5"      $��2��60   ���#B5D3DA$��1��6R   $��Добавить��6b   $'��!/AeroProd;component/Fonts/#Roboto)�6v   $��22(�6�   $��Stretch=�6�   $��Stretch=�6�   6�   �� 5#      -   5        $ UpdateButton��5#      $��2��6+   ���#B5D3DA$��2��6M   $��Обновить��6^   $'��!/AeroProd;component/Fonts/#Roboto)�6r   $��22(�6�   $��Stretch=�6�   $��Stretch=�6�   6�   �� 5$      -   5        $ ProfileButton��5$      $��2��6,   ���#B5D3DA$��3��6N   $)��#Профиль сотрудника��6^   $'��!/AeroProd;component/Fonts/#Roboto)�6|   $��20(�6�   $��Stretch=�6�   $��Stretch=�6�   6�   &   System.Windows.Controls.DataGrid  5%      -   5          Name$ EmployeeGrid��5%      $��1��6-   $��4��6:   $'��!/AeroProd;component/Fonts/#Roboto)�6N      
IsReadOnly . 6�   5&      � 5'   
   $��1��6   $��1��6    5(      �� 5)      �� 5*       5,      �� 5-      $
��Auto �6    �� 5.      �� 5/      $
��Auto �6    $��76��6.   .+�51      �� $��0��6   $
��Wrap=�6%   $-��'Список пользователей��69   $��Stretch=�6U   $��Stretch=�6t   $��36(�6�     52      -   5        $ UserGrid��52      $'��!/AeroProd;component/Fonts/#Roboto)�6*   $��1��6Y   $��2��6f    . 6�   �� 53      -   5        $ DeleteUserButton��53      $��Удалить��6/   ���#B5D3DA$'��!/AeroProd;component/Fonts/#Roboto)�6V   $��2��6�   $��0��6�   $��22(�6�   $��Stretch=�6�   $��Stretch=�6�   6�   �� 54      -   5        $ AddUserButton��54      $��Добавить��6,   ���#B5D3DA$'��!/AeroProd;component/Fonts/#Roboto)�6T   $��22(�6�   $��2��6�   $��1��6�   $��Stretch=�6�   $��Stretch=�6�   6�   55      � 56   
   $��0��6   $��0��6   $��50,50,150,0q�6,    57      �� 58      $
��auto �6    �� 59      $
��auto �6    �� 5:      $
��auto �6    �� 5;      $
��auto �6    �� 5<      $
��auto �6    �� 5=      $
��auto �6    �� 5>      $
��auto �6    �� 5?      $
��auto �6    �� 5@      $
��auto �6    �� 5A      $
��auto �6    �� 5B      $
��auto �6    .+�5D      �� -	   5        $ UpdateButtonEmployee��5D      $��10��63   ���#B5D3DA$��Изменить��6W   $'��!/AeroProd;component/Fonts/#Roboto)�6j   $��22(�6�   $��Stretch=�6�   $��Stretch=�6�   6�   �� 5E      -
   5         ��Name$ PostBox��5E      $��9��6(   $��Stretch=�66   $��Stretch=�6U   $��0,0,0,10q�6q   $��30(�6�   �� 5F      $��2��6   $
��Wrap=�6%   $��Фамилия��69   $��Stretch=�6H   $��Stretch=�6g   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5G      $��8��6   $
��Wrap=�6%   $��Должность��69   $��Stretch=�6J   $��Stretch=�6i   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5H      $��0��6   $
��Wrap=�6&   $��Имя��6:   $��Stretch=�6E   $��Stretch=�6d   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5I      -   5         ��Name$ NameBox��5I       �� TextWrapping$
 Wrap=�6'   $��1��6;   $��30(�6H   $'��!/AeroProd;component/Fonts/#Roboto)�6V   $��Stretch=�6�   $��Stretch=�6�   �� 5J      -   5        $ LastNameBox��5J      $
 Wrap=�6,   $��3��6@   $'��!/AeroProd;component/Fonts/#Roboto)�6M   $��30(�6|   $��Stretch=�6�   $��Stretch=�6�   �� 5K      $��4��6   $
��Wrap=�6%   $��Отчество��69   $��Stretch=�6I   $��Stretch=�6h   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5L      -   5        $ PatronymicBox��5L      $
 Wrap=�6.   $��5��6B   $'��!/AeroProd;component/Fonts/#Roboto)�6O   $��30(�6~   $��Stretch=�6�   $��Stretch=�6�   5M      � 5N   
   $��1��6   $��0��6   $��50,0,150,100q�6,    5O      �� 5P       5R      �� 5S      $
��auto �6    �� 5T      $
��auto �6    �� 5U      $
��auto �6    �� 5V      $
��auto �6    �� 5W      $
��auto �6    �� 5X      $
��auto �6    �� 5Y      $
��auto �6    �� 5Z      $
��auto �6    �� 5[      $
��auto �6    .+�5]      �� -   5        $ LoginBox��5]      $��1��6(   $��Stretch=�66   $��Stretch=�6U   $
 Wrap=�6q   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��30(�6�   �� 5^      -   5        $ PasswordBox��5^      $��3��6+   $��Stretch=�69   $��Stretch=�6X   $
 Wrap=�6u   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��30(�6�   $��0,0,0,10q�6�   �� 5_      -   5        $ UpdateButtonUser��5_      $��Изменить��6/   ���#B5D3DA$��Stretch=�6X   $��Stretch=�6w   $��8��6�   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��22(�6�   6�   �� 5`      $��0��6   $��Stretch=�6&   $��Stretch=�6E   $
��Wrap=�6a   $��
Логин��6u   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5a      $��2��6   $��Stretch=�6&   $��Stretch=�6E   $
��Wrap=�6a   $��Пароль��6u   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5b      $��4��6   $��Stretch=�6&   $��Stretch=�6E   $
��Wrap=�6a   $#��Уровень доступа��6u   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5c      $��6��6   $��Stretch=�6&   $��Stretch=�6E   $
��Wrap=�6a   $��Сотрудник��6u   $'��!/AeroProd;component/Fonts/#Roboto)�6�   $��20(�6�   �� 5d      -   5        $ LevelBox��5d      $��5��6)   $��Stretch=�67   $��Stretch=�6V   $��0,0,0,10q�6r   $��30(�6�   �� 5e      -   5        $ EmployeeBox��5e      $��7��6,   $��Stretch=�6:   $��Stretch=�6Y   $��0,0,0,10q�6u   $��30(�6�   5f      �� 5g   
   -   5        $ 
ExitButton��5g      $��
Выход��6%   ���#B5D3DA$��	10,0,0,10q�6J   $��22(�6]   $'��!/AeroProd;component/Fonts/#Roboto)�6k   $
��Left=�6�   $	��341��6�   $��66��6�   $��Bottom=�6�   $��1��6�   6�   5h      5i      