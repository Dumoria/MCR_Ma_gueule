public class Chef : Goblin
{

    public Chef(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe)
    {
        super(emploi, salaire, collegue, superieur, employe);
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
