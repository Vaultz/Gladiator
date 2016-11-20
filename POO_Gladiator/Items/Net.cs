using System;
namespace POO_Gladiator
{
    // Le filet ne peut-être utilisé qu'une fois par duel
    // Ne peut-être bloqué par une armure
    // Provoque la paralysie
	public class Net : Stuff, IWeapon
	{
		private bool usedInDuel;
		public Net()
		{
			Name = "filet";
			Points = 3;
			this.usedInDuel = false;
		}

 
		public int hit
		{
			get
			{
				return 30;
			}
		}

		public double initiative
		{
			get
			{
				return 0;
			}
		}

        public bool UsedInDuel
        {
            get
            {
                return usedInDuel;
            }

            set
            {
                usedInDuel = value;
            }
        }
    }
}
