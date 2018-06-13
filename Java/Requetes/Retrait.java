/** @author Max
*/



public class Retrait extends Cash {

	public Retrait (int somme)  {
		 super(somme);
	}

	@Override
	public bool doitTraiter(Coffrier c) {
		return true;
	}

}
