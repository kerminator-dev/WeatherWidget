   M S B A M L   `   `   `  ���� H  DWeatherWidget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WeatherWidget.ViewsWeatherWidget.Views  C&clr-namespace:WeatherWidget.ViewModelsWeatherWidget.ViewModels  $    WeatherWidget.Views.MainWindow   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6controls!clr-namespace:WeatherWidget.Views     =
viewmodels&clr-namespace:WeatherWidget.ViewModels     -     �Name$  xWindow��$	��300��$	��420�� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � 	Resources    	TextStyle �� 
TargetType �� Property �� Value  TransparentBlack �� Color �� Opacity��%�   &	        &	 R     �� " ��.���  � ��
 �������  � ��$
 30 0q���  � ��$ 0q��� $ Black��$	 0.6Q�	 � Triggers	 :� 
 :� RoutedEvent$
 Window.Loaded��.[��� .���� .��W�  �� TargetProperty$ (Window.Opacity)� W� From 0.0	 W� To 1.0 g� Duration$ 0:0:1D� g� AutoReverse$ False�� W� EasingFunction 0  *System.Windows.Media.Animation.QuarticEase  7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ 	EaseInOut=�.��� ����  �� ImageSource$ /1.jpg�� j� Stretch$ UniformToFill=� � ColumnDefinitions �� $
��0.5* ��� $
��0.5* �.+��� $��0�� �� Padding$
 10pxq�._��  � RowDefinitions �� �� .+��� -    ��Name$ TopPanel��$��0��$	��Top=�$
��Left=�.+��� -    ��Name$ CurrentDayOfWeek��
�������$
��18px(�$
��10 0q�����  �� Path$ CurrentDayOfWeek� � ToolTip _� .��Current day of week�� -   $ CurrentDate��
�������$
��20px(�$
��10 0q����� $ CurrentDate� _� .��Current date�� -   $ CurrentWeatherType��
�������$��22(�$��10q����� $ CurrentWeatherType� _� .��Current weather type�� -   $ BottomPanel��$��1��$��Bottom=�$
��Left=�.+��� -   $ CurrentMaxTemperature��
�������$��45(�$	��0 0q����� $ CurrentMaxTemperature� _� .��)'Maximum temperature for the current day�� -   $ CurrentMinTemperature��
�������$��30(�$	��0 0q����� $ CurrentMinTemperature� _� .��)'Minimal temperature for the current day�� -	   $ CurrentPlace��
�������$��18(�$	��0 0q����� $ CurrentPlace� _� .�� Current place and country code�� -
   $ 	DaysPanel��$��1��$��0��#��[ .+��� $��2�� �� Orientation$ 
Horizontal=�$��RightToLeft=�.+��� -    ��Name$ CloseButton��  SquareButtonStyle#��[ $	��✕��$��0q�$��15(� _� .��Close window�� -   $ SettingsButton��#��[ $
��Left=�$��0q�$��13(�$	��⚙�� _� .��
Settings�� -   $ UpdateButton��#��[ $��0q�$
��Left=�$��17(�$	��⭮������ *LoadWeatherDataCommand+ _� .��Update weather data�� -   $ 
HideButton��#��[ $��0q�$	��___�� _� .��Hide Window�� ���� $ DayControls�