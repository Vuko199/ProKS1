# Wymagania niefunkcjonalne

## NFR-01: Technologia
- Aplikacja napisana w C# na platformie .NET.
- Interfejs wykonany w Avalonia UI.
- Dane przechowywane lokalnie w pliku tekstowym.

## NFR-02: Wydajność
- Operacje dodania/edycji/usunięcia oraz sprawdzania statusu książki powinny być wykonywane bez zauważalnych opóźnień dla typowych rozmiarów danych (np. do kilku tysięcy rekordów).
- Odczyt/zapis pliku danych nie powinien powodować zawieszenia UI (w razie potrzeby operacje powinny być wykonywane asynchronicznie).

## NFR-03: Użyteczność (UX)
- Podstawowe akcje mają być dostępne z poziomu UI w intuicyjny sposób: dodaj → zapisz, wypożycz → zatwierdź, zwróć → zatwierdź.
- System pokazuje czytelne komunikaty sukcesu i błędów (np. „Książka jest już wypożyczona”).

## NFR-04: Niezawodność
- Brak pliku danych, błędny format lub brak wymaganych pól nie powinny powodować awarii aplikacji.
- System zapewnia spójność: jedna książka nie może mieć dwóch aktywnych wypożyczeń.

## NFR-05: Utrzymywalność
- Kod uporządkowany w foldery (np. Models/ViewModels/Views/Services).
- Logika wypożyczeń i walidacji wydzielona poza widoki (unikanie logiki w code-behind).
