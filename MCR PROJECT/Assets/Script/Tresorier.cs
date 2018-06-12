using Retrait;

namespace MODEL{
	public class Tresorier : Goblin
	{

	    Model model;

		public Tresorier(Model model, Emploi emploi, int salaire, Goblin collegue, Goblin superieur) : base(model, emploi, salaire, collegue, superieur)
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