   M S B A M L   `   `   `  ���� G  CVatanArayüz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VatanArayüz.ControlsVatanArayüz.Controls      VatanArayüz.Anasayfa   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2uc#clr-namespace:VatanArayüz.Controls     -     N� Title$  Anasayfa��.���� .+��� .+���    ImageButton#���    � Cursor$
 Hand��.���� -    ��Name$ SwipperImage��$	��274��$
��1133�� J� OpacityMask
 �   � J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  -   blur��   Color$	 Red��   	Direction$ 0Q�   ShadowDepth$ 15Q�   
BlurRadius$ 0Q�	 � Triggers	 :� 
 :� RoutedEvent$
 Image.Loaded��.[��� .���� .��W�  �� 
TargetName$
 blur�� �� TargetProperty$ (Direction)�	 W� To$	 360X� g� Duration$ 0:0:3D� g� AutoReverse .  g� RepeatBehavior$ 1���� 
�������$��1q�$��51��$
��1138��._�]� -   $��swiper��$	��100��$��50��$��0q���.  $��Center=�$��Center=�$
 Hand���� .+�A�  A� Columns$ 2��.+��� $��Günün Fırsatları��$��15(�$
��Left=�$	��5,5q��� -    ��Name$ 
frstbutton��$��TÜM FIRSAT ÜRÜNLERİ��$��Right=�$	��5,5q�  Button_1#���  A� -   $��UGFırsatUrunleri��$ 4���� ���	#FFEBEBEB.+�A� $ 2�� A� Rows$ 1��$��Stretch=����	#FFEBEBEB$��15,50q�.+��� $ ��Web' Özel Sınırlı Stok��$��30��$��15(�$
��Left=�$	��150��$��0,10,0,0q��� -   $ 	webbutton��$��TÜMÜNÜ GÖR��$��50��$��Right=�$	��140��  
Button_1.1#���  �� -    ��Name$	 sc2��$��Disabled=�$��Hidden=�.��A� -	   $��ugrid��$ 1��$ 8�����	#FFEBEBEB����  �� ElementName$ MyScrollViewer�� �� Path$ ViewportWidth�]� ���	#FFEBEBEB$��Center=�$��Center=���.  $
��0,50q�.+��� -
   $��0��$��22��$��20��  
Button_1.2#���  �� -   $��1��$��22��$��20��#���  �� -   $��2��$��22��$��20��#���  �� -   $��3��$��22��$��20��#���  �� 
�������.+�]� 
�������$��41����.  $
��1134��.+��� $��En Çok Satanlar��$��15(�$	��150��$��0,0,0,10q��� -   $ 	button_20��$��0��$��35��$��
850,0,0,10q�  Button_2.left#���  {�.  �� -   $ 	button_21��$��1��$��35��$��1,0,0,10q�  Button_2.right#���  {�.  �� -   $	 sc3��
�������$��Disabled=�$��Hidden=�.��A� -   $��ugrid2��$ 1��$ 10��
�������]� 
�������$��Center=�$��Center=���.  $
��0,50q�.+��� -   $��0��$��22��$��20��#���  �� -   $��1��$��22��$��20��#���  ]� $��38����.  $
��1134��.+��� $��Çok Satan Markalar��$��15(�$	��150��$��0,0,0,10q�]� $	��100����.  $
��1134��