namespace XIV.Models
{

    public record class CharacterDetail
    {
        public ActiveClassJob? ActiveClassJob { get; set; }
    }

    public record class ActiveClassJob
    {
        public int ClassID { get; set; }
        public int ExpLevelMax { get; set; }
        public int ExpLevelTogo { get; set; }
        public bool IsSpecialised { get; set; }
        public int JobID { get; set; }
        public int Level { get; set; }
        public string? Name { get; set; }
        public UnlockedState? UnlockedState { get; set; }
    }

    public record class UnlockedState
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }

    public record class CharacterDetailResponse
    {
        public object? Achievements { get; set; }
        public object? AchievementsPublic { get; set; }
        public CharacterDetail? Character { get; set; }
    }
}
