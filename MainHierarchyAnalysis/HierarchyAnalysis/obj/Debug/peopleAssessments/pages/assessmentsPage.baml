   M S B A M L   `   `   `  ����L  HHierarchyAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:HierarchyAnalysis.peopleAssessments.pages)HierarchyAnalysis.peopleAssessments.pages  5      ?    9HierarchyAnalysis.peopleAssessments.pages.assessmentsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:HierarchyAnalysis.peopleAssessments.pages     5      
�������.��5
   
   �   � RowDefinitions  5      �� 5      $
��0.2* �6    �� 5      �� 5      $
��0.1* �6    .+�5      (� $��0��6   .��5      �� $��25(�6   $��Center=�6+   $	��Top=�6H   $��0��6`   $��10q�6m   
���   �$$��./Resources/#Montserrat Medium)�6�   $e��_Кто оказывает большее влияние на развитие сценария?��5      5      � 5      $��1��6     5      �� 5      �� 5      �� 5      $
��0.4* �6$    � ColumnDefinitions 5      �� 5      $��0.05* �6'   �� 5      �� 5      $��0.05* �6'   .+�5       (� $��2��6   $��1��6'   $��1��67   .��5!      �� $��
Далее��6A      RoundedButton#���   6Q   ��6   �� *CompleteAssessment+6Q   5"      �� 5#        lbItemStyleNotBlue#���  6>   $��1��6y   $��2��6�   $��Center=�6�   $��Disabled=�6�     ListBoxWithTextBox#���  6�   ��6   �� *Assessments+��5$      �� 5%      .R�5&      A� $��Stretch=�6�   $��Stretch=�6�    A� Rows 6*   ��  �� Path$ Items.Count� �� RelativeSource ��  �� AncestorType$ ListBoxL�6�   5'      ��5)      �� 5*      .R�5+      � $
��0,15q�6    5,      �� 5-   "   $
��0.3* �63   �� 5.   "   �� 5/   "   $
��0.3* �63   .+�51      �� 
���   �$$��./Resources/#Montserrat Medium)�6<   $��20(�6h   $��0��6v   $��Center=�6�   $��Center=�6�   ��6�   �� *firstPerson.Name+6�   �� 52       �� AutoToolTipPlacement$ BottomRight=�6%    �� IsSnapToTickEnabled . $��1��6c    � Minimum$	 -10Q�6s   	 � Maximum$	 10Q�6�   
 �� TickFrequency$
 1Q�6�   $��Center=�6�    � Value 6�   �� *
Assessment+6�   �� 53      
���   �$$��./Resources/#Montserrat Medium)�6<   $��20(�6h   $��2��6w   $��Center=�6�   $��Center=�6�   ��6�   �� *secondPerson.Name+6�   54      57      59      5:      5;      5<      