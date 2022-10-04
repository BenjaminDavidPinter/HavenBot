using System.Text.Json.Serialization;

namespace XIV.Models
{

    public record class CharacterDetail
    {
	//Users current active job & information
	public ClassJob? ActiveClassJob { get; set; }

	//Link to user's small headshot profile picture
	public string? Avatar { get; set; }

	//Users in game bio
	public string? Bio { get; set; }

	//Full readout of jobs and their respective levels
	public List<ClassJob>? ClassJobs { get; set; }

	public ClassJobsBozjan? ClassJobsBozjan {get;set;}

        public ClassJobsElemental? ClassJobsElemental {get;set;}

	//Datacenter
	public string? DC {get;set;}

	public string? FreeCompanyId {get;set;}
	public string? FreeCompanyName {get;set;}

	//Gear information	
	public GearSet? GearSet {get;set;}

	public int? Gender {get;set;}

	public GrandCompany? GrandCompany {get;set;}
    	
	public int? GuardianDeity {get;set;}
	public int ID {get;set;}
	public string? Lang {get;set;}
	public string? Name {get;set;}
	public string? NamesDay {get;set;}
	public int? ParseDate {get;set;}
	public string? Portrait {get;set;}
	public int? PvPTeamId {get;set;}
	public int? Race {get;set;}
	public string? Server {get;set;}
	public int? Title {get;set;}
	public bool? TitleTop {get;set;}
	public int? Town {get;set;}
	public int? Tribe {get;set;} 
    }

    public record class GrandCompany
    {
	public int? NameID {get;set;}
	public int? RankID {get;set;}
    }

    public record class GearSet 
    {	
	public Attributes? Attributes {get;set;}
	public Gear? Gear {get;set;}
	public string? GearKey {get;set;}
	public int? JobID {get;set;}
	public int Level {get;set;}  
    }

    public record class Gear 
    {
	public GearItem? Body {get;set;}
	public GearItem? Bracelets {get;set;}
	public GearItem? Earrings {get;set;}
	public GearItem? Feet {get;set;}
	public GearItem? Hands {get;set;}
	public GearItem? Head {get;set;}
	public GearItem? Legs {get;set;}
	public GearItem? MainHand {get;set;}
	public GearItem? Necklace {get;set;}
	public GearItem? Ring1 {get;set;}
	public GearItem? Ring2 {get;set;}
	public GearItem? SoulCrystal {get;set;} 
    }

    public record class GearItem
    {
	public string? Creator {get;set;}
	public int? Dye {get;set;}
	public int? ID {get;set;}
	public List<int>? Materia {get;set;}
	public int? Mirage {get;set;}
    }

    //TODO: Someone needs to figure out what attribute maps to which label in XIV
    public record class Attributes 
    {

	[JsonPropertyName("1")]
	public int? Unknown_Attr1 {get;set;}
 
	[JsonPropertyName("2")]
	public int? Unknown_Attr2 {get;set;}
 
	[JsonPropertyName("3")]
	public int? Unknown_Attr3 {get;set;}
 
	[JsonPropertyName("4")]
	public int? Unknown_Attr4 {get;set;}
 
	[JsonPropertyName("5")]
	public int? Unknown_Attr5 {get;set;}
 
	[JsonPropertyName("6")]
	public int? Unknown_Attr6 {get;set;}
 
	[JsonPropertyName("7")]
	public int? Unknown_Attr7 {get;set;}
 
	[JsonPropertyName("8")]
	public int? Unknown_Attr8 {get;set;}
 
	[JsonPropertyName("19")]
	public int? Unknown_Attr19 {get;set;}
 
	[JsonPropertyName("20")]
	public int? Unknown_Attr20 {get;set;}
 
	[JsonPropertyName("21")]
	public int? Unknown_Attr21 {get;set;}
 
	[JsonPropertyName("22")]
	public int? Unknown_Attr22 {get;set;}
 
	[JsonPropertyName("24")]
	public int? Unknown_Attr24 {get;set;}
 
	[JsonPropertyName("27")]
	public int? Unknown_Attr27 {get;set;}
 
	[JsonPropertyName("33")]
	public int? Unknown_Attr33 {get;set;}
 
	[JsonPropertyName("34")]
	public int? Unknown_Attr34 {get;set;}
 
	[JsonPropertyName("44")]
	public int? Unknown_Attr44 {get;set;}
 
	[JsonPropertyName("45")]
	public int? Unknown_Attr45 {get;set;}
 
	[JsonPropertyName("46")]
	public int? Unknown_Attr46 {get;set;}
    	
    }

    public record class ClassJob
    {
	public int ClassID { get; set; }
	public int ExpLevel { get; set; }
	public int ExpLevelMax { get; set; }
	public int ExpLevelTogo { get; set; }
	public bool IsSpecialised { get; set; }
	public int JobID { get; set; }
	public int Level { get; set; }
	public string? Name { get; set; }
	public UnlockedState? UnlockedState { get; set; }
    }

    public record class ClassJobsBozjan {
	public int? Level {get;set;}
	public int? Mettle {get;set;}
	public string? Name {get;set;}
    }

    public record class ClassJobsElemental {
    	public int? ExpLevel {get;set;}
	public int? ExpLevelMax {get;set;}
	public int? ExpLevelTogo {get;set;}
	public int? Level {get;set;}
	public string? Name {get;set;}
    }

    public record class UnlockedState
    {
	public int? ID { get; set; }
	public string? Name { get; set; }
    }

    public record class CharacterDetailResponse
    {
	public object? Achievements { get; set; }
	public object? AchievementsPublic { get; set; }
	public CharacterDetail? Character { get; set; }
	//TODO: Implement these
	public object? FreeCompany {get;set;}
	public object? FreeCompanyMembers {get;set;}
	public object? Friends {get;set;}
	public object? FriendsPublic {get;set;}
	public object? Minions {get;set;}
	public object? Mounts {get;set;}
	public object? PvPTeam {get;set;}
    }
}
