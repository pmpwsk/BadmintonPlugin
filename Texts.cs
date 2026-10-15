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
            "bi bi-calendar-plus-fill",
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
            "Lösche alle Kombinationen mit dem Spieler."
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
            "Not enough players have been added.",
            "Es gibt nicht genug Spieler."
        );
        
        public static readonly CustomText Combination = new(
            "bi bi-calendar-event-fill",
            "Combination",
            "Kombination"
        );
        
        public static readonly CustomText Combinations = new(
            "bi bi-calendar-week-fill",
            "Combinations",
            "Kombinationen"
        );
        
        public static readonly CustomText Match = new(
            "bi bi-calendar-event-fill",
            "Match",
            "Spiel"
        );
        
        public static readonly CustomText Results = new(
            "bi bi-table",
            "Results",
            "Ergebnisse"
        );
        
        public static readonly CustomText Start = new(
            "bi bi-flag-fill",
            "Start",
            "Beginn"
        );
        
        public static readonly CustomText Actions = new(
            "bi bi-hand-index-thumb-fill",
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
        
        public static readonly CustomText CancelWithIcon = new(
            "bi bi-x-circle",
            "Cancel",
            "Abbrechen"
        );
        
        public static readonly CustomText Add = new(
            "bi bi-arrow-return-right",
            "Add",
            "Hinzufügen"
        );
        
        public static readonly CustomText Delete = new(
            "bi bi-trash-fill",
            "Delete",
            "Entfernen"
        );
        
        public static readonly CustomText Undo = new(
            "bi bi-arrow-counterclockwise",
            "Undo",
            "Rückgängig"
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