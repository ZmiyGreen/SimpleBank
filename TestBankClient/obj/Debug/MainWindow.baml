   M S B A M L   `   `   `  ����I  ETestBankClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestBankClientTestBankClient  5   	       TestBankClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TestBankClient     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1000��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��ClientInfoemationGrid��5
      $
��Left=�60   $	��700��6K   $��
324,30,0,0q�6X   $	��Top=�6l   $	��562��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6I      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ 
FamilyName�6Z     5      $ Имя��6H   $ 80 6U    6%   �� $ 	FirstName�6U     5      $ Отчество��6G   $ 80 6Y    6%   �� $ LastName�6Y     5      $ Дата рождения��6C   $	 100 6Z    6%   �� $
 Date�6Z     5      $ Email��6K   $	 100 6Z    6%   �� $ ContactEmail�6Z     5      $# Активные вклады��6O   $	 120 6h    6%   �� $ NumberOfAccounts�6h   5      �� 5   
   -   5        $��
ShowButton��5      $.��(Вывести всех клиентов��6#   $
��Left=�6C   $��	27,30,0,0q�6^   $	��Top=�6q   $	��150��6�   6�   �� 5   
   -   5        $��NewClientButton��5      $��Новый клиент��6(   $
��Left=�6?   $��	27,60,0,0q�6Z   $	��Top=�6m   $	��150��6�   6�   �� 5   
   -   5        $��SelectButton��5      $#��Выбрать клиента��6%   $
��Left=�6?   $��	27,90,0,0q�6Z   $	��Top=�6m   $	��150��6�   6�   �� 5   
   -   5        $��	DBOptions��5      $��Настройки��6"   $
��Left=�66   $��
27,126,0,0q�6Q   $	��Top=�6e   $	��150��6}   6�   5      5      