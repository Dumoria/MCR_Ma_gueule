namespace MODEL{
	public class Chef : Goblin
	{

		public Chef(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe) : base(emploi, salaire, collegue, superieur, employe)
	    {
	       
	    }

	    public new void valider(Salaire salaire)
	    {
	        model.ajouterCoffre(-1 * model.getSommeSalaires());
	        occupe = false;
	    }

	    public new void passerSuperieur(Requete requete)
	    {
	        
	    }
	}
}