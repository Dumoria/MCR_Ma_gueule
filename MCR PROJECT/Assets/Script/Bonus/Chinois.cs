using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MODEL{
	public class Chinois : BonusModel {
	public static int niveauTraiteur=0;
		public Chinois():base(){}
	public int getNiveauTraiteur(){
		return niveauTraiteur;
	}
	public void setNiveauTraiteur(int niveau){
		this.niveauTraiteur=niveau;
	}
	}
}