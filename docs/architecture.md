# Architektura systemu

## Opis architektury
Aplikacja jest desktopowym systemem bibliotecznym z interfejsem w Avalonia UI. Logika aplikacji jest rozdzielona od warstwy prezentacji (zalecany styl MVVM). Dane są przechowywane lokalnie w pliku tekstowym.

## Komponenty
- **Views (Avalonia UI)**: widoki/okna aplikacji
- **ViewModels**: logika UI, komendy, walidacje
- **Models**: encje danych (Książka, Czytelnik, Wypożyczenie)
- **Services**:
  - BookService (operacje na książkach)
  - ReaderService (operacje na czytelnikach)
  - LoanService (wypożyczenia/zwroty/status)
  - FileStorageService (zapis/odczyt pliku tekstowego)
- **Storage (plik tekstowy)**: lokalne utrwalanie danych

## Przepływ danych
UI (Views) → ViewModels → Services → FileStorage (plik tekstowy)  
UI odświeża widok na podstawie danych zwróconych przez serwisy.

## Diagram (draw.io)
W repo powinny znaleźć się:
- `docs/diagrams/architecture.drawio` (źródło)
- `docs/diagrams/architecture.png` (eksport)

### Co narysować w draw.io
Prostokąty:
1) Views (Avalonia)
2) ViewModels
3) Services
4) Models
5) File Storage (plik tekstowy)

Strzałki:
- Views ↔ ViewModels
- ViewModels → Services
- Services ↔ File Storage
- Services ↔ Models
