   M S B A M L   `   `   `  ���� I  ETestBankClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestBankClientTestBankClient      TestBankClient.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:TestBankClient       � Title$  
MainWindow��$	��800��$
��1000��.��� .+�&   System.Windows.Controls.DataGrid  -   $��ClientInfoemationGrid��$
��Left=�$	��700��$��
324,30,0,0q�$	��Top=�$	��562��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ 
FamilyName�  $ Имя��$ 80  �� $ 	FirstName�  $ Отчество��$ 80  �� $ LastName�  $ Дата рождения��$	 100  �� $
 Date�  $ Email��$	 100  �� $ ContactEmail�  $# Активные вклады��$	 120  �� $ NumberOfAccounts��� -   $��
ShowButton��$.��(Вывести всех клиентов��$
��Left=�$��	27,30,0,0q�$	��Top=�$	��150���� -   $��NewClientButton��$��Новый клиент��$
��Left=�$��	27,60,0,0q�$	��Top=�$	��150���� -   $��SelectButton��$#��Выбрать клиента��$
��Left=�$��	27,90,0,0q�$	��Top=�$	��150���� -   $��	DBOptions��$��Настройки��$
��Left=�$��
27,126,0,0q�$	��Top=�$	��150��