   M S B A M L   `   `   `  ����G  CVatanArayüz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VatanArayüz.ControlsVatanArayüz.Controls  5          VatanArayüz.Anasayfa   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2uc#clr-namespace:VatanArayüz.Controls     5      -   5          N� Title$  Anasayfa��5	      .��5      �� .+�5   
   �� .+�5      ��    ImageButton#���   6    � Cursor$
 Hand��62   .��5      �� -   5         ��Name$ SwipperImage��5      $	��274��6"   $
��1133��6/    J� OpacityMask
 �   � J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      -   5        blur��   Color$	 Red��5   '      	Direction$ 0Q�63      ShadowDepth$ 15Q�6A      
BlurRadius$ 0Q�6R   	 � Triggers	 5      :� 5      
 :� RoutedEvent$
 Image.Loaded��6   .[�5   	   �� .��5   
   �� .��5      W�  �� 
TargetName$
 blur��5       �� TargetProperty$ (Direction)�5      	 W� To$	 360X�5       g� Duration$ 0:0:3D�5       g� AutoReverse .  g� RepeatBehavior$ 1��5      5      5   
   5   	   5!      5"      �� 5$      
�������$��1q�6%   $��51��69   $
��1138��6E   ._�5%      ]� -   5        $��swiper��5%      $	��100��6   $��50��6.   $��0q�6:   ��.  $��Center=�6[   $��Center=�6x   $
 Hand��6�   5'      5(      5)      �� 5*      .+�5+      A�  A� Columns$ 2��6   .+�5,      �� $��Günün Fırsatları��6   $��15(�6(   $
��Left=�66   $	��5,5q�6Q   �� 5-      -   5         ��Name$ 
frstbutton��5-      $��TÜM FIRSAT ÜRÜNLERİ��6!   $��Right=�6?   $	��5,5q�6[     Button_1#���  6h   5.      A� 50      -   5        $��UGFırsatUrunleri��50      $ 4��6)   52      53      �� 55      ���	#FFEBEBEB.+�56      A� $ 2��6    A� Rows$ 1��6   $��Stretch=�6&   ���	#FFEBEBEB$��15,50q�6[   .+�57      �� $ ��Web' Özel Sınırlı Stok��6   $��30��6-   $��15(�69   $
��Left=�6G   $	��150��6b   $��0,10,0,0q�6n   �� 58      -   5        $ 	webbutton��58      $��TÜMÜNÜ GÖR��6    $��50��65   $��Right=�6A   $	��140��6]     
Button_1.1#���  6j   59      �� 5:      -   5         ��Name$	 sc2��5:      $��Disabled=�6   $��Hidden=�6F   .��5;      A� -	   5        $��ugrid��5;      $ 1��6    $ 8��6)   ���	#FFEBEBEB��6O   ��  �� ElementName$ MyScrollViewer�� �� Path$ ViewportWidth�5<      5=      ]� 5>      ���	#FFEBEBEB$��Center=�6&   $��Center=�6C   ��.  $
��0,50q�6t   .+�5?      �� -
   5        $��0��5?      $��22��6   $��20��6&     
Button_1.2#���  61   6V   �� 5@      -   5        $��1��5@      $��22��6   $��20��6&   #���  61   6V   �� 5A      -   5        $��2��5A      $��22��6   $��20��6&   #���  61   6V   �� 5B      -   5        $��3��5B      $��22��6   $��20��6&   #���  61   6V   5C      5D      �� 5F      
�������.+�5G      ]� 
�������$��41��6"   ��.  $
��1134��6D   .+�5H      �� $��En Çok Satanlar��6   $��15(�6&   $	��150��64   $��0,0,0,10q�6@   �� 5I      -   5        $ 	button_20��5I      $��0��6    $��35��6,   $��
850,0,0,10q�67     Button_2.left#���  6K   {�.  6�   �� 5J      -   5        $ 	button_21��5J      $��1��6    $��35��6,   $��1,0,0,10q�67     Button_2.right#���  6I   {�.  6�   5K      �� 5L      -   5        $	 sc3��5L      
�������$��Disabled=�63   $��Hidden=�6Z   .��5M      A� -   5        $��ugrid2��5M      $ 1��6!   $ 10��6*   
�������5N      5O      ]� 5P      
�������$��Center=�6"   $��Center=�6?   ��.  $
��0,50q�6p   .+�5Q      �� -   5        $��0��5Q      $��22��6   $��20��6&   #���  61   6V   �� 5R      -   5        $��1��5R      $��22��6   $��20��6&   #���  61   6V   5S      5T      ]� 5V      $��38��6   ��.  $
��1134��60   .+�5W      �� $��Çok Satan Markalar��6   $��15(�6(   $	��150��66   $��0,0,0,10q�6B   5X      ]� 5Y      $	��100��6   ��.  $
��1134��61   5[      5\      5]      