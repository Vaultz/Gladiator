using System;
using System.Collections.Generic;

namespace POO_Gladiator
{
	public class Team : IComparable
	{
		private string name;
		private string description;
		private readonly List<Gladiator> composition;
		private int victories;
		private int nbDuels;
        private int victoryRatio;

		public Team(string name, string description)
		{
			this.name = name;
			this.description = description;
			this.composition = new List<Gladiator>();
			this.Victories = 0;
            this.nbDuels = 0;


		}


		public bool addGladiatorToTeam(Gladiator glad)
		{
			if (this.composition.Count < 3)
			{
				this.composition.Add(glad);
				return true;
			}

			else return false;

		}

        public bool isSomeoneStillAlive()
        {
            foreach(Gladiator glad in this.composition)
            {
                if (glad.isAlive())
                {
                    return true;
                }
            }
            return false;
        }



        // classement des équipes en fonction de leur ratio de victoires
        public int SortByVictoryRatioDescending(int ratio1, int ratio2)
        {
            return ratio1.CompareTo(ratio2);
        }

        
        public int CompareTo(object obj)
        {
            Team otherTeam = obj as Team;

            return this.getVictoryRatio().CompareTo(otherTeam.getVictoryRatio());
            
        }

        // ACCESSEURS

        public int getVictoryRatio()
		{
			return this.Victories * 100 / NbDuels;
		}

        public String Name
		{
			get
			{
				return name;
			}
		}

		public String Description
		{
			get
			{
				return description;
			}
		}

		public List<Gladiator> Composition
		{
			get
			{
				return composition;
			}
		}

        public int Victories
        {
            get
            {
                return victories;
            }

            set
            {
                victories = value;
            }
        }

        public int Defeats
        {
            get
            {
                return (nbDuels-victories);
            }

        }

        public int NbDuels
        {
            get
            {
                return nbDuels;
            }

            set
            {
                nbDuels = value;
            }
        }
    }
}
