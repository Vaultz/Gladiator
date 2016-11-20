using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Gladiator
{

    // Cette classe récupère une liste (paire) d'équipes, les classe par ratio de victoire et créé autant de duels qu'il n'y a de paires
    class Tournament
    {
        private List<Team> participants;
        private List<Team> winners;

        public Tournament(List<Team> p)
        {

            Participants = p;
            winners = new List<Team>();

            // on vérifie que le nombre d'équipes soit pair
            if (Participants.Count%2 != 0)
            {
                throw new Exception("Nombre d'équipes incorrect ; veuillez entrer un nombre pair.");
            }

            // on classe les équipes par ratio de victoires (nécessite d'avoir réécrit le CompareTo de Team)
            Participants.Sort();

            // Puis on fait jouer les équipes par paires.
            int i = 0;
            while (i < Participants.Count)
            {
                Duel duel = new Duel(Participants[i], Participants[i+1]);
                if (duel.Winner == null)
                    Console.WriteLine("Tournament : pas de gagnant.");
                else
                {
                    winners.Add(duel.Winner);
                }
                i += 2;
            }

            Console.WriteLine("Le tournoi est terminé ! Les vainqueurs sont :");
            foreach(Team team in winners)
            {
                Console.WriteLine(" - " + team.Name);
            }
        }

        public List<Team> Participants
        {
            get
            {
                return participants;
            }

            set
            {
                participants = value;
            }
        }
    }
}
