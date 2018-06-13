using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MODEL{
	public class PoudreDePhenix : BonusModel {
		public static int niveauPoudre=0;
		public PoudreDePhenix():base(){}
	public int getNiveauPoudre(){
		return niveauPoudre;
	}
	public void setNiveauPoudre(int niveau){
		this.niveauPoudre=niveau;
	}
	}
}