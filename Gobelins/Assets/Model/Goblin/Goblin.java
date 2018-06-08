package MCR;

import javax.swing.text.StyledEditorKit;
import java.util.Timer;

public class Goblin{

    static int nextId = 0;
    int id;

    Emploi emploi;
    int salaire;

    int stress;
    Boolean greviste;
    Boolean occupe;

    Goblin collegue;
    Goblin superieur;
    Goblin employe;

    Timer timer;


    public Goblin(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe){
        id = nextId++;
        this.emploi = emploi;
        this.salaire = salaire;
        stress = 0;
        greviste = false;
        this.collegue = collegue;
        this.superieur = superieur;
        this.employe = employe;
    }

    public void handleRequest(Requete requete){
        if(occupe){
            passerCollegue(requete);
        }else{
            timer = new Timer(requete.getTime(emploi));
            //timer.Elapsed += requeteTerminee(requete);
            //timer.start();
            occupe = true;
        }
    }

    public void requeteTerminee(Requete requete){
        occupe = false;
        int nextTask = requete.traiter(emploi);
        if(nextTask != -1){
            if(nextTask == 0){
                passerCollegue(requete);
            }else {
                passerSuperieur(requete);
            }
        }
    }

    public void former(){
        if(emploi != Emploi.Chef){
            stress /= 2;
            salaire *= 2;
            emploi.next();

            Goblin tmp = collegue;
            collegue = superieur;
            employe = collegue;
            superieur = collegue.getSuperieur();
        }
    }

    public static int getNextId() {
        return nextId;
    }

    public static void setNextId(int nextId) {
        Goblin.nextId = nextId;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Emploi getEmploi() {
        return emploi;
    }

    public void setEmploi(Emploi emploi) {
        this.emploi = emploi;
    }

    public int getSalaire() {
        return salaire;
    }

    public void setSalaire(int salaire) {
        this.salaire = salaire;
    }

    public int getStress() {
        return stress;
    }

    public void setStress(int stress) {
        this.stress = stress;
    }

    public Boolean getGreviste() {
        return greviste;
    }

    public void setGreviste(Boolean greviste) {
        this.greviste = greviste;
    }

    public Goblin getCollegue() {
        return collegue;
    }

    public void setCollegue(Goblin collegue) {
        this.collegue = collegue;
    }

    public Goblin getSuperieur() {
        return superieur;
    }

    public void setSuperieur(Goblin superieur) {
        this.superieur = superieur;
    }

    public Goblin getEmploye() {
        return employe;
    }

    public void setEmploye(Goblin employe) {
        this.employe = employe;
    }

    public void passerCollegue(Requete requete){
        collegue.handleRequest(requete);
    }

    public void passerSuperieur(Requete requete){
        superieur.handleRequest(requete);
    }

    public void passerEmploye(Requete requete){
        employe.handleRequest(requete);
    }


}