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
    }
}
