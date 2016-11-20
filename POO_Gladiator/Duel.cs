using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Gladiator
{
    // Un duel prend en paramètre deux équipes et fait jouter leurs gladiateurs
    class Duel
    {
        private Team team1;
        private Team team2;
        private Team winner;

        public Duel(Team t1, Team t2)
        {
            this.team1 = t1;
            this.team2 = t2;
            
            int i =0, j =0;
            
            int nbGlad1 = team1.Composition.Count;
            int nbGlad2 = team2.Composition.Count;
            Gladiator jouster1, jouster2;

            // i et j correspondent au nombre de gladiateurs vaincus par team
            // par conséquent, on continue le duel tant que ce nombre n'atteint pas le nombre total de glads d'une team
            //Console.WriteLine(nbGlad1d);
            Console.WriteLine("### " + team1.Name + " VERSUS " + team2.Name + " ###");
            while ((i < nbGlad1) && (j < nbGlad2))
            {
                jouster1 = team1.Composition[i];
                jouster2 = team2.Composition[j];

                new Joust(jouster1, jouster2);

                if (!jouster1.isAlive())
                {
                    Console.WriteLine(jouster1.Name + " a perdu !");
                    i++;
                }

                if (!jouster2.isAlive())
                {
                    Console.WriteLine(jouster2.Name + " a perdu !");
                    j++;
                }
                
            }

            // au sortir de la boucle, deux cas possibles
            if (!(team1.isSomeoneStillAlive()) && !(team2.isSomeoneStillAlive()))
            {
                Console.WriteLine("Duel : Ex Aequo !");
                team1.Victories++;
                team2.Victories++;
            }
            else
            {
                if (team1.isSomeoneStillAlive())
                {
                    Console.WriteLine("Duel : "+team1.Name + " l'emporte !");
                    team1.Victories++;
                    this.Winner = team1;

                }
                if (team2.isSomeoneStillAlive())
                {
                    Console.WriteLine(team2.Name+" l'emporte !");
                    team2.Victories++;
                    this.Winner = team2;
                }
            }
            team1.NbDuels++;
            team2.NbDuels++;

            // Fin du combat : restauration des statuts
            
        }

        public Team Winner
        {
            get
            {
                return winner;
            }

            set
            {
                winner = value;
            }
        }
    }
}
