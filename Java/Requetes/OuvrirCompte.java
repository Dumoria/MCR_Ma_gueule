/** @author Max
*/



class OuvrirCompte extends Requete {

	@Override
	public bool doitTraiter(Receptionniste r) {
		return true;
	}

	@Override
	public bool doitTraiter(Coffrier c) {
		return true;
	}

	@Override
	public bool doitTraiter(Tamponeur t) {
		return true;
	}

	@Override
	public bool doitTraiter(Chef c) {
		return true;
	}
}
