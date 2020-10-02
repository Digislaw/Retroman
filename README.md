# Retroman
Platformówka retro 2D

# Znane problemy
Wartości z klasy Controls są ulotne. Tzn. pobranie wartości, np. float x = Controls.Horizontal powoduje jego natychmiastowe wyczyszczenie - kolejne wywołanie w ramach tej samej klatki (Update()) powoduje błędny odczyt.
