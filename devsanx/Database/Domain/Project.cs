namespace devsanx.Database.Domain
{
	public class Project
	{
		public int DeveloperId { get; set; }
		public int ProjectId { get; set; } // Attributes with "Id" will be translated to keys by EFCore
		public string Title { get; set; }
		public string Description { get; set; }
		public Developer Developer { get; set; }
	}
}
