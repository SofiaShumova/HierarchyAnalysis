   M S B A M L   `   `   `  ����L  HHierarchyAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HierarchyAnalysisHierarchyAnalysis  5   	   "    HierarchyAnalysis.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HierarchyAnalysis     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      $��0.05* �6   6-   �� 5      6   �� 5      $
��0.1* �6   6,   �� 5      $
��0.1* �6   .+�5   
   �� $��0��6   $��3��6!   
���   �$��0,0,1,0q�6F   �� 5   
   -   5         ��Name$ mainMenu��5      $��0��6$   $��3��61   $��Disabled=�5      $��Disabled=�6C   $��Center=�5      $��Stretch=�6-   $��Stretch=�6R   $��0,0,1,0q�5      
���   ���5   B   �� *items+{�5   @   �� *EnabledMenu+ �� SelectedIndex 6b   �� *SelectedIndexMenu+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � {� �� Value 62   �� *IsEnabledItem+ �� Triggers 5      P� 5       	 P� Property	 � {�
 P� Value
 .  . �5!      ��  � ��
 �����6;   5"      5$      ��5&      �� 5'      .R�5(      A� $��Stretch=�6z    A� Rows 6"   ��  �� Path$ Items.Count� �� RelativeSource ��  �� AncestorType$ ListBoxL�6z   5)      ��5+      �� 5,      .R�5-      �� 
�������$��0q�6K   $��0q�6V   $��0q�6c   
���������6   �� *Action+��5.      �� 5/      " ��6$    50   "   P� 51   &   	 � {�
 .  . �52   *   ��  � ��
 �����6G   53   '   55      .��57      �� $��20q�6!   ��6-   �� *	ImagePath+59      5:      5<      5>      �� 5?   
   -   5         ��Name$ mainContent��5?      $��30q�6N   $��0��6Z   $��1��6g   $��3��6w   ��6.   �� *CurrentPage+6w   �� 5@   
   $��1��6   $��3��6!   $
��Test��6.   ��6=   �� *Test+5A      5B      