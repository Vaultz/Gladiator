using System;
namespace POO_Gladiator
{
	public class Dagger : Stuff, IWeapon
	{
		public Dagger()
		{
			Name = "dague";
			Points = 2;
		}

		public int hit
		{
			get
			{
				return 60;
			}
		}

		public double initiative
		{
			get
			{
				return 4;
			}
		}
	}
}
