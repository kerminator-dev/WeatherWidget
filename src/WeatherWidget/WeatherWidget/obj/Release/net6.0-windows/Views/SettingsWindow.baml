   M S B A M L   `   `   `  ���� H  DWeatherWidget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WeatherWidget.PropertiesWeatherWidget.Properties  C&clr-namespace:WeatherWidget.ViewModelsWeatherWidget.ViewModels  (    "WeatherWidget.Views.SettingsWindow   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =
properties&clr-namespace:WeatherWidget.Properties     =
viewmodels&clr-namespace:WeatherWidget.ViewModels     -   $	��172��$	��230��  � WindowStyle$
  None=� � AllowsTransparency$
 True��
���   � � WindowStartupLocation$ CenterOwner=� � 	Resources    CheckBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType �� 
Background	 �� Bullet
 ��Name �� CornerRadius �� 
StartPoint �� EndPoint � Color � Offset F�Name J� SnapsToDevicePixels �� Stretch �� Angle �� Color'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible R� Value��%J  &	        �� " ��.���  �@�Cursor$
 Hand����  � ��$ 0 10 0 0q���  � ��
 �������  �@J�SnapsToDevicePixels$
 true����  �@�OverridesDefaultStyle$
 true����  � �� �� " ��.R��� 
 ���� 	 �� $
 Border��$��18��$��18��$ 4��$��1q����� $	 0,0&�$	 0,1&���� � $ #1d213d��$	 0.0Q����� $	 0,0&�$	 0,1&���� � $ #1d213d��._�� .+�F� $ 	CheckMark��$��1��$��1��$��10��$��10��$y�	Collapsed=�$ False��$��2��+����        ���j ��j �    ��j ���j     	$
 Fill=�z�V� .~��� �� �� $ 0Q�T� ���� $ 	LightGray��F� $ InderminateMark��$��0��$y�	Collapsed=�$��10��$��10��$ False��$��2������    ��j ���j     	���� $ White��   CheckStates��.   Checked��. �� .��T� $ (UIElement.Visibility)�$ 	CheckMark��..�i� $ 0��# Z   	Unchecked��  Indeterminate��. �� .��T� $ (UIElement.Visibility)�$ InderminateMark��..�i� $ 0��# Z ._��� $��4,0,0,0q�$��Center=�$
��Left=�$
��True��.��� .+��� ���#2d325a.+�� ���#1d213d � ColumnDefinitions �� �� $
��auto �.+��� $��0��  
LabelStyle#��[ $��Settings��
�������$��14(�$	��0pxq�$
��10 0q�$��Center=�$
��Left=��� $��1��$��Stretch=� �� Orientation$ 
Horizontal=�$��RightToLeft=�.+��� -    ��Name$ CloseButton��  SquareButtonStyle#��[ $	��✕��$��15(�  � ToolTip$)  #Close window without saving changes���� ! �� Padding$
! 10pxq�._��� .+��� #��[ $	��0pxq�
�������$��City:����   TextBoxStyle#��[ ���#1d213d$	��4pxq�
����������� *CurrentCity+" �� Mode$" TwoWay=�.��$  Current city��.���� #��[  
�������${�False��# d� 	IsChecked$# FalseY�.���� !Receive weather data at startup�� $ 
Horizontal=�$��Right=�$��0 14 0 0q�.+��� -   $ CancelButton��$��Stretch=�  FlatButtonStyle#��[ $��Cancel�����#B33771$)  #Close window without saving changes���� -   $ 
SaveButton��$��Stretch=�$��10 0 0 0q�#��[ $��Save changes�����#7033ff���� *SaveChangesCommand+$  Save current settings��