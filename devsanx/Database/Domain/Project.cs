namespace devsanx.Database.Domain
{
	public class Project
	{
		public int UserId { get; set; }
		public int ProjectId { get; set; } // Attributes with "Id" will be translated to keys by EFCore
		public string Text { get; set; }
		public User User { get; set; }
	}
}
