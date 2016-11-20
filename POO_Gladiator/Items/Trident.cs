using System;
namespace POO_Gladiator
{
	public class Trident : Stuff, IWeapon, IArmor
	{
		public Trident()
		{
			Name = "trident";
			Points = 7;
		}

		public int block
		{
			get
			{
				return 10;			}
		}

		public int hit
		{
			get
			{
				return 40;			}
		}

		public double initiative
		{
			get
			{
				return 2;
			}
		}
	}
}
