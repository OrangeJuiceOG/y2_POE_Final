   M S B A M L   `   `   `  ����[  WPersonalBudgetPlannerGUI20117048, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PersonalBudgetPlannerGUI20117048 PersonalBudgetPlannerGUI20117048  5   	   7    1PersonalBudgetPlannerGUI20117048.CreateLoadReport   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PersonalBudgetPlannerGUI20117048     5   	     � Title$  Create / Load Report��5   	   $	��450��6&   $	��800��63    � WindowStartupLocation$ CenterScreen=�6?    � Icon$ 	/logo.png��6d   ��5	      �� 5
   
    �� ImageSource$ /backImg3.png��6   .��5      � -   5         �Name$ createLoadMainGrid��5      .+�5   
   �� -   5         ��Name$ headerLabel��5      $��Personal Budget Planner��6%   $��Center=�6G   $��0,61,0,0q�6d   $	��Top=�6v   $
��Bold"�6�   $��36(�6�   �� 5   
   -   5         ��Name$ createReportButton��5      $��Create new report��6-   $��Center=�6I   $��	0,152,0,0q�6f   $	��Top=�6y   $	��230��6�   $��38��6�   ���	#FF393E46���	#FFEEEEEE$��16(�6�   $
��Bold"�6  $��1��6   � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%^   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 8��65   5      5      5      �� 5   
   -   5        $ loadReportButton��5      $��Load / edit saved report��6+   $��Center=�6N   $��	0,247,0,0q�6k   $	��Top=�6~   $	��230��6�   $��40��6�   ���	#FF393E46���	#FFEEEEEE$��16(�6�   $
��Bold"�6  $��3��6   5      ��%^   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 8��65   5      5      5      �� 5   
   -   5         ��Name$ loadCombobox��5      $��Center=�6)   $��	0,219,0,0q�6F   $	��Top=�6Y   $	��230��6q   $��2��6}   �� 5   
   -   5        $ 	infoLabel��5      $2��,( saved reports will refresh automatically )��6#   $��Center=�6Z   $��	0,292,0,0q�6w   $	��Top=�6�   �� 5   
   -   5        $ openUserManualLabel��5      $.��(For more info please see the User Manual��6-   $
��Left=�6`   $��222,334,0,0q�6{   $	��Top=�6�   $	��230��6�   �� 5   
   -   5        $ openUMButton��5      $��View User Manual��6'   $
��Left=�6B   $��458,336,0,0q�6]   $	��Top=�6r   $��24��6�   $	��117��6�   $��4��6�   ���	#FF393E46���	#FFEEEEEE 5       ��%^   '��       �� 5!      " ��6   .�5"      �� 	 �@��CornerRadius$
 8��65   5#      5$      5%      5'       5(      ��%_   '��       �� 5)   
   " ��6   .�5*      �� 	 �@��CornerRadius$
 12��6-   5+      5,      5-      