   M S B A M L   `   `   `  ����D  @Blackjack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Blackjack.ViewsBlackjack.Views  5      3clr-namespace:Blackjack.ModelsBlackjack.Models  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089*    $Blackjack.Views.CardToBrushConverter   CardToBrushConverter  	PointText  �� 
TargetType �� Property �� Value  RoundButton �� 	Resources �� DataType   Blackjack.Models.Card �� CornerRadius `� 	Converter �� Path T� X	 T� Y
 � Triggers :� RoutedEvent �� TargetProperty g� Duration W� From	 W� To�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'viewsclr-namespace:Blackjack.Views  5      )modelsclr-namespace:Blackjack.Models  5      %{  &	        &	      &	 �     (��     5      *, +)7      5      6!   �� 5      "  ��6   .�5	   
   ��  � ��$ 50(�6%   �� 5
   
    � ��$ Bahnschrift)�6'   �� 5   
    � ��$
 Bold"�6'   �� 5   
    � ��
 �����6'   5      �� 5      "  ��6    5   
   ���� 5      '��       "  ��6   .�5      ��  �@��CornerRadius$ 5��61   5      5      .�5   
   ��  � ��$ 20(�6%   �� 5   
    � ��$ Bahnschrift)�6'   �� 5   
    � ��$
 Bold"�6'   �� 5   
    � ��
 �����6'   5      �� 5      "  6   .R�5   
   �� $	��120��6   $	��160��6   $��1q�6*   
���   �$ 10��6R   $��-40, 0q�6d   ��5      `� 5      8   .1�5      �� $
 Suit�6   �� 5       $ 
FaceString�6   �� 5!      $ FaceDown�6   5"      z�5$      T� 5%      $ 0Q�6%   $	 0Q�6+   
 5'      :� 5(      $ Loaded��6   .[�5)      �� .��5*      �� .��5+      W� $, &RenderTransform.(TranslateTransform.Y)�6.   $ 0:0:0.3D�6q   $	 100X�6�   $ 0X�6�   5,      5-      5.      50      51      53      