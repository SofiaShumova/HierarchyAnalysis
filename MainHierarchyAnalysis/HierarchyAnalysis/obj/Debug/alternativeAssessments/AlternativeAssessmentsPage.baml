   M S B A M L   `   `   `  ����L  HHierarchyAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:HierarchyAnalysis.alternativeAssessments(HierarchyAnalysis.alternativeAssessments  5      I    CHierarchyAnalysis.alternativeAssessments.AlternativeAssessmentsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:HierarchyAnalysis.alternativeAssessments     5      
�������.��5	      � .+�5
   
   ��   �� TabStripPlacement$  Bottom=�6^   $��0,0,0,0q�6y      TabItemMenuStyle#���   6�   ��6   �� *Assessments+ �� SelectedIndex 6:   �� *	IndexMain+ � 	Resources 5       �� 
TargetType �� Property �� Value��%V   '��       �� 5      " ��6   .�5      ��  � ��$ Center=�6<   5      5       �� ContentTemplate 5      �� 5      .R�5      �  � RowDefinitions 5      �� 5      $
��0.2* �6,   �� 5      �� 5      $
��0.1* �6,   .+�5      (� $��0��6"   .��5      �� $��25(�6(   $��Center=�67   $	��Top=�6T   $��0��6l   $��10q�6y   
���   �$$��./Resources/#Montserrat Medium)�6�   �� 5   "   �6&   �� *Criterion.Name+5!      5"      � 5#      $��1��6    5$      �� 5%   "   �� 5&   "   �� 5'   "   $
��0.4* �60    � ColumnDefinitions 5)      �� 5*   "   $��0.05* �63   �� 5+   "   �� 5,   "   $��0.05* �63   .+�5.      (� $��2��6&   $��1��63   $��1��6C   .��5/   "   �� $��
Далее��6�     RoundedButton#���  6�   ��6)   �� 	 �� Path$	 DataContext.NextPage�
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType" >�6�   50      �� 51        lbItemStyleNotBlue#���  6U   $��1��6�   $��2��6�   $��Center=�6�   $��Disabled=�6�     ListBoxWithTextBox#���  6  ��6&   �� *AlternativeAssessments+��52   "   �� 53   &   .R�54   *   A� $��Stretch=�6�   $��Stretch=�6�    A� Rows 66   �� $	 Items.Count�
 �� $ ListBoxL�6�   55   '   ��57   "   �� 58   &   .R�59   *   � $
��0,15q�6/    5:   .   �� 5;   2   $
��0.3* �6C   �� 5<   2   �� 5=   2   $
��0.3* �6C   .+�5?   .   �� 
���   �$$��./Resources/#Montserrat Medium)�6L   $��15(�6x   $��0��6�   $��Center=�6�   $��Center=�6�   ��6�   �� *firstAlternative.Name+6�   �� 5@   .    �� AutoToolTipPlacement$ BottomRight=�66    �� IsSnapToTickEnabled . $��1��6t    � Minimum$	 -10Q�6�    � Maximum$ 10Q�6�    �� TickFrequency$ 1Q�6�   $��Center=�6�    � Value 6�   �� *
Assessment+6�   �� 5A   .   
���   �$$��./Resources/#Montserrat Medium)�6L   $��15(�6x   $��2��6�   $��Center=�6�   $��Center=�6�   ��6�   �� *secondAlternative.Name+6�   5B   +   5C   '   5E      5F      5G      5H      5J      5L      5M      