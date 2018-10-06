using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : MonoBehaviour {

    private Etat etatSoldat;
    private bool estEnnemi;
    private int niveauSoldat;
    private int nbPaSoldat;
    private TypeCombattant combattant;

    public Soldat(int idSoldat){
        this.niveauSoldat = 1;
        etatSoldat = new Etat();
        // 1 pour Guerrier
        if(idSoldat == 1)
            combattant = new Guerrier();
        // 2 pour Assassin
        if (idSoldat == 2)
            combattant = new Assassin();
        // 3 pour Sniper
        if (idSoldat == 3)
            combattant = new Sniper();
        // 4 pour Eclaireur
        if (idSoldat == 4)
            combattant = new Eclaireur();
    }

    public void CheckEtat(){

        if(this.etatSoldat.NomEtat == Etat.etatFaible){
            combattant.PasAssezDeNourriture();
            etatSoldat.PasAssezDeNourriture();
        }
        if (this.etatSoldat.NomEtat == Etat.etatNeutre)
        {
            combattant.NourritureOk();
            etatSoldat.NourritureOk();
        }
        if (this.etatSoldat.NomEtat == Etat.etatEnForme)
        {
            combattant.TropDeNourriture();
            etatSoldat.TropDeNourriture();
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
