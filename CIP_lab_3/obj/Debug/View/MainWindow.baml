   M S B A M L   `   `   `  ����D  @CIP_lab_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CIP_lab_3	CIP_lab_3  5      9!clr-namespace:CIP_lab_3.ViewModelCIP_lab_3.ViewModel  5	          CIP_lab_3.View.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      #localclr-namespace:CIP_lab_3  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      *vm!clr-namespace:CIP_lab_3.ViewModel  5	        � Title$  
MainWindow��5
      $	��450��5      $��301.429��5       � 
ResizeMode$ NoResize=�5       � DataContext 5      1   +CIP_lab_3.ViewModel.TrisemusWindowViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� 
����+��.+�5      �� 
���P�� �� 
IsReadOnly .  �� SelectedValue 5      �� *
Language+ �� Mode$ TwoWay=�.@�5      �� $��English��6    �� 
IsSelected . 61   �� 5      $��Русский��6   5      �� 5      $��Center=�6    �� Orientation$ 
Horizontal=�66   5       �� 5!      $��Center=�5"      $	��Top=�5#      $��18(�5$      $
��Bold"�5%      $��Encrypt text��5&      �� 5'      $��0,20,0,0q�5(      $��Center=�5)      $	��Top=�5*      $��14(�5+      $��Text to encrypt��5,      �� 5-      $	��130��5.      $��20��5/      $��0,10,0,0q�50      
���������52      �� *EncryptText+$ TwoWay=��� 53      $��0,10,0,0q�54      $��Center=�55      $	��Top=�56      $��14(�57      $��Secret to encrypt��58      �� 59      $	��130��5:      $��20��5;      $��0,10,0,0q�5<      
���������5>      �� *SecretEncrypt+$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5?      $��Count of Columns��5@      $��0,10,0,0q�5A      $��Center=�5B      $	��Top=�5C      $��14(�5D      �� 5E      $��40��5F      $��0,10,0,0q�5G      
���������5I      �� *CountOfColumns+$ TwoWay=�$	 PropertyChanged=��� 5K      $	��100��5L      $��20��5M      $��0,5,0,0q�5N      
���P��$��Crypt and save��5Q      ��5P      �� *EncryptAndSaveCommand+5Q      5R      �� 5S   
   $��0��6   $��3��6'   � 5T   
   $��1��6   
����d�
 � RowDefinitions
 5U      �� 5V      $
��0.1* �6    �� 5W      .+�5Y      o� $��0��5Z      $	��110��5[      $
��Left=�5\      
�������.@�5^      m� $��12(�6   $��Load text from file��6)   .  (System.Windows.Interactivity.Interaction   Triggers 5_      /  )System.Windows.Interactivity.EventTrigger  5`         	EventName$ Click��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5a      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *
OpenFile+5b      5d      5e      �� 5f      $��1��6   .+�5g      �� $��Center=�5h      $	��Top=�5i      $��18(�5j      $
��Bold"�5k      $��Decrypt text��5l      �� 5m      $��0,20,0,0q�5n      $��Center=�5o      $	��Top=�5p      $��14(�5q      $��Secret to decrypt��5r      �� 5s      $	��130��5t      $��20��5u      $��0,10,0,0q�5v      
���������5x      �� *SecretDecrypt+$	 PropertyChanged=��� 5y      $��0,10,0,0q�5z      $��Center=�5{      $	��Top=�5|      $��14(�5}      $��Result��5~      �� 5      $	��130��5�      $��20��5�      $��0,10,0,0q�5�      
������� �� 
IsReadOnly . ��5�      �� *DecryptText+�� 5�      $��Count of Columns��5�      $��0,10,0,0q�5�      $��Center=�5�      $	��Top=�5�      $��14(�5�      �� 5�      $��40��5�      $��0,10,0,0q�5�      
���������5�      �� *CountOfColumns+$ TwoWay=�$	 PropertyChanged=�5�      5�      5�      5�      