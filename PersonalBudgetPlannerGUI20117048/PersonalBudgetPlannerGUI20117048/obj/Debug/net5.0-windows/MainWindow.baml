   M S B A M L   `   `   `  ����[  WPersonalBudgetPlannerGUI20117048, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PersonalBudgetPlannerGUI20117048 PersonalBudgetPlannerGUI20117048  5   	   1    +PersonalBudgetPlannerGUI20117048.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:PersonalBudgetPlannerGUI20117048     5   	     � Title$  PBP Sign In��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66   ���	#FFAAD8D3 � Icon$ 	/logo.png��6r   .��5	      � ��5
   
   �� 5       �� ImageSource$ /backImg.jpg��6   .+�5   
   �� $��Personal Budget Planner��6   $
��Left=�62   $��
191,52,0,0q�6M   $	��Top=�6a   $
��Bold"�6y   $��36(�6�   �� 5   
   -   5         ��Name$ usernameText��5      $
��Left=�6(    �� TextWrapping$
 Wrap=�6C   $	��Top=�6W   $	��120��6o   $��383,232,0,0q�6{   ���	#FFEEEEEE$��1��6�   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   $��383,264,0,0q�6F   $	��Top=�6[   $	��120��6s   ���	#FFEEEEEE$��2��6�   �� 5   
   -   5        $��Sign In��5      $��Center=�6#   $��	0,308,0,0q�6@   $	��Top=�6S   $��22��6�   $��62��6�   ���	#FF393E46���	#FFEEEEEE$
��Bold"�6�   $��3��6�    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%^   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 5��65   5      5      5      �� 5   
   -   5         ��Name$ creatorLabel��5      $��20117048��6&   $��Center=�69   $��	0,115,0,0q�6V   $	��Top=�6i   $
��Bold"�6�   �� 5   
   -   5        $ 
infoLabel1��5      $8��2Please enter your username and password to sign in��6$   $
��Left=�6a   $��261,177,0,0q�6|   $	��Top=�6�   �� 5   
   -   5        $ 
infoLabel2��5      $4��.( default username = admin, password = admin )��6$   $
��Left=�6]   $��291,203,0,0q�6x   $	��Top=�6�   $��10(�6�   �� 5   
   -   5        $ invalidCredLabel��5      $��-��6*   $��Center=�66   $��	0,335,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ usernameLabel��5      $��
Username :��6'   $
��Left=�6<   $��299,227,0,0q�6W   $	��Top=�6l    J� RenderTransformOrigin$ 0.507,0.228&�6�   $
��Bold"�6�   �� 5   
   -	   5        $ passwordLabel��5      $��
Password :��6'   $
��Left=�6<   $��299,260,0,0q�6W   $	��Top=�6l   $ 0.507,0.228&�6�   $
��Bold"�6�   5       5      ��%_   '��       �� 5   
   " ��6   .�5       �� 	 �@��CornerRadius$
 12��6-   5!      5"      5#      