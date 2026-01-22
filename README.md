# ProKS1 — Aplikacja biblioteczna

<img width="2816" height="1536" alt="Gemini_Generated_Image_d708scd708scd708" src="https://github.com/user-attachments/assets/18b06ee0-1732-4162-b01a-c7426f85db6e" />

ProKS1 to aplikacja desktopowa do obsługi prostej biblioteki. Umożliwia zarządzanie książkami i czytelnikami oraz rejestrowanie wypożyczeń. System pozwala sprawdzić, czy dana książka jest aktualnie wypożyczona oraz na jak długo (termin zwrotu / czas pozostały).

Aplikacja została wykonana w **C#/.NET** z użyciem **Avalonia UI**. Dane są przechowywane lokalnie w **pliku tekstowym**.

---

## Najważniejsze funkcje
- Dodawanie i przeglądanie książek
- Dodawanie i przeglądanie czytelników
- Wypożyczanie i zwrot książek
- Sprawdzanie statusu książki: dostępna / wypożyczona + informacje o czasie wypożyczenia

---

## Dokumentacja projektu (wymagane)
- Wymagania funkcjonalne: `docs/functional-requirements.md`
- Wymagania niefunkcjonalne: `docs/nonfunctional-requirements.md`
- Funkcjonalności / moduły: `docs/modules.md`
- Przypadki użycia: `docs/use-cases.md`
- Architektura + diagram: `docs/architecture.md` + `docs/diagrams/architecture.png`
- Stos technologiczny + uruchomienie: `docs/runbook.md`
- Struktura folderów (.NET): `docs/folder-structure.md`

---

## Uruchomienie aplikacji (Release)

1. Pobierz repozytorium jako ZIP lub sklonuj projekt.
2. Wejdź do folderu z aplikacją.
3. Uruchom plik **`ProKS.exe`**.

> Dane aplikacji są zapisywane lokalnie w plikach (np. `books.json`, `loans.json`).  
> Najlepiej trzymaj je w tym samym folderze co `ProKS.exe` (aplikacja może je utworzyć przy pierwszym uruchomieniu).

---

## Instrukcja obsługi

### Ekran startowy
Po uruchomieniu aplikacji zobaczysz komunikat:
**„Witaj w systemie bibliotecznym! Skorzystaj z menu u góry.”**  
Aby rozpocząć, kliknij menu **Operacje** w lewym górnym rogu.

---

### Menu „Operacje”
W menu znajdują się główne funkcje:
- **Dodaj wypożyczenie…** → proces wypożyczenia książki
- **Tabela wszystkich wypożyczeń…** → lista wypożyczeń + filtrowanie
- **Zarządzaj Książkami…** → dodawanie książek i podgląd bazy książek
<img width="1100" height="781" alt="70b0fbd9-d023-48cb-a2d5-82e7f3e08e6c" src="https://github.com/user-attachments/assets/4e4d5c21-c6c5-444d-82b6-49dee135b50c" />


---<img width="567" height="440" alt="1a814a34-6e44-497c-80ff-b14e470292a9" src="https://github.com/user-attachments/assets/35afa8d6-17ec-4e6c-b52a-7e2abe3476d4" />


## 1) Dodawanie książki (Zarządzanie książkami)
1. Wejdź w **Operacje → Zarządzaj Książkami…**
2. Otworzy się okno **Zarządzanie książkami** z formularzem u góry i tabelą na dole.
3. Wpisz dane książki:
   - **Tytuł** (wymagane)
   - **Autor**
   - **Gatunek**
   - **Rok**
   - **ISBN**
   - **Egz.** (liczba egzemplarzy)
4. Kliknij **Dodaj**.
5. Książka pojawi się w tabeli.
<img width="1202" height="634" alt="dcbb38ce-cef2-4c7f-8eb2-15a38cec2c02" src="https://github.com/user-attachments/assets/6889474e-b323-420b-887d-c5aa50ee0323" />

Dodatkowe opcje:
- Pole **Szukaj (tytuł lub autor)** + **Filtruj** → filtruje listę
- **Wyczyść** → czyści pole wyszukiwania
- **Odśwież** → ponownie wczytuje dane z pliku (np. `books.json`)

---

## 2) Wypożyczenie książki (Dodaj wypożyczenie…)
### Krok A — wybór książki
1. Wejdź w **Operacje → Dodaj wypożyczenie…**
2. W oknie **Wybierz Książkę** kliknij książkę na liście (zaznaczy się).
3. Kliknij **Wybierz**.
<img width="1089" height="495" alt="9c8fdd42-4f81-4eec-9219-0145eac20ac2" src="https://github.com/user-attachments/assets/906b1c67-c971-433d-bbc7-0b1f2f8d5e1f" />

### Krok B — dane wypożyczenia
1. Otworzy się okno **Nowe wypożyczenie: [Tytuł]**
2. Uzupełnij:
   - **Czytelnik** (imię i nazwisko)
   - **Telefon**
   - **Data wypożyczenia** (dzień / miesiąc / rok)
   - **Termin zwrotu** (dzień / miesiąc / rok)
   - **Uwagi** (opcjonalnie)
3. Kliknij **Zapisz**.
<img width="1182" height="759" alt="723545fb-1617-4464-8177-9386adcc994e" src="https://github.com/user-attachments/assets/aee9ad03-6044-4afc-9cdb-e2f077028c37" />

Jeśli książka jest już wypożyczona, aplikacja pokaże komunikat i nie pozwoli wykonać operacji.

---

## 3) Tabela wypożyczeń (wyszukiwanie i filtrowanie)
1. Wejdź w **Operacje → Tabela wszystkich wypożyczeń…**
2. Otworzy się okno **Wypożyczenia (z filtrami)**

Dostępne filtry:
- **Książka (tytuł)** — np. „Pan Tadeusz”
- **Czytelnik lub telefon** — np. „Kowalski” lub „505”
- **Termin od** i **Termin do** — zakres dat (dzień/miesiąc/rok)

Przyciski:
- **Szukaj** — stosuje filtry
- **Wyczyść** — czyści filtry
- **Odśwież** — ponownie wczytuje dane

Na górze okna widać:
- **Załadowano:** liczba rekordów wczytanych
- **Widoczne:** liczba rekordów po filtrach
- ścieżkę do pliku danych (np. `loans.json`)

---

## 4) Zwrot książki
Zwrot wykonujesz z poziomu listy wypożyczeń:
1. Otwórz **Operacje → Tabela wszystkich wypożyczeń…**
2. Zaznacz wypożyczenie na liście (rekord w tabeli).
3. Kliknij **Zwróć** (jeśli przycisk jest dostępny w Twojej wersji okna / w szczegółach wypożyczenia).
4. Książka zmieni status na **Dostępna**.

---

## 5) Pliki danych (gdzie zapisują się informacje)
Aplikacja zapisuje dane lokalnie w plikach (JSON) i pokazuje ich ścieżkę w oknach, np.:
- `books.json` — baza książek
- `loans.json` — baza wypożyczeń

Po ponownym uruchomieniu `ProKS.exe` dane pozostają zachowane.


> **Uwaga:** Pozostała dokumentacja projektowa znajduje się w katalogu `docs/`:
> - Wymagania funkcjonalne: `docs/functional-requirements.md`
> - Wymagania niefunkcjonalne: `docs/nonfunctional-requirements.md`
> - Moduły systemu: `docs/modules.md`
> - Przypadki użycia: `docs/use-cases.md`
> - Uruchomienie i stos technologiczny: `docs/runbook.md`
> - Struktura folderów (.NET): `docs/folder-structure.md`

