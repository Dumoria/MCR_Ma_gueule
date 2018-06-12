/** @author Max
*/


namespace MODEL{
	
	abstract class CertificatFortune : Requete {

		public CertificatFortune (int somme) : base(somme) {}

		public override bool doitTraiter(Receptionniste r) {
			return true;
		}

		public override bool doitTraiter(Tamponeur t) {
			return true;
		}
	}

}