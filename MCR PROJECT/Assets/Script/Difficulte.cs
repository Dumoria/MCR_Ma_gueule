namespace MODEL{

	public class Difficulte
	{

	    int debitRequetes;
	    int tauxBraquages;
	    int stressPrc;

	    public Difficulte(int debitRequetes, int tauxBraquages, int stressPrc)
	    {
	        this.debitRequetes = debitRequetes;
	        this.tauxBraquages = tauxBraquages;
	        this.stressPrc = stressPrc;
	    }

	    public int getDebitRequetes()
	    {
	        return debitRequetes;
	    }

	    public void setDebitRequetes(int debitRequetes)
	    {
	        this.debitRequetes = debitRequetes;
	    }

	    public int getTauxBraquages()
	    {
	        return tauxBraquages;
	    }

	    public void setTauxBraquages(int tauxBraquages)
	    {
	        this.tauxBraquages = tauxBraquages;
	    }

	    public int getStressPrc()
	    {
	        return stressPrc;
	    }

	    public void setStressPrc(int stressPrc)
	    {
	        this.stressPrc = stressPrc;
	    }

	}
}