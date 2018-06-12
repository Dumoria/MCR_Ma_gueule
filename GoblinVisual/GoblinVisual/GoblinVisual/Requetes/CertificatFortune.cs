/** @author Max
*/

using Requete


abstract class CertificatFortune : Requete {

	public CertificatFortune (int somme) : base(somme) {}

	public override bool doitTraiter(Receptionniste r) {
		return true;
	}

	public bool doitTraiter(Tamponneur t) {
		return true;
	}
}
