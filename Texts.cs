using uwap.WebFramework.Responses.DefaultUI;
using uwap.WebFramework.Tools;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    public static class Texts
    {
        public static readonly CustomText Badminton = new(
            null,
            "Badminton",
            "Badminton"
        );
        
        public static readonly CustomText NewTournament = new(
            "bi bi-calendar-plus",
            "New tournament",
            "Neues Turnier"
        );
        
        public static readonly CustomText Single11 = new(
            "bi bi-person-fill",
            "Single to 11",
            "Einzel bis 11"
        );
        
        public static readonly CustomText Double11 = new(
            "bi bi-people-fill",
            "Double to 11",
            "Doppel bis 11"
        );
        
        public static readonly CustomText Single21 = new(
            "bi bi-person-fill",
            "Single to 21",
            "Einzel bis 21"
        );
        
        public static readonly CustomText Double21 = new(
            "bi bi-people-fill",
            "Double to 21",
            "Doppel bis 21"
        );
        
        public static readonly CustomText Players = new(
            "bi bi-person-lines-fill",
            "Players",
            "Spieler"
        );
        
        public static readonly CustomText NewPlayer = new(
            "bi bi-person-plus-fill",
            "New player",
            "Neuer Spieler"
        );
        
        public static readonly CustomText Name = new(
            null,
            "Name",
            "Name"
        );
        
        public static readonly CustomText NameMissing = new(
            null,
            "Please enter a name.",
            "Bitte geben Sie einen Namen ein."
        );
        
        public static readonly CustomText NameExists = new(
            null,
            "This player already exists.",
            "Dieser Spieler existiert bereits."
        );
        
        public static readonly CustomText RemovePlayerDescription = new(
            null,
            "Deletes all combinations with this player.",
            "Löscht alle Kombinationen mit dem Spieler."
        );
        
        public static readonly CustomText ReallyRemovePlayer = new(
            null,
            "Do you want to remove this player?",
            "Möchten Sie diesen Spieler entfernen?"
        );
        
        public static readonly CustomText ReallyCancelMatch = new(
            null,
            "Do you want to cancel the match?",
            "Möchten Sie das Spiel abbrechen?"
        );
        
        public static readonly CustomText ReallyGenerateCombinations = new(
            null,
            "Do you want to re-generate all combinations?",
            "Möchten Sie alle Kombinationen neu generieren?"
        );
        
        public static readonly CustomText NoPlayers = new(
            null,
            "No players have been added yet.",
            "Es wurden noch keine Spieler hinzugefügt."
        );
        
        public static readonly CustomText NoCombinations = new(
            null,
            "No combinations are left.",
            "Alle Kombinationen wurden gespielt."
        );
        
        public static readonly CustomText NotEnoughPlayers = new(
            null,
            "Not enough players are active.",
            "Es gibt nicht genug aktive Spieler."
        );
        
        public static readonly CustomText Combination = new(
            "bi bi-calendar-event",
            "Combination",
            "Kombination"
        );
        
        public static readonly CustomText Combinations = new(
            "bi bi-calendar-week",
            "Combinations",
            "Kombinationen"
        );
        
        public static readonly CustomText Match = new(
            "bi bi-calendar-event",
            "Match",
            "Spiel"
        );
        
        public static readonly CustomText Results = new(
            "bi bi-table",
            "Results",
            "Ergebnisse"
        );
        
        public static readonly CustomText Start = new(
            "bi bi-flag",
            "Start",
            "Beginn"
        );
        
        public static readonly CustomText Actions = new(
            "bi bi-hand-index-thumb",
            "Actions",
            "Aktionen"
        );
        
        public static readonly CustomText NewCombinations = new(
            "bi bi-stars",
            "New combinations",
            "Neue Kombinationen"
        );
        
        public static readonly CustomText MatchOver = new(
            null,
            "Match over",
            "Spiel vorüber"
        );
        
        public static readonly CustomText Winners = new(
            null,
            "Winners",
            "Gewinner"
        );
        
        public static readonly CustomText Continue = new(
            "bi bi-arrow-return-right",
            "Continue",
            "Weiter"
        );
        
        public static readonly CustomText Back = new(
            null,
            "Back",
            "Zurück"
        );
        
        public static readonly CustomText Cancel = new(
            "bi bi-x-circle",
            "Cancel",
            "Abbrechen"
        );
        
        public static readonly CustomText CancelDescription = new(
            null,
            "Puts the combination back on the list.",
            "Setzt die Kombination zurück in die Liste."
        );
        
        public static readonly CustomText Add = new(
            "bi bi-arrow-return-right",
            "Add",
            "Hinzufügen"
        );
        
        public static readonly CustomText Delete = new(
            "bi bi-trash",
            "Delete",
            "Entfernen"
        );
        
        public static readonly CustomText Undo = new(
            "bi bi-arrow-counterclockwise",
            "Undo",
            "Rückgängig"
        );
        
        public static readonly CustomText UndoDescription = new(
            null,
            "Reverses the last point.",
            "Entfernt den letzten Punkt."
        );
        
        public static readonly CustomText Activate = new(
            "bi bi-check-circle",
            "Activate",
            "Aktivieren"
        );
        
        public static readonly CustomText Deactivate = new(
            "bi bi-ban",
            "Deactivate",
            "Deaktivieren"
        );
        
        public static readonly CustomText ActivatePlayerDescription = new(
            null,
            "Shows all combinations with this player again.",
            "Zeigt alle Kombinationen mit dem Spieler wieder an."
        );
        
        public static readonly CustomText DeactivatePlayerDescription = new(
            null,
            "Hides all combinations with this player.",
            "Versteckt alle Kombinationen mit dem Spieler."
        );
        
        public static readonly CustomText Rename = new(
            "bi bi-tag",
            "Rename",
            "Umbenennen"
        );
        
        public static readonly CustomText RenamePlayerDescription = new(
            null,
            "Changes the player's name.",
            "Gibt dem Spieler einen neuen Namen."
        );
        
        public static readonly CustomText NoPointsYet = new(
            null,
            "No points were scored yet.",
            "Es wurden noch keine Punkte eingetragen."
        );
        
        public static readonly CustomText InvertA = new(
            "bi bi-arrow-down-up",
            "Invert team A",
            "Team A tauschen"
        );
        
        public static readonly CustomText InvertB = new(
            "bi bi-arrow-down-up",
            "Invert team B",
            "Team B tauschen"
        );
        
        public static readonly CustomText InvertDescription = new(
            null,
            "Corrects the positions in the team.",
            "Korrigiert die Positionen im Team."
        );
        
        public static readonly CustomText FastWinA = new(
            "bi bi-flag",
            "Team A won",
            "Team A hat gewonnen"
        );
        
        public static readonly CustomText FastWinB = new(
            "bi bi-flag",
            "Team B won",
            "Team B hat gewonnen"
        );
        
        public static readonly CustomText FastWinDescription = new(
            null,
            "Marks the match as won without exact points.",
            "Markiert das Spiel ohne genaue Punkte als gewonnen."
        );
    }
    
    public class CustomText(string? icon, string english, string german)
    {
        public readonly string? Icon = icon;
        
        public readonly Translation Translation = new
        (
            "en",
            new Dictionary<string, string>
            {
                { "en", english },
                { "de", german }
            }
        );
        
        public override string ToString()
            => this;
    
        public static implicit operator IconAndText(CustomText text)
            => new(text.Icon, text.Translation.ToString());
    
        public static implicit operator string(CustomText text)
            => text.Translation.ToString();
    }
}