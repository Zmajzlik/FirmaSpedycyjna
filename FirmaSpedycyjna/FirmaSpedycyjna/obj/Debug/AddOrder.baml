   M S B A M L   `   `   `  ����J  FFirmaSpedycyjna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FirmaSpedycyjnaFirmaSpedycyjna  5          FirmaSpedycyjna.AddOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:FirmaSpedycyjna     5      .��5	      � .+�5
   
   �� -   5        $��IDBox��5
      $y�Hidden=�6   $
��Left=�63   $��23��6N   $��135,321,0,0q�6Z     �� TextWrapping$
  Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $��IDBox2��5      $y�Hidden=�6    $
��Left=�64   $��23��6O   $��135,321,0,0q�6[   $
  Wrap=�6p   $	��Top=�6�   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	OrderDate��5      $
��Left=�6&   $��
113,88,0,0q�6A   $	��Top=�6U   $	��103��6m     5   
   -   5        $��RequiredDate��5      $
��Left=�6)   $��113,114,0,0q�6D   $	��Top=�6Y   $	��103��6q    J� RenderTransformOrigin$ 0.5,0.5&�6}   �� 5   
   -   5        $��DestinationTxt��5   <    �� TextAlignment$ Center=�6   $��Destination��6)   $��14(�6R   $��SemiBold"�6`   $
��Left=�6v   $��23��6�   $��	10,36,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��OrderDateTxt��5   ;   $ Center=�6   $��
Order date��6)   $��14(�6O   $��SemiBold"�6]   $
��Left=�6s   $��23��6�   $��	10,88,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��AddrTxt��5      $
��Left=�6!   $��23��6<   $��
113,36,0,0q�6H   $
  Wrap=�6\   $	��Top=�6p   $	��103��6�   �� 5   
   -   5         ��Name$ RequiredDateTxt��5   >   $ Center=�6   $��Required date��6)   $��14(�6W   $��SemiBold"�6e   $
��Left=�6{   $��23��6�   $��
10,114,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -	   5        $ 
AddressTxt��5   8   $ Center=�6   $��Address��6)   $��14(�6L   $��SemiBold"�6Z   $
��Left=�6p   $��23��6�   $��
113,10,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -
   5        $��	CityTxtIn��5   5   $ Center=�6   $
��City��6)   $��14(�6F   $��SemiBold"�6T   $
��Left=�6j   $��23��6�   $��
216,10,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��
CountryTxt��5   8   $ Center=�6   $��Country��6)   $��14(�6J   $��SemiBold"�6X   $
��Left=�6n   $��23��6�   $��
319,10,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��CityTxt��5      $
��Left=�6!   $��23��6<   $��
216,36,0,0q�6H   $
  Wrap=�6\   $	��Top=�6p   $	��103��6�   �� 5   
   -   5        $��CountTxt��5      $
��Left=�6"   $��23��6=   $��
319,36,0,0q�6I   $
  Wrap=�6]   $	��Top=�6q   $	��103��6�   �� 5   
   -   5        $��FinalDestination��5      $y�Hidden=�6*   $
��Left=�6>   $��23��6Y   $��
427,36,0,0q�6e   $
  Wrap=�6y   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $ DistanceTxt��5   9   $ Center=�6   $��Distance��6)   $��14(�6N   $��SemiBold"�6\   $
��Left=�6r   $��23��6�   $��
10,140,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��DistTxt��5      $
��Left=�6!   $��23��6<   $��113,140,0,0q�6H   $
  Wrap=�6]   $	��Top=�6q   $	��103��6�   �� 5   
   -   5        $��PricPerKmTxt��5   :   $ Center=�6   $��	Price/1km��6)   $��14(�6N   $��SemiBold"�6\   $
��Left=�6r   $��23��6�   $��
10,166,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��PerKmTxt��5      $
��Left=�6"   $��23��6=   $��113,166,0,0q�6I   $
  Wrap=�6^   $	��Top=�6r   $	��103��6�   �� 5   
   -   5        $��
TotalPrice��5   P   $y�Hidden=�6   $ Center=�6&   $��Total price��6=   $��14(�6b   $��SemiBold"�6p   $
��Left=�6�   $��23��6�   $��
10,192,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��TotalPriceTxt��5   &   $y�Hidden=�6   $
��Left=�6;   $��23��6V   $��113,192,0,0q�6b   $
  Wrap=�6w   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��FreightText��5   8   $ Center=�6   $��Freight��6)   $��14(�6K   $��SemiBold"�6Y   $
��Left=�6o   $��28��6�   $��
10,192,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5   
   -   5        $��
FreightTxt��5      $
��Left=�6$   $��28��6?   $��113,192,0,0q�6K   $
  Wrap=�6`   $	��Top=�6t   $	��103��6�   �� 5    
   -   5        $��CustTxt��5    9   $ Center=�6   $��Customer��6)   $��14(�6H   $��SemiBold"�6V   $
��Left=�6l   $��26��6�   $��
10,220,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5!   
   -   5        $��Customer��5!      $
��Left=�6#   $��113,220,0,0q�6>   $	��Top=�6S   $	��103��6k   �� 5"   
   -   5        $��
TrailerTxt��5"   =   $ Center=�6   $��Trailer type��6)   $��14(�6O   $��SemiBold"�6]   $
��Left=�6s   $��26��6�   $��
10,246,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5#   
   -   5        $��Trailer��5#      $
��Left=�6"   $��113,246,0,0q�6=   $	��Top=�6R   $	��103��6j   $ 0.495,0.487&�6v   �� 5$   
   -   5        $��DistBox��5$      $y�Hidden=�6!   $
��Left=�65   $��23��6P   $��343,140,0,0q�6\   $
  Wrap=�6q   $	��Top=�6�   $	��120��6�   �� 5%   
   -   5        $ DestinationTxt_Copy��5%   <   $ Center=�6   $��Start place��6)   $��14(�6Y   $��SemiBold"�6g   $
��Left=�6}   $��23��6�   $��	10,62,0,0q�6�   $
  Wrap=�6�   $	��Top=�6�   $	��103��6�   �� 5&   
   -   5        $��AddrTxtStart��5&      $
��Left=�6&   $��23��6A   $��
113,62,0,0q�6M   $
  Wrap=�6a   $	��Top=�6u   $	��103��6�   �� 5'   
   -   5        $��CityTxtStart��5'      $
��Left=�6&   $��23��6A   $��
216,62,0,0q�6M   $
  Wrap=�6a   $	��Top=�6u   $	��103��6�   �� 5(   
   -   5        $��CountTxtStart��5(      $
��Left=�6'   $��23��6B   $��
319,62,0,0q�6N   $
  Wrap=�6b   $	��Top=�6v   $	��103��6�   �� 5)   
   -    5        $��StartPlaceBox��5)      $y�Hidden=�6'   $
��Left=�6;   $��22��6V   $��272,374,0,0q�6b   $
  Wrap=�6w   $	��Top=�6�   $	��120��6�   �� 5*   
   -!   5        $��ShippedDateBox��5*      $y�Hidden=�6(   $
��Left=�6<   $��23��6W   $��242,321,0,0q�6c   $
  Wrap=�6x   $	��Top=�6�   $	��120��6�   �� 5+   
   -"   5        $��CustomerIDBox��5+      $y�Hidden=�6'   $
��Left=�6;   $��23��6V   $��242,321,0,0q�6b   $
  Wrap=�6w   $	��Top=�6�   $	��120��6�   �� 5,   
   -#   5        $��IDBox3��5,      $y�Hidden=�6    $
��Left=�64   $��23��6O   $��135,321,0,0q�6[   $
  Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5-   
   -$   5        $��TrailerIDBox��5-      $y�Hidden=�6&   $
��Left=�6:   $��23��6U   $��
48,400,0,0q�6a   $
  Wrap=�6u   $	��Top=�6�   $	��120��6�   �� 5.   
   -%   5        $��AddBtn��5.      $	��Add��6/   $
��Left=�6=   $��216,275,0,0q�6X   $	��Top=�6m   $��75��6�   �� 5/   
   -&   5        $��BackBtn��5/      $
��Back��61   $
��Left=�6@   $��	498,0,0,0q�6[   $	��Top=�6n   $��75��6�   50      51      