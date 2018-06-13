/** @author Max
*/




public class Depot extends Cash {

	public Depot (int somme) {
		 super(somme);
	}

	@Override
	public bool doitTraiter(Coffrier c) {
		return true;
	}

}

