using uwap.WebFramework.Localization;
using static uwap.WebFramework.Localization.CommonTexts;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    public static class PluginTexts
    {
        public static readonly Translation Badminton = Create(
            "bi bi-layout-split",
            "Badminton",
            "Badminton"
        );
        
        public static readonly Translation NewTournament = Create(
            "bi bi-calendar-plus",
            "New tournament",
            "Neues Turnier"
        );
        
        public static readonly Translation Single11 = Create(
            "bi bi-person-fill",
            "Single to 11",
            "Einzel bis 11"
        );
        
        public static readonly Translation Double11 = Create(
            "bi bi-people-fill",
            "Double to 11",
            "Doppel bis 11"
        );
        
        public static readonly Translation Single21 = Create(
            "bi bi-person-fill",
            "Single to 21",
            "Einzel bis 21"
        );
        
        public static readonly Translation Double21 = Create(
            "bi bi-people-fill",
            "Double to 21",
            "Doppel bis 21"
        );
        
        public static readonly Translation Players = Create(
            "bi bi-person-lines-fill",
            "Players",
            "Spieler"
        );
        
        public static readonly Translation NewPlayer = Create(
            "bi bi-person-plus-fill",
            "New player",
            "Neuer Spieler"
        );
        
        public static readonly Translation NamePlaceholder = Create(
            "Enter a name...",
            "Namen eingeben..."
        );
        
        public static readonly Translation NameExists = Create(
            "This player already exists.",
            "Dieser Spieler existiert bereits."
        );
        
        public static readonly Translation NameSame = Create(
            "The provided name is the same as the old one.",
            "Dieser Name entspricht dem alten Namen."
        );
        
        public static readonly Translation RemovePlayerDescription = Create(
            "Deletes all combinations with this player.",
            "Löscht alle Kombinationen mit dem Spieler."
        );
        
        public static readonly Translation ReallyRemovePlayer = Create(
            "Do you want to remove this player?",
            "Möchten Sie diesen Spieler entfernen?"
        );
        
        public static readonly Translation ReallyCancelMatch = Create(
            "Do you want to cancel the match?",
            "Möchten Sie das Spiel abbrechen?"
        );
        
        public static readonly Translation ReallyGenerateCombinations = Create(
            "Do you want to re-generate all combinations?",
            "Möchten Sie alle Kombinationen neu generieren?"
        );
        
        public static readonly Translation NoPlayers = Create(
            "No players have been added yet.",
            "Es wurden noch keine Spieler hinzugefügt."
        );
        
        public static readonly Translation NoCombinations = Create(
            "No combinations are left.",
            "Alle Kombinationen wurden gespielt."
        );
        
        public static readonly Translation NotEnoughPlayers = Create(
            "Not enough players are active.",
            "Es gibt nicht genug aktive Spieler."
        );
        
        public static readonly Translation Combination = Create(
            "bi bi-calendar-event",
            "Combination",
            "Kombination"
        );
        
        public static readonly Translation Combinations = Create(
            "bi bi-calendar-week",
            "Combinations",
            "Kombinationen"
        );
        
        public static readonly Translation Match = Create(
            "bi bi-calendar-event",
            "Match",
            "Spiel"
        );
        
        public static readonly Translation Results = Create(
            "bi bi-table",
            "Results",
            "Ergebnisse"
        );
        
        public static readonly Translation Start = Create(
            "bi bi-flag",
            "Start",
            "Beginn"
        );
        
        public static readonly Translation Actions = Create(
            "bi bi-hand-index-thumb",
            "Actions",
            "Aktionen"
        );
        
        public static readonly Translation NewCombinations = Create(
            "bi bi-stars",
            "New combinations",
            "Neue Kombinationen"
        );
        
        public static readonly Translation MatchOver = Create(
            "bi bi-flag",
            "Match over",
            "Spiel vorüber"
        );
        
        public static readonly Translation Winners = Create(
            "Winners",
            "Gewinner"
        );
        
        public static readonly Translation CancelDescription = Create(
            "Puts the combination back on the list.",
            "Setzt die Kombination zurück in die Liste."
        );
        
        public static readonly Translation Undo = Create(
            "bi bi-arrow-counterclockwise",
            "Undo",
            "Rückgängig"
        );
        
        public static readonly Translation UndoDescription = Create(
            "Reverses the last point.",
            "Entfernt den letzten Punkt."
        );
        
        public static readonly Translation Activate = Create(
            "bi bi-check-circle",
            "Activate",
            "Aktivieren"
        );
        
        public static readonly Translation Deactivate = Create(
            "bi bi-ban",
            "Deactivate",
            "Deaktivieren"
        );
        
        public static readonly Translation ActivatePlayerDescription = Create(
            "Shows all combinations with this player again.",
            "Zeigt alle Kombinationen mit dem Spieler wieder an."
        );
        
        public static readonly Translation DeactivatePlayerDescription = Create(
            "Hides all combinations with this player.",
            "Versteckt alle Kombinationen mit dem Spieler."
        );
        
        public static readonly Translation RenamePlayerDescription = Create(
            "Changes the player's name.",
            "Gibt dem Spieler einen neuen Namen."
        );
        
        public static readonly Translation NoPointsYet = Create(
            "No points were scored yet.",
            "Es wurden noch keine Punkte eingetragen."
        );
        
        public static readonly Translation InvertA = Create(
            "bi bi-arrow-down-up",
            "Invert team A",
            "Team A tauschen"
        );
        
        public static readonly Translation InvertB = Create(
            "bi bi-arrow-down-up",
            "Invert team B",
            "Team B tauschen"
        );
        
        public static readonly Translation InvertDescription = Create(
            "Corrects the positions in the team.",
            "Korrigiert die Positionen im Team."
        );
        
        public static readonly Translation TeamA = Create(
            "Team A",
            "Team A"
        );
        
        public static readonly Translation TeamB = Create(
            "Team B",
            "Team B"
        );
        
        public static readonly Translation FastWinA = Create(
            "bi bi-flag",
            "Team A won",
            "Team A hat gewonnen"
        );
        
        public static readonly Translation FastWinB = Create(
            "bi bi-flag",
            "Team B won",
            "Team B hat gewonnen"
        );
        
        public static readonly Translation FastWinDescription = Create(
            "Marks the match as won without exact points.",
            "Markiert das Spiel ohne genaue Punkte als gewonnen."
        );
    }
}