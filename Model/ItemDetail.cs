namespace XIV.Models 
{
    //TODO: This is a very incomplete class, if you wish to add more fields, see: ItemDetails.json
    public record class ItemDetail
    {
	public GamePatch? GamePatch {get;set;}
	public string? IconHD {get;set;}
	public string? Name {get;set;}	
    }

    public record class GamePatch
    {
	//The patch this piece was added
        public string? Name {get;set;}
    }
}
