using System;
namespace POO_Gladiator
{
	public class Helmet : Stuff, IArmor
	{
		public Helmet()
		{
			Name = "heaume";
			Points = 2;
		}

		public int block
		{
			get
			{
				return 10;			}
		}
	}
}
