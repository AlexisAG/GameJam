using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Campement : MonoBehaviour {

    

    public List<GameObject> batiments; // liste des batiment dans la scene a lier dans l'editeur

    public GameObject SurvivantPrefab;
    private List<GameObject> survivants;
    public Dropdown myDropdown;
    List<string> m_DropOptions = new List<string> ();

    // Use this for initialization
    void Start () {
        survivants = new List<GameObject>();
        
        //Add the options created in the List above
        m_DropOptions = new List<string> ();

        

        for (int i=0;i < CampementData.Instance.nbSurvivant ; i++)
        {            
            GameObject go =Instantiate(SurvivantPrefab); //to do : pop random ?
            survivants.Add(go);
        }
        ResetDropDownOption();
        

    }


    public void RecolterBois()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qteBoisToAdd += nbSurvivantEnvoyé; //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void RecolterPierre()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qtePierreToAdd += nbSurvivantEnvoyé; //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void RecolterMetal()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qteMetalToAdd += nbSurvivantEnvoyé; //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void RecolterNourriture()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qteNourritureToAdd += nbSurvivantEnvoyé; //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void NewDay()
    {
        Inventaire.Instance.AddLastDayRessources();
       


        if (Inventaire.Instance.qteNourriture>= CampementData.Instance.nbSurvivant)
        {
            Inventaire.Instance.qteNourriture -= CampementData.Instance.nbSurvivant;
            CampementData.Instance.survivantContent = true;
        }
        else
        {
            int nourritureManquante = CampementData.Instance.nbSurvivant - Inventaire.Instance.qteNourriture;
            Inventaire.Instance.qteNourriture = 0;
            Famine(nourritureManquante);
        }

        CampementData.Instance.nbSurvivantNonOccupé = CampementData.Instance.nbSurvivant;
        ResetDropDownOption();

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

    void ResetDropDownOption()
    {
        myDropdown.value = 0;
        myDropdown.ClearOptions();
        m_DropOptions.Clear();
        for (int i = 0; i <= CampementData.Instance.nbSurvivantNonOccupé; i++)
        {
            m_DropOptions.Add(i.ToString());
        }
        myDropdown.AddOptions(m_DropOptions);
    }

    int EnvoyerRecolter()
    {
        int _nbSurvivantEnvoyé = myDropdown.value;
        CampementData.Instance.nbSurvivantNonOccupé -= _nbSurvivantEnvoyé;
        if (CampementData.Instance.nbSurvivantNonOccupé < 0)
            CampementData.Instance.nbSurvivantNonOccupé = 0;
        return _nbSurvivantEnvoyé;

    }
}
