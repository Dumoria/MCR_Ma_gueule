namespace MODEL{
	public class Chef : Goblin
	{

		public Chef(Model model, Emploi emploi, int salaire, Goblin collegue, Goblin superieur) : base(model, emploi, salaire, collegue, superieur)
	    {
	       
	    }

	    public new void valider(PayementSalaire salaire)
	    {
	        model.ajouterCoffre(-1 * model.getSommeSalaires());
	        occupe = false;
	    }

	    public new void passerSuperieur(Requete requete)
	    {
	        
	    }
	}
}