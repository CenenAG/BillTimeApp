   M S B A M L   `   `   `  ����C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  5      '    !BillTime.Controls.PaymentsControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BillTime.Controls     5      $��18(�5      
�������$��Trebuchet MS)�6@   .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��24(�6   $��0��6"   $��0 0 0 15q�6/   
Payments6K   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��5 5 5 10q�69   .+�5      �� Client6    �� 5      -   5         ��Name$ clientDropDown��5      6/   5      �� 5   
   -   5         ��Name$ selectionStackPanel��5   M   $ 
Horizontal=�6   $��2��6.   $��5 5 5 15q�6;   .+�5      �� -   5        $ dateStackPanel��5   0   $ Vertical=�6   .+�5       �� Date6"   �� 5!      -   5        $ datetDropDown��5!      $	��150��62   $��0 0 10 0q�6>   6P   5"      �� 5#      -   5         ��Name$ orTextBlock��5#   3   $��Bottom=�6   -Or-6N   �� 5$      -   5         ��Name$ 	newButton��5$      $��10 0 5 0q�6(   $	��5 2q�6:   $��Bottom=�6H   .��6{   New6�   5%      �� 5(   
   -   5        $ amountStackPanel��5+      $ Vertical=�5(      $��3��5)      $��5 5 5 15q�5*      .+�5,      �� Amount6    �� 5-      -   5         ��Name$ amountTextBox��5-      $
��26.9��5.      5/      �� 52   
   -	   5        $ hoursStackPanel��52   K   $ Vertical=�6   $��4��6,   $��5 5 5 15q�69   .+�53      �� Hours6   �� 54      -
   5        $ hoursTextBox��54      $
��26.9��55      56      �� 59   
   -   5        $ buttonStackPanel��5:      $ 
Horizontal=�59      $��5��5;      $��
10 0 10 30q�5<      $��Center=�5=      .+�5>      �� -   5        $ 
cancelForm��5>      $��0 0 10 0q�5?      .��6'   Cancel6/   �� 5@      -   5        $ 
submitForm��5@      $��10 0 0 0q�5A      .��6'   Submit6/   5B      5D      5E      