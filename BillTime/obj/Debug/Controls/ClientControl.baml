   M S B A M L   `   `   `  ����C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  5      %    BillTime.Controls.ClientControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BillTime.Controls     5      $��18(�5      
�������$��Trebuchet MS)�6@   .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��24(�6   $��0��6"   $��0 0 0 5q�6/   	Clients6I   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��5 5 5 15q�6;   .+�5      �� -   5         ��Name$ clientStackPanel��5   0   $ Vertical=�6   .+�5      �� Client6$   �� 5      -   5         ��Name$ clientDropDown��5      $	��150��63   5      �� 5      -   5         ��Name$ 
editButton��5      $	��5 0q�6)   $	��5 2q�66   $��Bottom=�6D   .��6x   Edit6~   �� 5      -   5        $ 	newButton��5      $��0 0 5 0q�6(   $	��5 2q�69   $��Bottom=�6G   .��6z   New6   5      �� 5"   
   -   5        $ nameStackPanel��5"   K   $ Vertical=�6   $��2��6,   $��5 5 5 15q�69   .+�5#      �� Name6   �� 5$      -   5         ��Name$ nameTextBox��5$      5%      �� 5'   
   -   5        $ emailStackPanel��5'   L   $ Vertical=�6   $��3��6,   $��5 5 5 15q�69   .+�5(      �� Email Address6'   �� 5)      -   5        $ emailTextBox��5)      5*      �� 5,   
   -	   5        $ hourlyRateStackPanel��5,   K   $ Vertical=�6   $��4��6,   $��5 5 5 15q�69   .+�5-      �� 
hourlyRate6$   �� 5.      -
   5        $ hourlyRateTextBox��5.      5/      �� 51   
   -   5        $ checkBoxesStackPanel��51   N   $ 
Horizontal=�6   $��5��6.   $��5 5 5 15q�6;   .+�52      �� -   5         ��Name$ preBillCheckBox��52      $��0 0 10 0q�60   .��6B   Pre-Bill Client6S   �� 53      -   5        $ hasCutOffCheckBox��53      .��62   Cut Off Client6B   54      �� 56   
   -   5        $ cutOffMinimumStackPanel��56   M   $ 
Horizontal=�6   $��6��6.   $��5 5 5 15q�6;   .+�57      �� $ Vertical=�6   $��0 0 10 0q�60   .+�58      �� Cut Off Number6,   �� 59      -   5        $ cutOffTextBox��59      5:      �� 5;      $ Vertical=�6   .+�5<      �� Minimum Hours6+   �� 5=      -   5        $ minimumHoursTextBox��5=      5>      5?      �� 5B   
   -   5        $ incrementsStackPanel��5B   M   $ 
Horizontal=�6   $��7��6.   $��5 5 5 15q�6;   .+�5C      �� $ Vertical=�6   $��0 0 10 0q�60   .+�5D      �� Billing Increment6/   �� 5E      -   5        $ billingIncrementTextBox��5E      5F      �� 5G      $ Vertical=�6   .+�5H      �� Round Up(min.)6,   �� 5I      -   5        $! RoundUpAfterXMinutesTextBox��5I      5J      5K      �� 5M   
   -   5        $ buttonStackPanel��5M   .   $ 
Horizontal=�6   $��8��6H   $��
10 0 10 30q�6U   $��Center=�6i   .+�5N      �� -   5        $ 
cancelForm��5N      $��0 0 10 0q�5P      .��6'   Cancel6/   �� 5Q      -   5        $ 
submitForm��5Q      $��10 0 0 0q�5S      .��6'   Submit6/   5T      5X      5Y      