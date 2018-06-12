/** @author Max
*/

using Cash


class Depot : Cash {

	public Depot (int somme) : base(somme) {}

	public override bool doitTraiter(Coffrier c) {
		return true;
	}

}
