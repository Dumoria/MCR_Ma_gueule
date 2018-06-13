using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde : BonusModel {
	public static int niveauSecurite=0;

public Garde :base(){}
public int getNiveauSecurite(){
	return niveauSecurite;
}
public void setNiveauSecurite(int niveau){
	this.niveauSecurite=niveau;
}
}
