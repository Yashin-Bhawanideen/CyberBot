   M S B A M L   `   `   `  ����F  BCyberBotGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CyberBotGUICyberBotGUI  5   	       CyberBotGUI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CyberBotGUI     5   	     � Title$  CyberBot��5   	   $	��450��6   $	��800��6'   .��5	      � ���#1E1E1E$��10q�6     � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��ChatScrollViewer��5   :   $
��Auto=�6   $��10q�6R   .��5      �� -   5         ��Name$ 	BotOutput��5      $
��Wrap=�6+   
��� � �$��16(�5   &   $��10q�64   $	��Top=�5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ 	UserInput��5      $��14(�6)   $	��600��67   $��30��6C   $��0,0,10,0q�6O   �� 5      -   5        $
��Send��5      $��80��6$   $��30��6/   6;   5      5      5      