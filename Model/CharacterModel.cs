namespace XIV.Models
{
    public class PaginationModel
    {
        public int Page { get; set; }
        public int? PageNext { get; set; }
        public int? PagePrev { get; set; }
        public int PageTotal { get; set; }
        public int Results { get; set; }
        public int ResultsPerPage { get; set; }
        public int ResultsTotal { get; set; }
    }

    public class CharacterSearch
    {
        public string? Avatar { get; set; }
        public int? FeastMatches { get; set; }
        public int? ID { get; set; }
        public string? Lang { get; set; }
        public string? Name { get; set; }
        public string? Rank { get; set; }
        public string? RankIcon { get; set; }
        public string? Server { get; set; }
    }

    public class CharacterSearchResponse
    {
        public PaginationModel? Pagination { get; set; }
        public List<CharacterSearch>? Results { get; set; }
    }
}
