   M S B A M L   `   `   `  ����M  IProjectGravitation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectGravitationProjectGravitation  5   	   G(clr-namespace:ProjectGravitation.ClassesProjectGravitation.Classes  5   	   K*clr-namespace:ProjectGravitation.ControllsProjectGravitation.Controlls  5   	   #    ProjectGravitation.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectGravitation     5   	   <myclass(clr-namespace:ProjectGravitation.Classes     5   	   @	mycontrol*clr-namespace:ProjectGravitation.Controlls     5   	     � Title$  
MainWindow��5
   	   $	��700��6   $	��450��6)    � 	Resources 5      %   ProjectGravitation.Classes.Game   mainGame��%   &	          5   
   6   5      .��5      �  � DataContext# �   6    � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $
��Auto=�6   $
��Auto=�6:   $��0��6_   .��5      �� -   5         ��Name$
 text��5   >   
���   �
�������$��30(�6g   ��6L   ��  �� Path$
 Text�6g   5      �� 5   
   -   5         ��Name$ buttons��5   (   
���   �$��1��69   .+�5      +   %ProjectGravitation.Controlls.MyButton  -   5          Name$ 	MainStart��5   !   $��게임 시작��5      ��5      ��  �� ElementName$ 	MainStart����5      �� 	 �� Source#	 [  $ _gameCommand�  5      $��안할래요��6!     5       $��hi��6!   69   5!      5"      