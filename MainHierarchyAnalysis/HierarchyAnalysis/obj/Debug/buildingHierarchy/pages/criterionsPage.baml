   M S B A M L   `   `   `  ����L  HHierarchyAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:HierarchyAnalysis.buildingHierarchy#HierarchyAnalysis.buildingHierarchy  5      8    2HierarchyAnalysis.buildingHierarchy.criterionsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:HierarchyAnalysis.buildingHierarchy     5      
�������.��5	      �   � RowDefinitions  5
   
   �� 5      $
��0.2* �6   �� 5      �� 5      $
��0.1* �6   .+�5   
   (� $��0��6   .��5      �� $��25(�6   $��Center=�6'   $	��Top=�6D   $��0��6\   $��10q�6i   
���   �$$��./Resources/#Montserrat Medium)�6�   $;��5Введите критерии оценивания:��6�   5      � 5   
   $��1��6     5      �� 5      �� 5      $
��0.2* �6    �� 5      $
��0.2* �6     � ColumnDefinitions 5      �� 5      $
��0.2* �6#   �� 5      �� 5      $
��0.2* �6#   .+�5      (� $��1��6   $��1��6#   .��5      �� -   5         ��Name$ 	buttonTop��5      $)��#+ Добавить критерий��6M   $��150,20q�6k      RoundedButton#���   6|   ��6,   �� *AddCriterion+6|   5      (� 5       $��2��6   $��1��6#   .��5!      �� $��
Далее��6�   #���   6�   ��6   ��  �� ElementName$ 	buttonTop�� �� Path$ ActualHeight���6U   �� $ 	buttonTop��$ ActualWidth���6�   �� *CompleteCriterions+6�   5"      �� 5#        lbItemStyleNotBlue#���  6   $��1��6s   $��Center=�6�   $��Disabled=�6�     ListBoxWithTextBox#���  6�   ��6P   �� *
Criterions+��5$      �� 5%      .R�5&      A� $��Stretch=�6~   $��Stretch=�6�    A� Rows 6&   �� $ Items.Count� �� RelativeSource ��  �� AncestorType$ ListBoxL�6�   5'      ��5)      �� 5*      .R�5+      ��   RoundedTextBox#���  6"   $��50��6L   $	��350��6X   ��6d   �� *Name+5,      5.      5/      50      51      