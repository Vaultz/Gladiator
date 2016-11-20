using System;
namespace POO_Gladiator
{
	public class RectangleShield : Stuff, IArmor
	{
		public RectangleShield()
		{
			Name = "pavois";
			Points = 8;
		}

		public int block
		{
			get
			{
				return 30;
			}
		}
	}
}
