   M S B A M L   `   `   `  ���� C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  #    BillTime.Controls.WorkControl   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:BillTime.Controls     $��18(�
�������$��Trebuchet MS)�.���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $��24(�$��0��$��0 0 0 15q�Client Work��  �� Orientation$ Vertical=�$��1��$��5 5 5 10q�.+��� Client�� -    ��Name$ clientDropDown���� -    ��Name$ dateStackPanel��$ Vertical=�$��2��$��5 5 5 15q�.+��� Date�� -   $ datetDropDown���� -   $ hoursStackPanel��$ Vertical=�$��3��$��5 5 5 15q�.+��� Hours�� -    ��Name$ hoursTextBox���� -   $ titleStackPanel��$ Vertical=�$��4��$��5 5 5 10q�.+��� Title�� -   $ titleTextBox���� -   $ descriptionStackPanel��$ Vertical=�$��5��$��5 5 5 10q�.+��� Description�� -	   $ descriptionTextBox�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��80���� -
   $ paidStackPanel��$ 
Horizontal=�$��6��$��5 5 5 10q�.+��� -    ��Name$ paidCheckBox��$��0 0 10 0q�$��Bottom=�.��Paid�� -   $ paymentStackPanel��$ Vertical=�.+��� 	Payment�� -   $ paymentDropDown��$	��200���� -    ��Name$ 
submitForm��$��7��$��5 5 5 10q�.��Submit