using uwap.WebFramework.Localization;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    public static class PluginTexts
    {
        public static readonly Translation Badminton = CommonTexts.Create(
            null,
            "Badminton",
            "Badminton"
        );
        
        public static readonly Translation NewTournament = CommonTexts.Create(
            "bi bi-calendar-plus",
            "New tournament",
            "Neues Turnier"
        );
        
        public static readonly Translation Single11 = CommonTexts.Create(
            "bi bi-person-fill",
            "Single to 11",
            "Einzel bis 11"
        );
        
        public static readonly Translation Double11 = CommonTexts.Create(
            "bi bi-people-fill",
            "Double to 11",
            "Doppel bis 11"
        );
        
        public static readonly Translation Single21 = CommonTexts.Create(
            "bi bi-person-fill",
            "Single to 21",
            "Einzel bis 21"
        );
        
        public static readonly Translation Double21 = CommonTexts.Create(
            "bi bi-people-fill",
            "Double to 21",
            "Doppel bis 21"
        );
        
        public static readonly Translation Players = CommonTexts.Create(
            "bi bi-person-lines-fill",
            "Players",
            "Spieler"
        );
        
        public static readonly Translation NewPlayer = CommonTexts.Create(
            "bi bi-person-plus-fill",
            "New player",
            "Neuer Spieler"
        );
        
        public static readonly Translation Name = CommonTexts.Create(
            null,
            "Name",
            "Name"
        );
        
        public static readonly Translation NameMissing = CommonTexts.Create(
            null,
            "Please enter a name.",
            "Bitte geben Sie einen Namen ein."
        );
        
        public static readonly Translation NameExists = CommonTexts.Create(
            null,
            "This player already exists.",
            "Dieser Spieler existiert bereits."
        );
        
        public static readonly Translation RemovePlayerDescription = CommonTexts.Create(
            null,
            "Deletes all combinations with this player.",
            "Löscht alle Kombinationen mit dem Spieler."
        );
        
        public static readonly Translation ReallyRemovePlayer = CommonTexts.Create(
            null,
            "Do you want to remove this player?",
            "Möchten Sie diesen Spieler entfernen?"
        );
        
        public static readonly Translation ReallyCancelMatch = CommonTexts.Create(
            null,
            "Do you want to cancel the match?",
            "Möchten Sie das Spiel abbrechen?"
        );
        
        public static readonly Translation ReallyGenerateCombinations = CommonTexts.Create(
            null,
            "Do you want to re-generate all combinations?",
            "Möchten Sie alle Kombinationen neu generieren?"
        );
        
        public static readonly Translation NoPlayers = CommonTexts.Create(
            null,
            "No players have been added yet.",
            "Es wurden noch keine Spieler hinzugefügt."
        );
        
        public static readonly Translation NoCombinations = CommonTexts.Create(
            null,
            "No combinations are left.",
            "Alle Kombinationen wurden gespielt."
        );
        
        public static readonly Translation NotEnoughPlayers = CommonTexts.Create(
            null,
            "Not enough players are active.",
            "Es gibt nicht genug aktive Spieler."
        );
        
        public static readonly Translation Combination = CommonTexts.Create(
            "bi bi-calendar-event",
            "Combination",
            "Kombination"
        );
        
        public static readonly Translation Combinations = CommonTexts.Create(
            "bi bi-calendar-week",
            "Combinations",
            "Kombinationen"
        );
        
        public static readonly Translation Match = CommonTexts.Create(
            "bi bi-calendar-event",
            "Match",
            "Spiel"
        );
        
        public static readonly Translation Results = CommonTexts.Create(
            "bi bi-table",
            "Results",
            "Ergebnisse"
        );
        
        public static readonly Translation Start = CommonTexts.Create(
            "bi bi-flag",
            "Start",
            "Beginn"
        );
        
        public static readonly Translation Actions = CommonTexts.Create(
            "bi bi-hand-index-thumb",
            "Actions",
            "Aktionen"
        );
        
        public static readonly Translation NewCombinations = CommonTexts.Create(
            "bi bi-stars",
            "New combinations",
            "Neue Kombinationen"
        );
        
        public static readonly Translation MatchOver = CommonTexts.Create(
            null,
            "Match over",
            "Spiel vorüber"
        );
        
        public static readonly Translation Winners = CommonTexts.Create(
            null,
            "Winners",
            "Gewinner"
        );
        
        public static readonly Translation Continue = CommonTexts.Create(
            "bi bi-arrow-return-right",
            "Continue",
            "Weiter"
        );
        
        public static readonly Translation Back = CommonTexts.Create(
            null,
            "Back",
            "Zurück"
        );
        
        public static readonly Translation Cancel = CommonTexts.Create(
            "bi bi-x-circle",
            "Cancel",
            "Abbrechen"
        );
        
        public static readonly Translation CancelDescription = CommonTexts.Create(
            null,
            "Puts the combination back on the list.",
            "Setzt die Kombination zurück in die Liste."
        );
        
        public static readonly Translation Add = CommonTexts.Create(
            "bi bi-arrow-return-right",
            "Add",
            "Hinzufügen"
        );
        
        public static readonly Translation Delete = CommonTexts.Create(
            "bi bi-trash",
            "Delete",
            "Entfernen"
        );
        
        public static readonly Translation Undo = CommonTexts.Create(
            "bi bi-arrow-counterclockwise",
            "Undo",
            "Rückgängig"
        );
        
        public static readonly Translation UndoDescription = CommonTexts.Create(
            null,
            "Reverses the last point.",
            "Entfernt den letzten Punkt."
        );
        
        public static readonly Translation Activate = CommonTexts.Create(
            "bi bi-check-circle",
            "Activate",
            "Aktivieren"
        );
        
        public static readonly Translation Deactivate = CommonTexts.Create(
            "bi bi-ban",
            "Deactivate",
            "Deaktivieren"
        );
        
        public static readonly Translation ActivatePlayerDescription = CommonTexts.Create(
            null,
            "Shows all combinations with this player again.",
            "Zeigt alle Kombinationen mit dem Spieler wieder an."
        );
        
        public static readonly Translation DeactivatePlayerDescription = CommonTexts.Create(
            null,
            "Hides all combinations with this player.",
            "Versteckt alle Kombinationen mit dem Spieler."
        );
        
        public static readonly Translation Rename = CommonTexts.Create(
            "bi bi-tag",
            "Rename",
            "Umbenennen"
        );
        
        public static readonly Translation RenamePlayerDescription = CommonTexts.Create(
            null,
            "Changes the player's name.",
            "Gibt dem Spieler einen neuen Namen."
        );
        
        public static readonly Translation NoPointsYet = CommonTexts.Create(
            null,
            "No points were scored yet.",
            "Es wurden noch keine Punkte eingetragen."
        );
        
        public static readonly Translation InvertA = CommonTexts.Create(
            "bi bi-arrow-down-up",
            "Invert team A",
            "Team A tauschen"
        );
        
        public static readonly Translation InvertB = CommonTexts.Create(
            "bi bi-arrow-down-up",
            "Invert team B",
            "Team B tauschen"
        );
        
        public static readonly Translation InvertDescription = CommonTexts.Create(
            null,
            "Corrects the positions in the team.",
            "Korrigiert die Positionen im Team."
        );
        
        public static readonly Translation FastWinA = CommonTexts.Create(
            "bi bi-flag",
            "Team A won",
            "Team A hat gewonnen"
        );
        
        public static readonly Translation FastWinB = CommonTexts.Create(
            "bi bi-flag",
            "Team B won",
            "Team B hat gewonnen"
        );
        
        public static readonly Translation FastWinDescription = CommonTexts.Create(
            null,
            "Marks the match as won without exact points.",
            "Markiert das Spiel ohne genaue Punkte als gewonnen."
        );
    }
}