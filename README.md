# ŮKOLNÍČEK :D - TODO aplikace

## Příkazy

| Příkaz | Co dělá |
|--------|---------|
| `pridat` | Vytvoří nový úkol |
| `vypsat` | Zobrazí všechny úkoly a jejich stav |
| `done` | Označí úkol jako splněný |
| `smazat` | Smaže úkol ze seznamu |
| `help` | Ukáže nápovědu |
| `konec` | Zavře program |

## Struktura projektu

- `Program.cs` - hlavní program, menu a všechny příkazy
- `TaskItem.cs` - třída pro jeden úkol (název, popis, priorita, stav)
- `UkladaniUkolu.cs` - ukládání a načítání úkolů ze souboru JSON
- `ukoly.json` - soubor kde se ukládají úkoly (vytvoří se automaticky)

## Funkce

- Přidání úkolu s názvem, popisem a prioritou (1 = nízká, 2 = střední, 3 = vysoká)
- Označení úkolu jako splněného
- Smazání úkolu
- Ukládání do JSON souboru - úkoly přežijí restart programu
- Ošetření chyb - program nevyhodí chybu když uživatel zadá špatný vstup

---

## Použití AI

Při tvorbě tohoto projektu byla použita AI (Claude od Anthropic).

### Seznam promptů

1. **"zadání 4 - Správce úkolů... tohle mam udelany, muzes mi  dodelat done a smazat"**
    - AI doplnila příkazy `done` a `smazat` do existujícího kódu

2. **"Ukládání do souboru (JSON), aby data přežila restart"**
    - AI vytvořila třídu `UkladaniUkolu` která ukládá a načítá úkoly pomocí `System.Text.Json`

3. **"Ošetření neplatných operací"**
    - AI přidala ošetření pro: prázdný název, špatný formát čísla (`int.TryParse`), neexistující úkol, už splněný úkol, priorita mimo rozsah

4. **"muzes mi udelat i komentare"**
    - AI přidala komentáře do `Program.cs` a `TaskItem.cs`

5. **"mohl bys mi k tomuto projektu udělat README, funkce a promty, které jsem použil"**
    - AI napsala README.md k tomuto projektu