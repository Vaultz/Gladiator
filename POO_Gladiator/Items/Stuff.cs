namespace POO_Gladiator
{
	public abstract class Stuff
	{
		private string _name;
		private int _points;

		public Stuff()
		{
		}

		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		public int Points
		{
			get
			{
				return _points;
			}

			set
			{
				_points = value;
			}
		}
	}
}