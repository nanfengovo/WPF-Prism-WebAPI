   M S B A M L   `   `   `  ����G  CDailyAPP.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DailyAPP.WPF.ViewsDailyAPP.WPF.Views  5      A%clr-namespace:DailyAPP.WPF.ViewModelsDailyAPP.WPF.ViewModels  5	          DailyAPP.WPF.Views.HomeUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:DailyAPP.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      6
viewmodels%clr-namespace:DailyAPP.WPF.ViewModels  5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��15,10q�5      $��22(�5      ��5      �� *	LoginInfo+�� 5   
   $��1��6   ��6$   �� *StatPanelList+��5      �� 5      .R�5       A� $��5,0,5,0q�6"    A� Columns$ 4��63   5!      ��5$      �� 5%      .R�5&      �� $��10q�5'       �� CornerRadius$ 5��5)      ��5(      �� *	BackColor+ J� InputBindings 5*      d� 5+       d� MouseAction$ 	LeftClicke�6+    �� Command 6C   �� *DataContext.NavigateCmm+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType ItemsControl	 �� CommandParameter	 6�   �� 5,      ��5/      �� 50      
 �� 
TargetType"
 ��6$    �� Triggers 52   "   P� 53   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �54   *   ��  �� Property �@J�Effect �� Value 55   .   3  -System.Windows.Media.Effects.DropShadowEffect  56   2      
BlurRadius$ 10Q�57   5      ShadowDepth$ 1Q�58   5      Color$ #dddddd��59   5   5;   +   5<   '   P� 5=   &    �@J�IsMouseOver$ False��6E   . �5>   *   ��  �@J�Opacity$ 1Q�6D   5?   '   5A      ._�5C      � .+�5D      �� $��20,10q�6)   .+�5E   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5F   %   $��30��5G   %      Kind 5H   %   �� *Icon+�� 5I   "   $
��0,15q�5J   %   $��15(�5K   %   ��5L   %   �� *
ItemName+�� 5M   "   $��40(�5N   %   $
��Bold"�5O   %   ��5P   %   �� *Result+5Q      �� 5T      $
}�True��6%   .+�5U   "   �� 
 �� Top$ 10��5V   %    �� Right$	 -50��5W   %   $	��120��5X   %   $	��120��5Y   %   ���#ffffff$	 100��5[   %    J� Opacity$	 0.1Q�5\   %   �� 5]   "   $ 80��5^   %   $	 -30��5_   %   $	��120��5`   %   $	��120��5a   %   ���#ffffff$	 100��5c   %   $	 0.1Q�5d   %   5e      5f      5g      5h      5j      � 5m   
   $��2��6   $
��0,15q�6    � ColumnDefinitions 5n      �� 5o      $��* �6#   �� 5p      $��* �6#   .+�5t      �� $
��10,0q�5u      ���#fffff5$ 5��5w      $	 0.5Q�5x      ._�5y      ]� .+�5z      ]� $	��Top=�6    $��False��65   .+�5{      �� $��20(�5|      $
��Bold"�5}      
���   �$��待办事项��5      �� 5�      $��30��5�      $��30��5�      $	��Top=�5�      $��Right=�5�       ,  (MaterialDesignFloatingActionAccentButton#��[  5�      ��5�      �� *ShowAddWaitDialogCmm+.��5�        $
 Plus=�6*   5�      5�      �� 5�      $��Stretch=�5�      $��Hidden=�5�      ��5�      �� *	WaitlList+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�         	EventName$ MouseDoubleClick��6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *ShowEditWaitDialogCmm+   CommandParameter 6b   �� *SelectedItem+ �� $ FindAncestor=� ListBox6�   5�      ��5�      �� 5�      .R�5�   "   ]� $��80��6,   $��False��6;   .+�5�   &   d� $��Right=�63    d� 	IsChecked 6J   �� *Status+��6g   �� *!DataContext.ChangeWaitStatusCmm+ �� $ FindAncestor=� ListBox��6�   �� �� 5�   &   .+�5�   *   �� $��16(�5�   -   $
��Bold"�5�   -   
���   ���5�   -   �� *Title+�� 5�   *   $	��0,5q�5�   -   
���   �$	 0.5Q�5�   -   ��5�   -   �� *	Content+5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��1��5�      $
��10,0q�5�      ���#fffff5$ 5��5�      $	 0.5Q�5�      ._�5�      ]� .+�5�      ]� $	��Top=�6    $��False��65   .+�5�      �� $��20(�5�      $
��Bold"�5�      
���   �$��	备忘录��5�      �� 5�      $��30��5�      $��30��5�      $	��Top=�5�      $��Right=�5�      #��[  5�      .��5�        $
 Plus=�6*   5�      5�      �� 5�      $��Stretch=�5�      $��Hidden=�5�      ��5�      �� *MemorandumList+��5�      �� 5�      .R�5�   "   ]� .+�5�   &   d� $��Right=�63   �� 5�   &   .+�5�   *   �� $��16(�5�   -   $
��Bold"�5�   -   
���   ���5�   -   �� *Title+�� 5�   *   $	��0,5q�5�   -   
���   �$	 0.5Q�5�   -   ��5�   -   �� *	Content+5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      