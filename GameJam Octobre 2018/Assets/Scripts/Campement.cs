using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campement : MonoBehaviour {

    public int nbSurvivant;
    public bool survivantContent;
    public List<GameObject> batiments; // liste des batiment dans la scene a lier dans l'editeur
    public List<Soldat> soldats;
    public Inventaire inventaire;
    public List<Mission> missionsDisponible;

    public GameObject SurvivantPrefab;
    private List<GameObject> survivants;

	// Use this for initialization
	void Start () {
        nbSurvivant = 2;


        for (int i=0;i<nbSurvivant;i++)
        {
            Instantiate(SurvivantPrefab); //to do : pop random ?
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}

    void RecolterBois(int nbSurvivantEnvoye)
    {

    }

    void NewDay()
    {
        if(Inventaire.Instance.qteNourriture>=nbSurvivant)
        {
            for (int i = 0; i < nbSurvivant; i++)
            {
                Inventaire.Instance.qteNourriture -= nbSurvivant;
            }
        }
        else
        {
            int nourritureManquante = nbSurvivant - Inventaire.Instance.qteNourriture;
            Inventaire.Instance.qteNourriture = 0;
            Famine(nourritureManquante);
        }
        
    }

    //perte de survivant
    void Famine(int _nourritureManquante)
    {
        


    }
}
