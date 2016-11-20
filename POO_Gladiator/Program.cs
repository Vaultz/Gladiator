using System;

namespace POO_Gladiator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			
			Player p1 = new Player("Vault_");

			Team tCody = new Team("Team Cody", "C'est nous les plus costauds !");
			Team tOpaline = new Team("Team Opaline", "Sans Palouf dans l'équipe, on ne peut que gagner.");
			Team tDust = new Team("Team Dust", "La team la plus sexy de la création.");
			Team tLadypig = new Team("Team Madame Cochon", "Grouik ?");
			
			Gladiator cody = new Gladiator("Cody");
			Gladiator samson = new Gladiator("Samson");
			Gladiator ezechiel = new Gladiator("Ezéchiel");
			Gladiator opaline = new Gladiator("Opaline");
			Gladiator capuche = new Gladiator("Capuche");
            Gladiator ode = new Gladiator("Ode");
            Gladiator dust = new Gladiator("Dust");
            Gladiator esteban = new Gladiator("Esteban");
            Gladiator roger = new Gladiator("Roger");
            Gladiator ladypig = new Gladiator("Madame Cochon");
            Gladiator palouf = new Gladiator("Palouf");
            Gladiator geolier = new Gladiator("le Geôlier");

            Sword sword = new Sword();      // 5 pts
            Dagger dagger = new Dagger();   // 2 pts
            Net net = new Net();            // 3 pts
            Trident trident = new Trident();    // 7 pts
            Helmet helmet = new Helmet();   // 2 pts
            Spear spear = new Spear();      // 7 pts
            RectangleShield res = new RectangleShield();    // 8 pts
            RoundShield ros = new RoundShield();    // 5 pts

            cody.AddStuffToGlad(sword);
            cody.AddStuffToGlad(sword);
            samson.AddStuffToGlad(spear);
            samson.AddStuffToGlad(dagger);
            capuche.AddStuffToGlad(ros);
            capuche.AddStuffToGlad(sword);
            ezechiel.AddStuffToGlad(trident);
            ezechiel.AddStuffToGlad(helmet);
            opaline.AddStuffToGlad(res);
            opaline.AddStuffToGlad(dagger);
            ode.AddStuffToGlad(ros);
            ode.AddStuffToGlad(net);
            dust.AddStuffToGlad(sword);
            dust.AddStuffToGlad(sword);
            esteban.AddStuffToGlad(spear);
            esteban.AddStuffToGlad(dagger);
            roger.AddStuffToGlad(ros);
            roger.AddStuffToGlad(sword);
            ladypig.AddStuffToGlad(trident);
            ladypig.AddStuffToGlad(helmet);
            palouf.AddStuffToGlad(res);
            palouf.AddStuffToGlad(dagger);
            geolier.AddStuffToGlad(ros);
            geolier.AddStuffToGlad(net);

            p1.addTeamToPlayer(tCody);
			p1.addTeamToPlayer(tOpaline);
			p1.addTeamToPlayer(tDust);
			p1.addTeamToPlayer(tLadypig);

            tCody.addGladiatorToTeam(cody);
            tCody.addGladiatorToTeam(samson);
            tCody.addGladiatorToTeam(capuche);

            tOpaline.addGladiatorToTeam(ezechiel);
            tOpaline.addGladiatorToTeam(opaline);
            tOpaline.addGladiatorToTeam(ode);

            tDust.addGladiatorToTeam(dust);
            tDust.addGladiatorToTeam(esteban);
            tDust.addGladiatorToTeam(roger);

            tLadypig.addGladiatorToTeam(ladypig);
            tLadypig.addGladiatorToTeam(geolier);
            tLadypig.addGladiatorToTeam(palouf);

            tCody.NbDuels = 78;
            tCody.Victories = 65;
            tOpaline.NbDuels = 78;
            tOpaline.Victories = 6;
            tDust.NbDuels = 78;
            tDust.Victories = 55;
            tLadypig.NbDuels = 78;
            tLadypig.Victories = 78;

            new Tournament(p1.teams);
                  
   
        }
    }
}
