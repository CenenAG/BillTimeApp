   M S B A M L   `   `   `  ���� C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  #    BillTime.Controls.MainControl   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:BillTime.Controls     $��18(�
�������$��Trebuchet MS)�.���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $��24(�$��0��$��0 0 0 15q�
Time Entry��  �� Orientation$ Vertical=�$��1��$��5 5 5 10q�.+��� Client�� -    ��Name$ clientDropDown���� -    ��Name$ hoursStackPanel��$ 
Horizontal=�$��2��$��5 5 5 10q�.+��� $ Vertical=�$��0 0 20 0q�.+��� Hours�� -    ��Name$ hoursTextBox��$	��100���� -    ��Name$ operateTime��$
��15 0q�
��� � �
�������.��Start Timer�� -   $ titleStackPanel��$ Vertical=�$��3��$��5 5 5 10q�.+��� Title�� -   $ titleTextBox���� -   $ descriptionStackPanel��$ Vertical=�$��4��$��5 5 5 10q�.+��� Description�� -   $ descriptionTextBox�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��80���� -	   $ 
submitForm��$��5��$��5 20 5 5q�$
��0 20q�.��Submit