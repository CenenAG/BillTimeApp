   M S B A M L   `   `   `  ���� C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  %    BillTime.Controls.ClientControl   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:BillTime.Controls     $��18(�
�������$��Trebuchet MS)�.���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $��24(�$��0��$��0 0 0 5q�	Clients��  �� Orientation$ 
Horizontal=�$��1��$��5 5 5 15q�.+��� -    ��Name$ clientStackPanel��$ Vertical=�.+��� Client�� -    ��Name$ clientDropDown��$	��150���� -    ��Name$ 
editButton��$	��5 0q�$	��5 2q�$��Bottom=�.��Edit�� -   $ 	newButton��$��0 0 5 0q�$	��5 2q�$��Bottom=�.��New�� -   $ nameStackPanel��$ Vertical=�$��2��$��5 5 5 15q�.+��� Name�� -    ��Name$ nameTextBox���� -   $ emailStackPanel��$ Vertical=�$��3��$��5 5 5 15q�.+��� Email Address�� -   $ emailTextBox���� -	   $ hourlyRateStackPanel��$ Vertical=�$��4��$��5 5 5 15q�.+��� 
hourlyRate�� -
   $ hourlyRateTextBox���� -   $ checkBoxesStackPanel��$ 
Horizontal=�$��5��$��5 5 5 15q�.+��� -    ��Name$ preBillCheckBox��$��0 0 10 0q�.��Pre-Bill Client�� -   $ hasCutOffCheckBox��.��Cut Off Client�� -   $ cutOffMinimumStackPanel��$ 
Horizontal=�$��6��$��5 5 5 15q�.+��� $ Vertical=�$��0 0 10 0q�.+��� Cut Off Number�� -   $ cutOffTextBox���� $ Vertical=�.+��� Minimum Hours�� -   $ minimumHoursTextBox���� -   $ incrementsStackPanel��$ 
Horizontal=�$��7��$��5 5 5 15q�.+��� $ Vertical=�$��0 0 10 0q�.+��� Billing Increment�� -   $ billingIncrementTextBox���� $ Vertical=�.+��� Round Up(min.)�� -   $! RoundUpAfterXMinutesTextBox���� -   $ buttonStackPanel��$ 
Horizontal=�$��8��$��
10 0 10 30q�$��Center=�.+��� -   $ 
cancelForm��$��0 0 10 0q�.��Cancel�� -   $ 
submitForm��$��10 0 0 0q�.��Submit