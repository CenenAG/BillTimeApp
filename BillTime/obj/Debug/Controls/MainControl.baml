   M S B A M L   `   `   `  ����C  ?BillTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BillTime.ControlsBillTime.Controls  5      #    BillTime.Controls.MainControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BillTime.Controls     5      $��18(�5      
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
Time Entry6M   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��5 5 5 10q�69   .+�5      �� Client6    �� 5      -   5         ��Name$ clientDropDown��5      5      �� 5   
   -   5         ��Name$ hoursStackPanel��5       $ 
Horizontal=�5      $��2��5      $��5 5 5 10q�5      .+�5!      �� $ Vertical=�6   $��0 0 20 0q�60   .+�5"      �� Hours6#   �� 5#      -   5         ��Name$ hoursTextBox��5#      $	��100��60   5$      �� 5%      -   5         ��Name$ operateTime��5%      $
��15 0q�6*   
��� � �
�������.��6y   Start Timer6�   5&      �� 5(   
   -   5        $ titleStackPanel��5+      $ Vertical=�5(      $��3��5)      $��5 5 5 10q�5*      .+�5,      �� Title6   �� 5-      -   5        $ titleTextBox��5-      5.      �� 50   
   -   5        $ descriptionStackPanel��50   K   $ Vertical=�6   $��4��6,   $��5 5 5 10q�69   .+�51      �� Description6%   �� 52      -   5        $ descriptionTextBox��52       �� TextWrapping$
 Wrap=�62    �� AcceptsReturn . $��80��6[   53      �� 56   
   -	   5        $ 
submitForm��56      $��5��6%   $��5 20 5 5q�62   $
��0 20q�6D   .��6l   Submit6t   57      58      