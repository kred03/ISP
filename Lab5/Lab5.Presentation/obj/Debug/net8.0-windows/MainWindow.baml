   M S B A M L   `   `   `  ����L  HLab5.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab5Lab5  5   	       Lab5.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $localclr-namespace:Lab5     5   	     � Title$  Superheroes Manager��5   	   $	��500��6%   $	��600��62   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��0,0,0,20q�69   .+�5      �� $��Name:��6      TextBlockStyle#��[  6%   �� 5      -   5         ��Name$ NameTextBox��5        TextBoxStyle#��[ 6+   �� 5      $��Alias:��6   #��[  6&   �� 5      -   5        $ AliasTextBox��5      #��[ 6,   �� 5      $��Superpower:��6   #��[  6+   �� 5      -   5        $ SuperpowerTextBox��5      #��[ 61   �� 5      $��Power Level:��6   #��[  6,   �� 5      -   5         ��Name$ PowerLevelComboBox��5        ComboBoxStyle#��[ 63   .@�5      �� $��	Low (25%)��6   
 � Tag$	 Low��63   �� 5      $��Medium (50%)��6   $ Medium��66   �� 5      $��
High (75%)��6   $
 High��64   �� 5      $��Extreme (100%)��6   $ Extreme��68   5      �� 5      $��Superpowers:��6   #��[  6,   �� 5      -   5        $ SuperpowersTextBox��5      #��[ 62   �� 5!      $��Photo:��6   #��[  6&   �� 5"      $ 
Horizontal=�6   .+�5#      �� -   5        $��Choose Photo��5#        ButtonStyle#��[ 6J   �� 5$      -   5         ��Name$ 	HeroImage��5$      $	��100��6+   $	��100��67   $��10,0,0,0q�6D   5%      �� 5'      -   5        $��Add Superhero��5'      #��[ 6H   5(      �� 5*   
   $��1��6   $
��Auto=�6$   .��5+      �� -	   5         ��Name$ HeroesListBox��5+      ��5,      �� 5-      .R�5.      �� $��1q�6!   
������� �� CornerRadius$ 5��6H   	 �� Padding$	 10q�6Y   $��5q�6f   ._�5/      �� .+�50   "   �� $
��Bold"�6B   ��6,   �� *Name+6B   �� 51   "   ��6,   �� *Alias+�� 52   "   -
   5        $��View Details��52   )   $��5q�6m    6Z   �� *Id+6m   �� 54   "   $ 
Horizontal=�6-   .+�55   &   �� -   5        $
��Edit��55   -   $��5q�6k    6X   �� *Id+6k   �� 56   &   -   5        $��Delete��56   -   $��5q�6o    6\   �� *Id+6o   57   #   58      59      5:      5<      5=      �� 5?   
   -   5        
 ��Name$
 FinishEditingButton��5?      $��Finish Editing��6.   $y�	Collapsed=�5@      $��
400,10,0,0q�6(   $	��120��6<   $��30��6H   5B      5C      