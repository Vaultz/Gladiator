using System;
using System.Collections.Generic;

namespace POO_Gladiator
{
	// Joute représente une suite de passes entre Gladiateurs, jusqu'à ce que l'un d'eux soit touché.
	// Prend en paramètre les deux jouteurs. Renvoie le nom du vainqueur ; null si ex aequo
	//  A la fin d'une Joute, le vainqueur récupère une victoire ; le vaincu, une défaite;

	// Fonctionnement : range les armes des jouteurs dans deux tableaux comprenant autant d'indices qu'il n'y a d'armes 
	// Chaque indice est parcouru en fonction de l'initiative qu'ils représentente
	// Pour chaque incide, fait un .attack/.defend sur chaque jouteur ; si l'indice d'un des deux joueurs est vide, il ne fait rien

    

	public class Joust
	{
		private Gladiator glad1;
		private Gladiator glad2;

		// Liste des armes
		private List<IWeapon> weapons;
               
		public Joust(Gladiator g1, Gladiator g2)
		{
			glad1 = g1;
			glad2 = g2;

			Console.WriteLine(g1.Name+" VS " + g2.Name);

			weapons = new List<IWeapon>();
           
            weapons.Add(new Net());
            weapons.Add(new Spear());
            weapons.Add(new Trident());
            weapons.Add(new Sword());
            weapons.Add(new Dagger());

            startOfJoust();


        }


        // Boucle de combat
        public void startOfJoust()
        {            
            IWeapon attackWeap;

            // Tant que les deux gladiateurs sont en vie
            int i = 0;
            int nbWeap;
            while (glad1.isAlive() && glad2.isAlive())
            {
                Console.WriteLine(".");

                // On parcours la liste des armes
                attackWeap = weapons[i];

                // Si glad1 possède l'arme : attaque glad2
                if ((nbWeap = glad1.doYouOwn(attackWeap)) > 0)
                {
                    for (; nbWeap > 0; nbWeap--)
                    {
                        if (glad2.isAlive())
                            Console.WriteLine(sparring(glad1, attackWeap, glad2));
                    }
                }


                // Si glad2 possède l'arme : attaque glad1
                if ((nbWeap = glad2.doYouOwn(attackWeap)) > 0)
                {
                    for (; nbWeap > 0; nbWeap--)
                    {
                        if (glad1.isAlive())
                            Console.WriteLine(sparring(glad2, attackWeap, glad1));
                    }
                }

                // Arrivé en bas du tableau des armes, on le remonte
                if (i == 4)
                    i = 0;
                else
                    i++;

                System.Threading.Thread.Sleep(500);
            }

            // A la fin de la joute, on met les scores à jour. Adversaire vaincu = une victoire.
            if (!glad1.isAlive())
                glad2.Victories++;
            else
                glad2.Defeats++;

            if (!glad2.isAlive())
                glad1.Victories++;
            else
                glad1.Defeats++;

            // On supprime les états temporaires liés à la joute pour chaque gladiateur
            endOfJoust(glad1);
            endOfJoust(glad2);

        }

        // Méthode quirestaure les états temporaires liés à une joute
        public void endOfJoust(Gladiator glad)
        {
            // Répare les éventuels filets
            glad.fixNet();
            // Soigne les états temporaires
            glad.cureFromJoustStatus();
        }

        // sparring réalise une passe : l'un des gladiateurs tente d'attaquer avec son arme (param weap)
        // Le gladiateur attaqué (param defender) se défend avec ses protections
        // La méthode met directement à jour le statut du gladiateur à la fin de la passe : alive, dead ou paralyzed

        public string sparring(Gladiator attacker, IWeapon attackWeap, Gladiator defender)
		{
            // Si l'arme est un filet : on vérifie qu'il n'a pas déjà été utilisé au combat
            if (attackWeap is Net)
            {
                Net net = (Net)attackWeap;
                // Si elle est déjà utilisée : le glad ne peut attaquer
                if (net.UsedInDuel)
                {
                    return attacker.Name + " a déjà utilisé son filet...";
                }
                else
                    net.UsedInDuel = true;
             }

            Stuff Sweap = (Stuff)attackWeap;
            string weapName = Sweap.Name;
            string display = attacker.Name+ " attaque "+defender.Name+" avec "+weapName+"... ";
			// l'assaillant porte le coup : s'il est réussi...
			if (glad1.attack(attackWeap))
			{
                // ... et que l'arme est un filet : pas de défense, défenseur paralysé
                if (attackWeap is Net)
                {
                    defender.Status.Add("paralyzed");
                    return display + defender.Name + " est paralysé(e) !";
                }

                // Si l'arme n'est pas un filet : tentative de défense
                else
                {
                // Si la défense a réussi
                    if (defender.defense())
                    {
                        return display + defender.Name + " a bloqué le coup !";
                    }
                    // si elle a échoué
                    else
                    {
                        defender.Status.Remove("alive");
                        defender.Status.Add("dead");
                        return display + defender.Name + " est touché(e) !";
                    }
                }
			}

			// si l'attaque a échoué : fin de la passe
			return display + "mais rate son attaque.";
			                   
		}


	}
}
