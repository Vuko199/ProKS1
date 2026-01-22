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

## Szybki start (DEV)
```bash
dotnet restore
dotnet build
dotnet run

---

# docs/functional-requirements.md

```md
# Wymagania funkcjonalne

## FR-01: Zarządzanie książkami
System umożliwia:
- dodanie książki,
- wyświetlenie listy książek,
- podgląd szczegółów książki.

<img width="1024" height="559" alt="obraz" src="https://github.com/user-attachments/assets/8f8d90bb-ef98-4cd2-818e-f7baab0d6f09" />

**Kryteria akceptacji:**
- Po dodaniu książka pojawia się na liście.
- Dla książki widoczne są podstawowe dane (np. tytuł, autor, identyfikator).

## FR-02: Zarządzanie czytelnikami
System umożliwia:
- dodanie czytelnika,
- wyświetlenie listy czytelników,
- podgląd szczegółów czytelnika.

**Kryteria akceptacji:**
- Po dodaniu czytelnik pojawia się na liście.
- Czytelnik ma unikalny identyfikator (np. ID w systemie).

## FR-03: Rejestrowanie wypożyczeń
System umożliwia wypożyczenie książki wybranemu czytelnikowi.

**Kryteria akceptacji:**
- Nie da się wypożyczyć książki, jeśli jest już wypożyczona.
- Wypożyczenie zapisuje datę wypożyczenia oraz termin zwrotu (lub czas wypożyczenia).

## FR-04: Zwrot książki
System umożliwia zwrot książki.

**Kryteria akceptacji:**
- Po zwrocie książka zmienia status na „dostępna”.
- Wypożyczenie zostaje zamknięte (nie jest aktywne).

## FR-05: Sprawdzenie statusu książki
System umożliwia sprawdzenie:
- czy książka jest wypożyczona,
- kto ją wypożyczył (jeśli dotyczy),
- do kiedy / na jak długo (termin zwrotu lub czas pozostały).

**Kryteria akceptacji:**
- Dla książki dostępnej system pokazuje „dostępna”.
- Dla książki wypożyczonej system pokazuje termin zwrotu lub długość wypożyczenia.

## FR-06: Walidacja danych wejściowych
System sprawdza poprawność danych (np. puste pola).

**Kryteria akceptacji:**
- Nie da się dodać książki/czytelnika bez wymaganych pól.
- System pokazuje komunikat o błędzie w UI.

## FR-07: Zapis i odczyt danych z pliku tekstowego
System zapisuje dane biblioteki lokalnie do pliku tekstowego i odczytuje je przy starcie aplikacji.

**Kryteria akceptacji:**
- Po ponownym uruchomieniu aplikacji dane są zachowane.
- Brak pliku danych nie powoduje awarii (system startuje z pustymi listami).

## Instrukcja obsługi

### Ekran główny
Po uruchomieniu aplikacji zobaczysz panel z nawigacją do modułów:
- **Książki**
- **Czytelnicy**
- **Wypożyczenia**
- **Status książki** (podgląd czy jest wypożyczona i do kiedy)

### 1) Dodawanie książki
1. Wejdź w zakładkę **Książki**
2. Kliknij **Dodaj książkę**
3. Uzupełnij dane (np. tytuł, autor, rok/ID)
4. Kliknij **Zapisz**
5. Książka pojawi się na liście

### 2) Dodawanie czytelnika
1. Wejdź w zakładkę **Czytelnicy**
2. Kliknij **Dodaj czytelnika**
3. Uzupełnij dane (np. imię, nazwisko, ID/nr karty)
4. Kliknij **Zapisz**
5. Czytelnik pojawi się na liście

### 3) Wypożyczenie książki
1. Wejdź w zakładkę **Wypożyczenia**
2. Kliknij **Nowe wypożyczenie**
3. Wybierz książkę i czytelnika
4. Ustaw **datę wypożyczenia** i **termin zwrotu** (lub ilość dni)
5. Kliknij **Zatwierdź**
6. Jeśli książka była już wypożyczona, aplikacja pokaże komunikat i nie pozwoli wykonać operacji

### 4) Zwrot książki
1. Wejdź w zakładkę **Wypożyczenia**
2. Z listy aktywnych wypożyczeń wybierz rekord
3. Kliknij **Zwróć**
4. Książka zmieni status na „Dostępna”

### 5) Sprawdzenie, czy książka jest wypożyczona i na jak długo
1. Wejdź w **Status książki** (albo sekcję statusu w Książkach)
2. Wybierz książkę z listy
3. Zobaczysz:
   - status: **Dostępna / Wypożyczona**
   - kto wypożyczył (jeśli dotyczy)
   - **termin zwrotu** i **czas pozostały**

> Dane aplikacji są zapisywane lokalnie w pliku tekstowym. Po ponownym uruchomieniu aplikacji wpisy pozostają zachowane.


