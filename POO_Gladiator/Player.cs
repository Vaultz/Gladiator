using System;
using System.Collections.Generic;

namespace POO_Gladiator
{
	// Chaque joueur possède une liste de Teams

	public class Player
	{
		private string _firstname;
		private string _name;
		private string _nickname;
		private DateTime _subscription;
		private readonly List<Team> _teams;

		public Player(string nickname)
		{
			this._nickname = nickname;
			this._subscription = new DateTime();
			this._teams = new List<Team>();
		}

		public bool addTeamToPlayer(Team team)
		{
			if (_teams.Count < 5)
			{
				this._teams.Add(team);
				return true;
			}
			else
				return false;

		}

		public List<Team> teams
		{
			get
			{
				return _teams;
			}
		}
	}
}
