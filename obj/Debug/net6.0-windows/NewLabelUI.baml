   M S B A M L   `   `   `  ����G  CFinalDLTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalDLToolsFinalDLTools  5   	       FinalDLTools.NewLabelUI   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   A =Wpf.Ui, Version=2.0.3.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44tool)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   &localclr-namespace:FinalDLTools  5   	   -   5          �Name$  LabelUI��5	   	    � Title$ 
NewLabelUI��5   	   $	��200��6   $	��300��6)    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�6#   
������ ��6R   *  $Wpf.Ui.Markup.ThemeResourceExtension  *TextFillColorPrimaryBrush+ � DataContext 5      "  FinalDLTools.NewLabelContext  5   
   .��5      �� ���#454545._�5   
   � $��5q�6    � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��2* �6    �� 5      $��* �6    .+�5      � $��0��6   .+�5      �� $��Create Class Label��6   $��10q�66   $��14(�5         TextFillColorPrimaryBrush#���   5   
   $
��Left=�5   
   $��Center=�5   
   5      � 5       $��1��6    5!      �� 5"      $��* �6$   �� 5#      $��* �6$   .+�5%      ��  �� Orientation$ 
Horizontal=�6   $��0��66   .+�5&      �� $��Name : ��6    $��10q�6/   $��Center=�6;   $��Center=�6X   $��12(�6s     Wpf.Ui.Controls.TextBox  5'      $��50��6"   $	��200��6.   $��5q�6:   ��6E   �� *Label+5(      �� 5)      $ 
Horizontal=�6   $��1��66   .+�5*      �� $��Color : ��6    $��10q�60   $��Center=�6<   $��Center=�6Y   $��12(�6t   #  Xceed.Wpf.Toolkit.ColorPicker  5+      $��Center=�5-      $��Center=�64   $��10q�6Q   $	��200��5.      $��50��5/      	   DisplayColorAndName$
	 True��50      
   DisplayColorTooltip$

 True��51         SelectedColor 52      �� *SelectedColor+54      55      � 56      $��2��6   .+�57      �� $ 
Horizontal=�6   $��Right=�67   .+�58        Wpf.Ui.Controls.Button  $��Cancel��6!   $��10q�62   ��59   !   �� *CancelCommad+��5:   !   ��  �� ElementName$ LabelUI��  5;      $	��Add��6!   $��10q�6/      
Appearance$ Primary=�5?   !   ��5<   !   �� *AddLabelCommand+��5=   !   �� $ LabelUI��{�5>   !   �� *IsEnableAdd+5?   !   5A      5C      5D      5E      5F      