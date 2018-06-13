/** @author Max
*/



	
class CertificatFortune extends Cash {

	public CertificatFortune (int somme) {
		super(somme);
	}

	@Override
	public bool doitTraiter(Receptionniste r) {
		return true;
	}

	@Override
	public bool doitTraiter(Tamponeur t) {
		return true;
	}
}

