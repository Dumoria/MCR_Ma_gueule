package MCR;

public enum Emploi
{
    Receptionniste,
    Coffrier,
    Tresorier,
    Tamponeur, Chef;

    private static Emploi[] vals = values();

    public Emploi next(){
        return vals[(this.ordinal()+1) % vals.length];
    }
}