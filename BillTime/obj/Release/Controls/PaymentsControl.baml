   M S B A M L   `   `   `  ���� C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  '    !BillTime.Controls.PaymentsControl   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:BillTime.Controls     $��18(�
�������$��Trebuchet MS)�.���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $��24(�$��0��$��0 0 0 15q�
Payments��  �� Orientation$ Vertical=�$��1��$��5 5 5 10q�.+��� Client�� -    ��Name$ clientDropDown���� -    ��Name$ selectionStackPanel��$ 
Horizontal=�$��2��$��5 5 5 15q�.+��� -   $ dateStackPanel��$ Vertical=�.+��� Date�� -   $ datetDropDown��$	��150��$��0 0 10 0q��� -    ��Name$ orTextBlock��$��Bottom=�-Or-�� -    ��Name$ 	newButton��$��10 0 5 0q�$	��5 2q�$��Bottom=�.��New�� -   $ amountStackPanel��$ Vertical=�$��3��$��5 5 5 15q�.+��� Amount�� -    ��Name$ amountTextBox��$
��26.9���� -	   $ hoursStackPanel��$ Vertical=�$��4��$��5 5 5 15q�.+��� Hours�� -
   $ hoursTextBox��$
��26.9���� -   $ buttonStackPanel��$ 
Horizontal=�$��5��$��
10 0 10 30q�$��Center=�.+��� -   $ 
cancelForm��$��0 0 10 0q�.��Cancel�� -   $ 
submitForm��$��10 0 0 0q�.��Submit