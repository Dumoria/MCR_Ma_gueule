public class Tresorier : Goblin
{

    Model model;

    public new Tresorier(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe)
    {
        super(emploi, salaire, collegue, superieur, employe);
    }

    public new void valider(Retrait retrait)
    {
        model.addCoffre(-1 * requete.getSomme());
        passerSuperieur(requete);
        occupe = false;
    }

    public new void valider(Depot depot)
    {
        model.addCoffre(requete.getSomme());
        passerSuperieur(requete);
        occupe = false;
    }

    public new void valider(Remboursement remboursement)
    {
        model.addCoffre(requete.getSomme());
        passerSuperieur(requete);
        occupe = false;
    }

    public new void valider(Emprunt emprunt)
    {
        model.addCoffre(-1 * requete.getSomme());
        passerSuperieur(requete);
        occupe = false;
    }
}
