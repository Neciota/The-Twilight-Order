namespace TheTwilightOrder.Shared.Models.Game
{
	public class Region
	{
        public Region(string code, string name, int pointsPresence, int pointsControl, int pointsDominance)
        {
			Code = code;
            Name = name;
			PointsPresence = pointsPresence;
			PointsControl = pointsControl;
			PointsDominance = pointsDominance;
        }

		public string Code { get; set; }
        public string Name { get; set; }
		public List<Country> Countries { get; set; } = new List<Country>();
		public int PointsPresence { get; set; }
		public int PointsControl { get; set; }
		public int PointsDominance { get; set; }
	}
}
