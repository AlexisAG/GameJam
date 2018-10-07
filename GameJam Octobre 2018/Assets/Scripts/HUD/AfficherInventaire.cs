using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficherInventaire : MonoBehaviour {

    public Text affBois;
    public Text affNourriture;
    public Text affPierre;
    public Text affMetal;
    public Text affdate;
    public Text affnbSurv;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        affBois.text = "Bois : " + Inventaire.Instance.qteBois + " (+" + Inventaire.Instance.qteBoisToAdd+ ")";
        affNourriture.text = "Nourriture : " + Inventaire.Instance.qteNourriture + " (+" + Inventaire.Instance.qteNourritureToAdd + ")";
        affPierre.text = "Pierre : " + Inventaire.Instance.qtePierre + " (+" + Inventaire.Instance.qtePierreToAdd + ")";
        affMetal.text = "Metal : " + Inventaire.Instance.qteMetal + " (+" + Inventaire.Instance.qteMetalToAdd + ")";
        affdate.text = "Date : " + Environnement.Instance.JoursPasses;
        affnbSurv.text = "Survivants : " + CampementData.Instance.nbSurvivant;
    }
}
