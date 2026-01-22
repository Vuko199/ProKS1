# Przypadki użycia

## UC-01: Dodanie książki
- Aktor: Bibliotekarz/Użytkownik
- Cel: Dodać nową książkę
- Scenariusz:
  1) Użytkownik wybiera „Dodaj książkę”
  2) Wpisuje dane (np. tytuł, autor)
  3) Zatwierdza
  4) System waliduje dane
  5) System zapisuje dane do pliku tekstowego

## UC-02: Dodanie czytelnika
- Aktor: Bibliotekarz/Użytkownik
- Cel: Dodać czytelnika
- Scenariusz analogiczny do UC-01

## UC-03: Wypożyczenie książki
- Aktor: Bibliotekarz/Użytkownik
- Cel: Wypożyczyć książkę
- Scenariusz:
  1) Użytkownik wybiera książkę
  2) Wybiera „Wypożycz”
  3) Wskazuje czytelnika i termin/okres
  4) System sprawdza dostępność
  5) System zapisuje wypożyczenie i aktualizuje status książki
  6) System zapisuje dane do pliku tekstowego
- Alternatywa:
  - Książka już wypożyczona → komunikat i brak akcji

## UC-04: Zwrot książki
- Aktor: Bibliotekarz/Użytkownik
- Cel: Zwrócić książkę
- Scenariusz:
  1) Użytkownik wybiera wypożyczoną książkę
  2) Wybiera „Zwróć”
  3) System zamyka wypożyczenie i ustawia status „dostępna”
  4) System zapisuje dane do pliku tekstowego

## UC-05: Sprawdzenie statusu książki
- Aktor: Bibliotekarz/Użytkownik
- Cel: Sprawdzić, czy książka jest wypożyczona i na jak długo
- Scenariusz:
  1) Użytkownik wybiera książkę
  2) System pokazuje status (dostępna/wypożyczona)
  3) Jeśli wypożyczona → system pokazuje czytelnika + termin zwrotu / czas pozostały
