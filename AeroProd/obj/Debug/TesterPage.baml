   M S B A M L   `   `   `  ����C  ?AeroProd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AeroProdAeroProd  5          AeroProd.TesterPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:AeroProd     5        N� Title$  
TesterPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��733* �6   �� 5      $
��115* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MessageGrid��5      $��0��6)   $��0��66   $��20q�6F   $'��!/AeroProd;component/Fonts/#Roboto)�6R   $��24(�6�   6�   � 5   
   $��0��6   $��3��6    5      �� 5      $
��auto �6    $��61��6.   �� 5      $
��auto �6    .+�5      �� -   5         ��Name$ Message��5      $��1��6'   $��Stretch=�64   $��0��6Q   $'��!/AeroProd;component/Fonts/#Roboto)�6b   $��24(�6�    �� TextWrapping$
 Wrap=�6�    �� 	MaxLength$
 1000��6�   $��20,20,20,-650q�6�   �� 5      -   5        $ NameMessage��5      $��0��6+   $��0��6:   $��
20,20,20,0q�6J   $'��!/AeroProd;component/Fonts/#Roboto)�6^   $��16(�6�   $
 Wrap=�6�   $	 100��6�   5      �� 5   
   -   5         ��Name$ 
FileButton��5      $��0��6%   $��1��65   $��20q�6B   $#��Прикрепить файл��6N   $��22(�6h   ���#B5D3DA6�   �� 5   
   -   5        $ 
LoadButton��5      $��1��6%   $��1��65   $��20q�6B   $��Опубликовать��6N   $��22(�6e   ���#B5D3DA6�   �� 5    
   -   5        $ LoadMessage��5       $��0��6'   $��Stretch=�64   $��1��6Q   $'��!/AeroProd;component/Fonts/#Roboto)�6b   $��24(�6�   $
 Wrap=�6�   $��20q�6�    �� 
IsReadOnly . 6�   �� 5!   
   -   5        $ 
ExitButton��5!      $��2��6%   $��1��65   $��20q�6B   $��
Выход��6N   $'��!/AeroProd;component/Fonts/#Roboto)�6^   $��22(�6�   ���#B5D3DA6�   5"      5#      