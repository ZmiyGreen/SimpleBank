   M S B A M L   `   `   `  ���� I  ETestBankClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestBankClientTestBankClient  #    TestBankClient.TransferWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:TestBankClient       � Title$"  Клиент и вклады��$	��450��$	��800��.��� .+��� $
��Left=�$��	50,26,0,0q�$
��Wrap=�$>��8Перевод между счемами клиента:��$	��Top=��� $
��Left=�$��
397,26,0,0q�$
��Wrap=�$6��0Перевести по номеру счета:��$	��Top=��� $
��Left=�$��	50,47,0,0q�$
��Wrap=�$"��Выбранный счет:��$	��Top=��� $
��Left=�$��
50,116,0,0q�$
��Wrap=�$#��Счет начисления��$	��Top=��� -   $��FromAccountBox��$
��Left=�$��	50,68,0,0q�$	��Top=�$	��140���� -   $��ToAccountBox��$
��Left=�$��
50,137,0,0q�$	��Top=�$	��140���� -   $��AccountCodeBox��$
��Left=�$��23��$��
397,67,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��120��&   System.Windows.Controls.DataGrid  -   $��AccountGrid��$
��Left=�$	��200��$��
50,198,0,0q�$	��Top=�$	��300��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Номер счета��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ AccountCode�  $ Размер вклада��$	 100  �� $ 
MoneyValue�  $ Валюта��$ 80  �� $
 Sign��� -   $��CodeTransferButton��$5��/Перевести по номеру счета��$
��Left=�$��397,112,0,0q�$	��Top=�$	��180���� -   $��SelfTransferButton��$2��,Перевести между счетами��$
��Left=�$��
50,173,0,0q�$	��Top=�$	��189���� $
��Left=�$��397,198,0,0q�$
��Wrap=�$��Новый вклад:��$	��Top=��� -   $��OpenAccountButton��$��Открыть вклад��$
��Left=�$��397,286,0,0q�$	��Top=�$	��100���� -   $��CloseAccountButton��$��Закрыть вклад��$
��Left=�$��397,311,0,0q�$	��Top=�$	��100���� $
��Left=�$��397,232,0,0q�$
��Wrap=�$��Номер счета:��$	��Top=��� -	   $��AccountInputCodebox��$
��Left=�$��23��$��489,225,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� $
��Left=�$��397,265,0,0q�$
��Wrap=�$��Валюта:��$	��Top=��� -
   $��CurrencyBox��$
��Left=�$��489,259,0,0q�$	��Top=�$	��120���� -   $��OkButton��$%��Завершить работу��$
��Left=�$��
633,22,0,0q�$	��Top=�$	��120���� -   $��MoneyValueBox��$
��Left=�$��23��$��
239,68,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� $
��Left=�$��
239,47,0,0q�$
��Wrap=�$"��Денежная сумма:��$	��Top=��� -   $��DepositButton��$ ��Внести на счет��$
��Left=�$��239,139,0,0q�$	��Top=�$	��111��