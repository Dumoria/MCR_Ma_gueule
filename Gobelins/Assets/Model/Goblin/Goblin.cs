public class Goblin{

    static int nextId = 0;
    int id;

    Emploi emploi;
    int salaire;

    int stress;
    bool greviste;

    Goblin* collegue;
    Goblin* superieur;
    Goblin* employe;

    public Goblin(Emploi emploi, int salaire, Goblin* collegue, Goblin* superieur, Goblin* employe){
        id = nextId++;
        this.emploi = emploi;
        this.salaire = salaire;
        stress = 0;
        greviste = false;
        this.collegue = collegue;
        this.superieur = superieur;
        this.employe = employe;
    }

    public handleRequest(Requete requete){

    }

    public void former(){
        if(emploi != 4){
            stress /= 2;
            salaire++;
            emploi++;

            Goblin* tmp = collegue;
            collegue = superieur;
            employe = collegue;
            superieur = collegue.getSuperieur();


        }
    }

    public void passerCollegue(Requete requete){
        collegue->handleRequest(requete);
    }

    public void passerSuperieur(Requete requete){
        superieur->handleRequest(requete);
    }

    public void passerEmploye(Requete requete){
        employe->handleRequest(requete);
    }


}