   M S B A M L   `   `   `  ����G  CUserImporter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UserImporterUserImporter  5   	       UserImporter.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UserImporter     5   	     � Title$"  Active Directory CSV Creator��5   	   $��363.389��6.   $��587.238��6?   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��368* �6   �� 5      $��0* �6   �� 5      $
��211* �6   .+�5   
   �� -   5         ��Name$ 	listNevek��5      $
��Left=�6%   $	��237��6@   $��	45,44,0,0q�6M   $	��Top=�6`   $	��204��6x    J� IsManipulationEnabled . 6�   �� 5   
   $��Nevek��6   $
��Left=�6    $��39��6;   $��	45,10,0,0q�6G   $	��Top=�6Z   $	��204��6r   	� 5   
   -   5         	�Name$ rbUser��5      $
��User��6&   $
��Left=�65   $��19��6P   $��
302,63,0,0q�6\   $	��Top=�6p   $��95��6�    	� 	GroupName$ tipus��6�    d� 	IsChecked$
 TrueY�6�   $��3��6�   	� 5   
   -   5        $
 rbPC��5      $��PC��6$   $
��Left=�61   $��19��6L   $��	29,63,0,0q�6X   $	��Top=�6k   $	��138��6�   $ tipus��6�   $��2��6�   �� 5   
   -   5         ��Name$ 	tbDomains��5      $
��Left=�6%   $��20��6@   $��
282,88,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $5��/Tartományok: altartomány.főtartomány.suffix��6t   $	��Top=�6�   $	��259��6�   $��3��6�   6�   �� 5   
   -   5        $��3��5      $��CSV generálása��6%   $
��Left=�6>   $��37��6Y   $��283,212,0,0q�6e   $	��Top=�6z   $	��259��6�   6�   �� 5   
   -   5        $��Nevek importálása��5      $
��Left=�6-   $��283,161,0,0q�6H   $	��Top=�6]   $	��258��6u   $��3��6�   $��36��6�   6�   	� 5   
   -   5        $ rbMagyar��5      $��Magyar��6(   $
��Left=�69   $��
302,43,0,0q�6T   $	��Top=�6h   $ nyelv��6�   $
 TrueY�6�   	� 5   
   -   5        $ rbAngol��5      $��Angol��6'   $��2��67   $
��Left=�6G   $��	29,44,0,0q�6b   $	��Top=�6u   $ nyelv��6�   �� 5   
   -	   5        $
 tbOU��5      $��3��6    $
��Left=�64   $��21��6O   $��282,122,0,0q�6[   $
 Wrap=�6p   $��OU-k: belső<külső��6�   $	��Top=�6�   $	��259��6�   6�   5      5      