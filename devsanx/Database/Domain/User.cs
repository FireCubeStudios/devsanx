﻿namespace devsanx.Database.Domain
{
	public class User
	{
		public int UserId { get; set; } // Attributes with "Id" will be translated to keys by EFCore
		public string Name { get; set; }
		public ICollection<Project> Projects { get; set; }
	}
}