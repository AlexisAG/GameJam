using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Campement : MonoBehaviour {

    

    public List<GameObject> batiments; // liste des batiment dans la scene a lier dans l'editeur

    public GameObject SurvivantPrefab;
    private List<GameObject> survivants;
    public Dropdown myDropdown;
    List<string> m_DropOptions = new List<string>();

    // Use this for initialization
    void Start () {

        

        survivants = new List<GameObject>();

        //Add the options created in the List above
        m_DropOptions = new List<string>();

        for (int i=0;i <= CampementData.Instance.nbSurvivant ; i++)
        {
            //GameObject go =Instantiate(SurvivantPrefab); //to do : pop random ?
            //survivants.Add(go);
        }
        ResetDropDownOption();
        if (CampementData.Instance.partiEnMission)
        {
            NewDay();
            CampementData.Instance.partiEnMission = false;
        }
            
    }


    public void RecolterBois()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qteBoisToAdd +=Mathf.RoundToInt( nbSurvivantEnvoyé * RessourcesManager.RatioRecolteBois() * 2); //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void RecolterPierre()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qtePierreToAdd += Mathf.RoundToInt(nbSurvivantEnvoyé * RessourcesManager.RatioRecolteBois() * 4); ; //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void RecolterMetal()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qteMetalToAdd += Mathf.RoundToInt(nbSurvivantEnvoyé * RessourcesManager.RatioRecolteBois() * 1); ; //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void RecolterNourriture()
    {
        int nbSurvivantEnvoyé = EnvoyerRecolter();
        Inventaire.Instance.qteNourritureToAdd += Mathf.RoundToInt(nbSurvivantEnvoyé * RessourcesManager.RatioRecolteNourriture() * 2); ; //a modifier en fonction de ressource manager        
        ResetDropDownOption();
    }

    public void NewDay()
    {
        Environnement.Instance.UpdateEnvironnement();
        Inventaire.Instance.AddLastDayRessources();

        int qteNourritureBesoin = Mathf.RoundToInt( ( CampementData.Instance.nbSurvivant + CampementData.Instance.soldats.Count * 4) * RessourcesManager.RatioBesoin() );
        int qteNourritureFestin = Mathf.RoundToInt( (  CampementData.Instance.nbSurvivant + CampementData.Instance.soldats.Count * 6) * RessourcesManager.RatioFestin()     );
        if (Inventaire.Instance.qteNourriture >= qteNourritureBesoin)
        {
            if (Inventaire.Instance.qteNourriture >= qteNourritureFestin)
            {
                Inventaire.Instance.qteNourriture -= qteNourritureFestin;
                foreach(Soldat s in CampementData.Instance.soldats )
                    s.buffCombattant.TropDeNourriture();
            }
            else
            {
                Inventaire.Instance.qteNourriture -= qteNourritureBesoin;
                foreach (Soldat s in CampementData.Instance.soldats)
                    s.buffCombattant.NourritureOk();
            }
                
            CampementData.Instance.survivantContent = true;

        }
        else
        {
            int nourritureManquante = qteNourritureBesoin  - Inventaire.Instance.qteNourriture;
            Inventaire.Instance.qteNourriture = 0;
            foreach (Soldat s in CampementData.Instance.soldats)
                s.buffCombattant.PasAssezDeNourriture();
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
            CampementData.Instance.nbSurvivant -= Mathf.RoundToInt(_nourritureManquante /2);
            if(CampementData.Instance.nbSurvivant <=0)
            {
                SceneManager.LoadScene("Lose");
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

    public void PartirEnMission()
    {
        CampementData.Instance.partiEnMission = true;
        NewDay(); // a retirer quand les mission sont implanté 
    }
    
    
}
