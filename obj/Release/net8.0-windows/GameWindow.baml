   M S B A M L   `   `   `  ���� @  <Laba4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba4Laba4      Laba4.GameWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:Laba4       � Title$  
GameWindow��$	��676��$	��870��.��� .+��� -    ��Name$ 
GameCanvas��
���   �$
|�True����  �� Orientation$ Vertical=�$��Right=�$	��Top=�$��	0,34,29,0q�$	��171��$	��150��.+��� $ 
Horizontal=�.+��� $��Score: ��$��20(�
��������� -    ��Name$ ScoreTextBlock��$��20(�
�������$��Center=����� *Player.Score+�� $ 
Horizontal=�$��0,50,0,0q�.+��� -    ��Name$ playerImage��$��16��$��16��$��0, 0, 10, 0q��� $��Player HP: ��$��20(�
�������$��Center=��� -   $ PlayerHPTextBlock��$��20(�
�������$��Center=����� *Player.Health+�� $ 
Horizontal=�$��0,10,0,0q�.+��� -   $ 
enemyImage��$��16��$��16��$��0, 0, 10, 0q��� $��
Enemy HP: ��$��20(�
��������� -   $ EnemyHPTextBlock��$��20(�
�������$��Center=����� *Enemy.Health+�� -   $"��На главное меню��$
��Left=�$	��Top=�$��657,485,0,0q�$��20(�$
��10,5q�$|�False��$��39��$	��183���� -   $!��Сохранить игру��$
��Left=�$	��Top=�$��657,559,0,0q�$��20(�$
��10,5q�$|�False��$	��183��� -	   $��GameOverCanvas��$y�Hidden=�
���   � � RowDefinitions �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��$��Center=�$��Center=�$��20q�.+��� $
��Game��$��Center=�$��40(�
���  ��$��0,0,0,5q��� $
��Over��$��Center=�$��40(�
���  ��$��0,0,0,20q��� -
   $��Начать заново��$��Center=�$��20(�$
��10,5q�$
��0,10q��� -   $3��-Вернутья на главное меню��$��Center=�$��20(�$
��10,5q�$
��0,10q�