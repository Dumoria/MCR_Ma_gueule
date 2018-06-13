/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


/**
 *
 * @author Simon
 * @modificator Max
 */
namespace MODEL{
	public abstract class Requete
	{


	    /* Retourne un booleen suivant si le type de gobelin
	     * passé doit traiter la requête ou non. Redéfinir la
	     * méthode pour chaque type devant traiter la requête.
	     */
		public virtual bool doitTraiter(Receptionniste r) {
			return false;
		}

		public virtual bool doitTraiter(Coffrier c) {
			return false;
		}

		public virtual bool doitTraiter(Tresorier t) {
			return false;
		}

		public virtual bool doitTraiter(Tamponeur t) {
			return false;
		}
		
		public virtual bool doitTraiter(Chef c) {
			return false;
		}

		public bool doitTraiter(Goblin g) {
			return false;
		}

	}
}
