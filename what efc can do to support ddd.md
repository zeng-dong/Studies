# let EFC worry about DB mapping
* private property support via field mapping
	- modelBuilder.Entity<Team>().Property(b => b.TeamName).HasField("_teamname");
	- in model: 
		private string _teamname;
		public string TeamName => _teamname;
* private collection support
* Owned entities enable value object mapping
* Shadow properties
* Value Converters
* Keyless entities
* Many-to-Many mapping in EFC5
* more
