   M S B A M L   `   `   `  ����L  HHierarchyAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:HierarchyAnalysis.buildingHierarchy#HierarchyAnalysis.buildingHierarchy  5      5    /HierarchyAnalysis.buildingHierarchy.personsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:HierarchyAnalysis.buildingHierarchy     5      
�������.��5	      �   � RowDefinitions  5
   
   �� 5      $
��0.2* �6   �� 5      �� 5      $
��0.1* �6   .+�5   
   (� $��0��6   .��5      �� $��25(�6   $��Center=�6'   $	��Top=�6D   $��0��6\   $��10q�6i   
���   �$$��./Resources/#Montserrat Medium)�6�   $/��)Кто принимает решение?��6�   5      � 5   
   $��1��6     5      �� 5      �� 5      $
��0.2* �6    �� 5      $
��0.2* �6     � ColumnDefinitions 5      �� 5      $
��0.2* �6#   �� 5      �� 5      $
��0.2* �6#   .+�5      (� $��1��6   $��1��6#   .��5      �� -   5         ��Name$ 	addPerson��5      $'��!+ Добавить сторону��6J      RoundedButton#���   6g   ��6,   �� *	AddPerson+6g   5      (� 5       $��2��6   $��1��6#   .��5!      �� $��
Далее��6�   #���   6�   ��6   �� *CompletePersons+��6=   ��  �� ElementName$ 	addPerson�� �� Path$ ActualHeight���6y   �� $ 	addPerson��$ ActualWidth�6�   5"      �� 5#        lbItemStyleNotBlue#���  6   $��1��6p   $��Center=�6�   $��Disabled=�6�     ListBoxWithTextBox#���  6�   ��6P   �� *	Persons+��5)      �� 5*      .R�5+      ��   RoundedTextBox#���  6"   $��50��6K   $	��350��6W   ��6c   �� *Name+5,      5.      5/      50      51      