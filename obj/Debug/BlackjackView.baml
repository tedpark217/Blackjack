   M S B A M L   `   `   `  ����D  @Blackjack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Blackjack.ViewModelsBlackjack.ViewModels  5   	   #    Blackjack.Views.BlackjackView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Blackjack.ViewModels     5   	     � DataContext  5      &    Blackjack.ViewModels.BlackjackVM  5   
   ��5      �� 5   
    j� 
AlignmentY$	 Top=�6    �� ImageSource$ \Resource\IMG\bg.jpg��6&    j� Stretch$ UniformToFill=�6I    � 	Resources 5       �� Source�� 5   
   $! /Resource/ResourceDict.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5"   
   �� $��0��6   $��0��6$   $��Center=�64   $��Center=�6Q   
������ $��0q�6�   ��6l   �� *PlayerCards+��5#      �� 5$      .R�5%      � 5&      5(      �� 5*   
   $��0��6   $��1��6$   $��Center=�64   $��Center=�6Q   
������ $��0q�6�   ��6l   �� *DealerCards+��5+      �� 5,      .R�5-      � 5.      50      �� 52   
   $��1��6   $��0��6&   $��2��66   $��Center=�6K   $	��Top=�6h   .��53      �� $��Bahnschrift)�6Z   $��50(�6s   $��Center=�6�   $��Center=�6�   
���������6   ��  �� Path$ Result�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   54      �� 56   
   $��1��6   $��0��6&   $��Center=�66   $��Center=�6S   .��57      ��    	PointText#��[  6_   ��6   �� $ PlayerPoint�$	 PropertyChanged=�6_   58      �� 5:   
   $��1��6   $��1��6&   $��Center=�66   $��Center=�6S   .��5;      �� #��[  6_   ��6   �� $ DealerPoint�$	 PropertyChanged=�6_   5<      � 5>   
   $��2��6   $��0��6!   $��Center=�61   $��Center=�6N   .+�5?      �� -   5        $��	HitButton��5?   :     RoundButton#��[ 6   ���	#FF5BE05B$��50��5@      $	��100��6   $��20,20,20,20q�6   $��Bottom=�5A      $	��Hit��5B      
���   ���5@   4   �� *
HitCommand+5B      �� 5C      -   5        $��StandButton��5C   :   #��[ 6   ���	#FFFB6A6A$��Bottom=�5D      $��50��6"   $	��100��6.   $��2��6:   $��20,20,20,20q�6J   $��Stand��5E      
���   ���5D   _   �� *StandCommand+5E      5F      � 5H   
   $��2��6   $��1��6!   $��Center=�61   $��Center=�6N   .+�5I      �� -   5        $��StartButton��5I   :   #��[ 6   
����·�$��50��5J      $	��100��6   $��1��6   $��20,20,20,20q�6/   $	��Top=�5K      $��Start��6   
���   ���5J   D   �� *StartCommand+5K   /   �� 5M      -   5        $��ResetButton��5M   :   #��[ 6   
�������$��50��5N      $	��100��6   $��1��6   $��20,20,20,20q�6/   $	��Top=�5O      $��Reset��6   
���   ���5N   D   �� *ResetCommand+5O   /   5P      5Q      5R      