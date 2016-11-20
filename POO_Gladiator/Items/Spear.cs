using System;
namespace POO_Gladiator
{
	public class Spear : Stuff, IWeapon
	{
		public Spear()
		{
            Name = "lance";
            Points = 7;
		}

		public int hit
		{
			get
			{
				return 50;
			}
		}

		public double initiative
		{
			get
			{
				return 1;
			}
		}
	}
}
