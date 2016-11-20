using System;
using System.Collections.Generic;

namespace POO_Gladiator
{
	public class Gladiator
	{
		private string _name;
		private int _equipmentScore;
		private readonly List<Stuff> _stuff;
        private int _victories;
        private int _defeats;

		// On gère les statuts d'un gladiateur sous forme de liste, en prévision d'un éventuel statut qui pourrait s'appliquer à un gladiateur mort ou vivant
		private List<string> _status; 

		public Gladiator(string name)
		{
			_name = name;
			_equipmentScore = 0;
			_stuff = new List<Stuff>();

			_status = new List<string>();
			_status.Add("alive");
		}


		// Tentative d'attaque : prend une arme en param et renvoie true si l'attaque est réussie
		public bool attack(IWeapon weapon)
		{
			Random attack = new Random();
			int attackNb = attack.Next(0, 100);
            int hitScore = weapon.hit;

            // Si le gladiateur est paralysé : deux fois moins de chances de toucher
            if (Status.Contains("paralyzed"))
                hitScore /= 2;

			if (attackNb <= hitScore)
			{
				return true;
			}

			else return false;
		}

		// Tentative de défense : parcourt les armures et renvoie true si la défense est réussie
		public bool defense()
		{
			Random defense = new Random();
			int defenseNb = defense.Next(0, 100);

			// On parcourt le stuff du défendeur
			foreach (var item in Stuff)
			{
				// Si on trouve une armure
				if (item is IArmor)
				{
					IArmor armor = (IArmor)item;
					// on fait un test de blocage
					if (defenseNb <= armor.block)
					{
						return true;
					}
				}
			}
			// Si l'on parvient à la fin du stuff sans avoir trouvé d'armure ou que tous les tests de blocage ont échoué : échec de la défense
			return false;
		}


		// Un gladiateur peut avoir jusqu'à 10 points d'équipement
		// entre 1 et N armes
		// entre 0 et N armures
		public bool AddStuffToGlad(Stuff stuff)
		{
			if ((stuff.Points + EquipmentScore) > 10)
			{
				return false;
			}

			else
			{
				_stuff.Add(stuff);
				EquipmentScore += stuff.Points;
				return true;
			}
		}

		// Prend un rang d'initiative en paramètre
		// Renvoie le nombre d'exemplaires possédés de l'arme (ex : possède deux fois l'arme : return 2 ; ne la possède pas, return 0)
		public int doYouOwn(IWeapon weap)
		{
			int nbWeap = 0;
			foreach (var item in Stuff)
			{
				if (item is IWeapon)
				{
					if (((IWeapon)item).initiative == weap.initiative)
						nbWeap++;
				}
			}
			return nbWeap;
		}

        // Cherche si le gladiateur possède un filet et le rend de nouveau utilisable au besoin
        public void fixNet()
        {
            foreach(Stuff item in Stuff)
            {
                if (item is Net)
                {
                    Net net = (Net)item;
                    net.UsedInDuel = false;
                }
            }
        }

        // Soigne tous les états temporaires
        public void cureFromJoustStatus()
        {
            if (Status.Contains("paralyzed"))
                Status.Remove("paralyzed");
            
        }

		//*** ACCESSEURS ***/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>

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

		public List<Stuff> Stuff
		{
			get
			{
				return _stuff;
			}
		}

		public int EquipmentScore
		{
			get
			{
				return _equipmentScore;
			}

			set
			{
				_equipmentScore = value;
			}
		}

		public List<string> Status
		{
			get
			{
				return _status;
			}
		}

        public int Victories
        {
            get
            {
                return _victories;
            }

            set
            {
                _victories = value;
            }
        }

        public int Defeats
        {
            get
            {
                return _defeats;
            }

            set
            {
                _defeats = value;
            }
        }

        public Boolean isAlive()
        {
            if (this.Status.Contains("alive"))
                return true;

            else return false;
        }


	}
}