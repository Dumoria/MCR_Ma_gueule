using Retrait;

namespace MODEL{
	public class Tresorier : Goblin
	{

	    Model model;

		public Tresorier(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe) : base(emploi, salaire, collegue, superieur, employe)
	    {
	    }

	    public new void valider(Retrait retrait)
	    {
	        model.ajouterCoffre(-1 * requete.getSomme());
	        passerSuperieur(requete);
	        occupe = false;
	    }

	    public new void valider(Depot depot)
	    {
			model.ajouterCoffre(requete.getSomme());
	        passerSuperieur(requete);
	        occupe = false;
	    }

	    public new void valider(Remboursement remboursement)
	    {
			model.ajouterCoffre(requete.getSomme());
	        passerSuperieur(requete);
	        occupe = false;
	    }

	    public new void valider(Emprunt emprunt)
	    {
			model.ajouterCoffre(-1 * requete.getSomme());
	        passerSuperieur(requete);
	        occupe = false;
	    }
	}
}