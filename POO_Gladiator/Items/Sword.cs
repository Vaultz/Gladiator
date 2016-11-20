using System;
namespace POO_Gladiator
{
	public class Sword : Stuff, IWeapon
	{
		public Sword()
		{
			Name = "épée";
			Points = 5;
		}

		public int hit
		{
			get
			{
				return 70;
			}
		}

		public double initiative
		{
			get
			{
				return 3;
			}
		}
	}
}
