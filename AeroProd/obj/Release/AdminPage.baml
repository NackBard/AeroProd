   M S B A M L   `   `   `  ���� C  ?AeroProd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AeroProdAeroProd      AeroProd.AdminPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:AeroProd       N� Title$  	AdminPage��.���  � ColumnDefinitions �� $
��179* ��� $
��301* � � RowDefinitions �� �� .+�� $��0��$��1�� �� �� �� ��  �� $
��Auto ��� �� $
��Auto �$��72��.+��� $��4��$
��Wrap=�$)��#Список сотрудников��$��Stretch=�$��Stretch=�$'��!/AeroProd;component/Fonts/#Roboto)�$��36(��� -    ��Name$ DeleteEmployeeButton��$��2�����#B5D3DA$��Удалить��$'��!/AeroProd;component/Fonts/#Roboto)�$��22(�$��Stretch=�$��Stretch=��� -   $ AddEmployeeButton��$��2�����#B5D3DA$��1��$��Добавить��$'��!/AeroProd;component/Fonts/#Roboto)�$��22(�$��Stretch=�$��Stretch=��� -   $ UpdateButton��$��2�����#B5D3DA$��2��$��Обновить��$'��!/AeroProd;component/Fonts/#Roboto)�$��22(�$��Stretch=�$��Stretch=��� -   $ ProfileButton��$��2�����#B5D3DA$��3��$)��#Профиль сотрудника��$'��!/AeroProd;component/Fonts/#Roboto)�$��20(�$��Stretch=�$��Stretch=�&   System.Windows.Controls.DataGrid  -     Name$ EmployeeGrid��$��1��$��4��$'��!/AeroProd;component/Fonts/#Roboto)�   
IsReadOnly . � $��1��$��1�� �� ��  �� $
��Auto ��� �� $
��Auto �$��76��.+��� $��0��$
��Wrap=�$-��'Список пользователей��$��Stretch=�$��Stretch=�$��36(�  -   $ UserGrid��$'��!/AeroProd;component/Fonts/#Roboto)�$��1��$��2�� . �� -   $ DeleteUserButton��$��Удалить�����#B5D3DA$'��!/AeroProd;component/Fonts/#Roboto)�$��2��$��0��$��22(�$��Stretch=�$��Stretch=��� -   $ AddUserButton��$��Добавить�����#B5D3DA$'��!/AeroProd;component/Fonts/#Roboto)�$��22(�$��2��$��1��$��Stretch=�$��Stretch=�� $��0��$��0��$��50,50,150,0q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -	   $ UpdateButtonEmployee��$��10�����#B5D3DA$��Изменить��$'��!/AeroProd;component/Fonts/#Roboto)�$��22(�$��Stretch=�$��Stretch=��� -
    ��Name$ PostBox��$��9��$��Stretch=�$��Stretch=�$��0,0,0,10q�$��30(��� $��2��$
��Wrap=�$��Фамилия��$��Stretch=�$��Stretch=�$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� $��8��$
��Wrap=�$��Должность��$��Stretch=�$��Stretch=�$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� $��0��$
��Wrap=�$��Имя��$��Stretch=�$��Stretch=�$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� -    ��Name$ NameBox�� �� TextWrapping$
 Wrap=�$��1��$��30(�$'��!/AeroProd;component/Fonts/#Roboto)�$��Stretch=�$��Stretch=��� -   $ LastNameBox��$
 Wrap=�$��3��$'��!/AeroProd;component/Fonts/#Roboto)�$��30(�$��Stretch=�$��Stretch=��� $��4��$
��Wrap=�$��Отчество��$��Stretch=�$��Stretch=�$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� -   $ PatronymicBox��$
 Wrap=�$��5��$'��!/AeroProd;component/Fonts/#Roboto)�$��30(�$��Stretch=�$��Stretch=�� $��1��$��0��$��50,0,150,100q� ��  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $ LoginBox��$��1��$��Stretch=�$��Stretch=�$
 Wrap=�$'��!/AeroProd;component/Fonts/#Roboto)�$��30(��� -   $ PasswordBox��$��3��$��Stretch=�$��Stretch=�$
 Wrap=�$'��!/AeroProd;component/Fonts/#Roboto)�$��30(�$��0,0,0,10q��� -   $ UpdateButtonUser��$��Изменить�����#B5D3DA$��Stretch=�$��Stretch=�$��8��$'��!/AeroProd;component/Fonts/#Roboto)�$��22(��� $��0��$��Stretch=�$��Stretch=�$
��Wrap=�$��
Логин��$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� $��2��$��Stretch=�$��Stretch=�$
��Wrap=�$��Пароль��$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� $��4��$��Stretch=�$��Stretch=�$
��Wrap=�$#��Уровень доступа��$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� $��6��$��Stretch=�$��Stretch=�$
��Wrap=�$��Сотрудник��$'��!/AeroProd;component/Fonts/#Roboto)�$��20(��� -   $ LevelBox��$��5��$��Stretch=�$��Stretch=�$��0,0,0,10q�$��30(��� -   $ EmployeeBox��$��7��$��Stretch=�$��Stretch=�$��0,0,0,10q�$��30(��� -   $ 
ExitButton��$��
Выход�����#B5D3DA$��	10,0,0,10q�$��22(�$'��!/AeroProd;component/Fonts/#Roboto)�$
��Left=�$	��341��$��66��$��Bottom=�$��1��