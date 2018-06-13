namespace MODEL{

	public class Difficulte
	{

	    int debitRequetes;
	    int nbRequetePourEvAl;
	    int stressPrc;

		public Difficulte(int debitRequetes, int nbRequetePourEvAl, int stressPrc)
	    {
	        this.debitRequetes = debitRequetes;
			this.nbRequetePourEvAl = nbRequetePourEvAl;
	        this.stressPrc = stressPrc;
	    }

		public void niveauSuperieur(){
			debitRequetes += 2;

			if(nbRequetePourEvAl >= 5)
				nbRequetePourEvAl -= 5;

			if(100 - stressPrc >= 2)
				stressPrc += 2;
		}

	    public int getDebitRequetes()
	    {
	        return debitRequetes;
	    }

	    public void setDebitRequetes(int debitRequetes)
	    {
	        this.debitRequetes = debitRequetes;
	    }

		public int getNbRequetePourEvAl()
	    {
			return nbRequetePourEvAl;
	    }

		public void setNbRequetePourEvAl(int nbRequetePourEvAl)
	    {
			this.nbRequetePourEvAl = nbRequetePourEvAl;
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