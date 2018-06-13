/** @author Max
*/




class TraiterBeuglantes extends Requete {

	@Override
	public bool doitTraiter(Receptionniste r) {
		return true;
	}

	@Override	
	public bool doitTraiter(Chef c) {
		return true;
	}
}
