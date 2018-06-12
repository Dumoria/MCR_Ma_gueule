public class Tresorier : Goblin
{

    Model model;

    public Tresorier(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe)
    {
        super(emploi, salaire, collegue, superieur, employe);
    }

    public void valider(Retrait retrait)
    {
        occupe = false;
        model.addCoffre(-1 * requete.getSomme());
        passerSuperieur(requete);
    }

    public void valider(Depot depot)
    {
        occupe = false;
        model.addCoffre(requete.getSomme());
        passerSuperieur(requete);
    }

    public void valider(Remboursement remboursement)
    {
        occupe = false;
        model.addCoffre(requete.getSomme());
        passerSuperieur(requete);
    }

    public void valider(Emprunt emprunt)
    {
        occupe = false;
        model.addCoffre(-1 * requete.getSomme());
        passerSuperieur(requete);
    }
}
