   M S B A M L   `   `   `  ����C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  5      #    BillTime.Controls.WorkControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BillTime.Controls     5      $��18(�5      
�������$��Trebuchet MS)�6@   .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��24(�6   $��0��6"   $��0 0 0 15q�6/   Client Work6N   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��5 5 5 10q�69   .+�5      �� Client6    �� 5      -   5         ��Name$ clientDropDown��5      6/   5      �� 5      -   5         ��Name$ dateStackPanel��5   O   $ Vertical=�6   $��2��60   $��5 5 5 15q�6=   .+�5       �� Date6"   �� 5!      -   5        $ datetDropDown��5!      63   5"      �� 5%   
   -   5        $ hoursStackPanel��5(      $ Vertical=�5%      $��3��5&      $��5 5 5 15q�5'      .+�5)      �� Hours6   �� 5*      -   5         ��Name$ hoursTextBox��5*      5+      �� 5.   
   -   5        $ titleStackPanel��51      $ Vertical=�5.      $��4��5/      $��5 5 5 10q�50      .+�52      �� Title6   �� 53      -   5        $ titleTextBox��53      54      �� 56   
   -   5        $ descriptionStackPanel��59      $ Vertical=�56      $��5��57      $��5 5 5 10q�58      .+�5:      �� Description6%   �� 5;      -	   5        $ descriptionTextBox��5;       �� TextWrapping$
 Wrap=�62    �� AcceptsReturn . $��80��6[   5<      �� 5?   
   -
   5        $ paidStackPanel��5B      $ 
Horizontal=�5?      $��6��5@      $��5 5 5 10q�5A      .+�5C      �� -   5         ��Name$ paidCheckBox��5C      $��0 0 10 0q�6-   $��Bottom=�6?   .��6u   Paid5E      �� 5F      -   5        $ paymentStackPanel��5G      $ Vertical=�5F      .+�5H      �� 	Payment6%   �� 5I      -   5        $ paymentDropDown��5I      $	��200��64   5J      5K      �� 5N   
   -   5         ��Name$ 
submitForm��5N      $��7��6%   $��5 5 5 10q�62   .��6]   Submit6e   5O      5P      