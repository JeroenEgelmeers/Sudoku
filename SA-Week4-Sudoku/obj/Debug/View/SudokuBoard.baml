   M S B A M L   `   `   `  ����  SA-Week4-Sudoku&     SA_Week4_Sudoku.View.SudokuBoard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $��Stretch=�5      $��Stretch=�5      $��Stretch=�5      $��Stretch=�5      
���   ���5	      ��   �� RelativeSource  �� *Self+ �� Path$ ActualHeight� � 	Resources 5
   
      CellTemplate ��Name � ContextMenu �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� SelectedItem �� Mode � DataContext �� Triggers �� Value �� Binding �� 
TargetName  InnerGridRowTemplate A� Rows  InnerGridTemplate A� Columns  OuterRowTemplate��%  &	        &	 �    7   &	 �    7  &	 H    7  �� 5      .R�5      �� $ Border��6   
���iii�$��2q�6A   ���	#00112233._�5      �� |�.  $��Center=�63   $��Center=�6Q   $
��Bold"�6m   $��16(�6�   ��6�   �� $ Value�5       5      �� 5      ��5      �� 5   "   " m�6(   .�5   &   ��  � �� 5   *   �� 5   .   " m�6>   .R�5   2   �� $	 Header��6C   $��Header��6S   ��. 6j   5   /   5   '   5   #   .@�5      �� $��0q�6&   $��35��6:   $��0q�6F   $��Stretch=�6�   $��Stretch=�6�   
 6R   �� $ Value�$ TwoWay=� 6�   ��   �� *TemplatedParent+$ DataContext���6  �� $ PossibleValues�5      5       5       �� 5!      $ False��6;    6   �� *	IsValid+.a�5"      �� $ Border��6    � ��
 �  ��6I   5#      �� 5$      $
 True��6<    6   �� *
ReadOnly+.a�5%      �� $ Border��6    � ��
 � � �6I   �� 5&      $ Border��6    6I   Z�  �@�ContextMenu5'      5)      �� 5*      .R�5+      �� 8��  ��6M   �� ��5,      �� 5-      .R�5.      A� $ 1��6*   5/      51      52      �� 53      .R�54      �� 
���   �$��3q�6.   ._�55      �� 8��  ��6#   �� $ GridRows���56      �� 57      .R�58   "   A� $ 1��6.   59      5;      5<      5=      �� 5>      .R�5?      �� 8��  ��6   �� ��5@      �� 5A      .R�5B      A� $ 1��6*   5C      5E      5F      5H      .��5I   
   �� -   5         ��Name$ MainList��5I   q   #��[ 6   ��6J   �� $ GridRows���5J      �� 5K      .R�5L      A� $ 1��6"   5M      5O      5P      