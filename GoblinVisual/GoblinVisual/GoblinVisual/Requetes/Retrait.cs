/** @author Max
*/

using Cash


class Retrait : Cash {

	public Retrait (int somme) : base(somme) {}

	public override bool doitTraiter(Coffrier c) {
		return true;
	}

}
