   M S B A M L   `   `   `  ����G  CFinalDLTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalDLToolsFinalDLTools  5   	       FinalDLTools.NewProjectUI   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   A =Wpf.Ui, Version=2.0.3.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   &localclr-namespace:FinalDLTools  5   	   -   5          �Name$  	ProjectUI��5
   	    � Title$ NewProjectUI��5	   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   $	��360��5   	   $	��900��6   
������ ��5   	   *  $Wpf.Ui.Markup.ThemeResourceExtension  *TextFillColorPrimaryBrush+ � DataContext 5      $  FinalDLTools.NewProjectContext  5   
   .��5      �� ���#454545._�5   
   � $��5q�6    � RowDefinitions 5      �� 5      $��80 �6    �� 5      $	��100 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      � $��0��6   .+�5       �� $��Create New Project��6   $��30 0 0 0q�66   $��24(�5!   
   $
��Left=�5"   
   $��Center=�5#   
   5$      � 5&      $��1��6    5'      �� 5(      $
��auto �6$   �� 5)      $��* �6$   .+�5+      �� $��DEEP LEARNING METHOD :��6   $��30 0 0 0q�6:   $��0��6L   $��12(�5,      ���	#5DFFFFFF$
��Left=�5.      $��Center=�5/      � 50      $��1��6   .+�51      �� ���	#0F000000$��30 10q�66   ._�52      �  � Orientation$ Vertical=�6$   $��Center=�6;   .+�53      	� $��Classification��6*   $��10q�6C   $��16(�54   *   	 d� 	IsChecked	 55   *   �� *IsClassification+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�	� 56      $��	Detection��6*   $��10q�6>   $��16(�57   *   	 58   *   �� *IsDetection+$
 TwoWay=�$ PropertyChanged=�	� 59      $��Segmentation��6*   $��10q�6A   $��16(�5:   *   	 5;   *   �� *IsSegmentation+$
 TwoWay=�$ PropertyChanged=�5<      5=      5>      5K      � 5M      $��2��6    � ColumnDefinitions 5N      �� 5O      $	��250 �6'   �� 5P      $	��450 �6'   �� 5Q      $��* �6'   .+�5S      � $��0��6   .+�5T      � $ Vertical=�6    .+�5U      �� $��PROJECT NAME :��6$   $��30 0 0 0q�6:   $��12(�5V      ���	#5DFFFFFF$
��Left=�5X      $��Center=�5Y      �� 5Z      $��
30 10 0 10q�6"   $	��210��66   ��6B   �� *ProjectName+5[      5]      � 5^      $��1��6   .+�5_      � $ Vertical=�6    .+�5`      �� $��PATH :��6$   $��10 0 0 0q�62   $��12(�5a      ���	#5DFFFFFF$
��Left=�5c      $��Center=�5d      �� 5e      $��
10 10 0 10q�6"   $	��440��66   ��5f   "   �� *PathSelected+$
 TwoWay=�$ PropertyChanged=�5g      5h      � 5i      $��2��6   .+�5j        Wpf.Ui.Controls.Button  $��BROWSE . . .��6       Icon$ Folder24=�5k       $��16(�5l       $��10q�6.   $��Bottom=�5m       $��Right=�5n       ��5j   7   �� *BrowseCommand+5n       5r      5s      � 5u      $��3��6    5v      �� 5w      $��2* �6'   �� 5x      $��* �6'   .+�5{      � $��0��6   .+�5|      � $ Vertical=�6    .+�5}      �� $��DESCRIPTION :��6$   $��30 0 0 0q�69   $��12(�5~       ���	#5DFFFFFF$
��Left=�5�       $��Center=�5�         Wpf.Ui.Controls.TextBox  5�         PlaceholderText$! Enter a project description��6%   $��	30 10 0 0q�6S   $	��550��5�   %   ��61   �� *DescriptionProject+5�      5�      � 5�      $��1��6    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�        $��0��6    $��CANCEL��5�       $��Bottom=�5�       $��Center=�5�       ��5�   0   �� *CancelCommand+��5�       ��  �� ElementName$ 	ProjectUI��5�         5�      $��1��6       
Appearance$ Primary=�5�       $��CREATE PROJECT��5�       $��Bottom=�5�       $��Center=�5�       ��5�   0   �� *CreateCommand+��5�       �� $ 	ProjectUI��5�       5�      5�      5�      5�      5�      