using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campement : MonoBehaviour {

    

    public List<GameObject> batiments; // liste des batiment dans la scene a lier dans l'editeur

    public GameObject SurvivantPrefab;
    private List<GameObject> survivants;

	// Use this for initialization
	void Start () {

        
        for (int i=0;i <= CampementData.Instance.nbSurvivant ; i++)
        {
            GameObject go =Instantiate(SurvivantPrefab); //to do : pop random ?
            survivants.Add(go);
        }
        
    }


    void RecolterBois(int nbSurvivantEnvoye)
    {

    }

    void RecolterPierre(int nbSurvivantEnvoye)
    {

    }

    void RecolterMetal(int nbSurvivantEnvoye)
    {

    }

    void NewDay()
    {
        if(Inventaire.Instance.qteNourriture>= CampementData.Instance.nbSurvivant)
        {
            for (int i = 0; i < CampementData.Instance.nbSurvivant; i++)
            {
                Inventaire.Instance.qteNourriture -= CampementData.Instance.nbSurvivant;
                CampementData.Instance.survivantContent = true;
            }
        }
        else
        {
            int nourritureManquante = CampementData.Instance.nbSurvivant - Inventaire.Instance.qteNourriture;
            Inventaire.Instance.qteNourriture = 0;
            Famine(nourritureManquante);
        }
        
    }

    //perte de survivant
    void Famine(int _nourritureManquante)
    {
        if (CampementData.Instance.survivantContent)
            CampementData.Instance.survivantContent = !CampementData.Instance.survivantContent;

        else//les tuer ses ptits batard
        {
            CampementData.Instance.nbSurvivant -= _nourritureManquante;
            if(CampementData.Instance.nbSurvivant <=0)
            {
                //perdu
            }
        }

    }
}
