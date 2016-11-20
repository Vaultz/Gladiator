using System;
namespace POO_Gladiator
{
	public class RoundShield : Stuff, IArmor
	{
		public RoundShield()
		{
			Name = "targe";
			Points = 5;
		}

		public int block
		{
			get
			{
				return 20;			
			}
		}
	}
}
