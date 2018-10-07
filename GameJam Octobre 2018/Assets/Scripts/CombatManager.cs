using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public List<TypeCombattant> listeCombattant = new List<TypeCombattant>();

    public TypeCombattant CombattantCourrant;

    public List<Soldat> listeSoldat = new List<Soldat>();

    public List<Ennemi> listeEnnemis = new List<Ennemi>();

    public GenerateurDeCarte CarteGenerateur;

    // Use this for initialization
    void Start () {
        if (HUDDetailMission.Mission != null)
        {
            CarteGenerateur.TypeMission = HUDDetailMission.Mission.GetTypeObjectif();
        }
        else
        {
            CarteGenerateur.TypeMission = Mission.TypeMission.Recherche;
        }


        if (HUDDetailMission.Mission != null)
        {
            listeSoldat = HUDDetailMission.Mission.Soldats;
            listeEnnemis = HUDDetailMission.Mission.Ennemis;
        }
		foreach(Soldat soldat in listeSoldat)
        {
            CarteGenerateur.soldats.Add(soldat);
        }

        foreach (Ennemi ennemi in listeEnnemis)
        {
            CarteGenerateur.ennemis.Add(ennemi);
        }
        switch(Environnement.Instance.SaisonCourante)
        {
            case "Ete":
                CarteGenerateur.season = 0;
                break;
            case "Hiver":
                CarteGenerateur.season = 1;
                break;
        }
        

        

        CarteGenerateur.GenererLaMission();

        listeCombattant = CarteGenerateur.CombatantSpawne;

        for (int i = 0; i < listeCombattant.Count; i++)
        {
            listeCombattant[i].GetComponent<MouvementPersonnage>().CreateStatCombatant(i, HUDDetailMission.Mission.Soldats.Count);
        }

        CombattantCourrant = listeCombattant[0];

        CombattantCourrant.GetComponent<MouvementPersonnage>().CommencerSonTour();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.Space) && !CombattantCourrant.GetComponent<MouvementPersonnage>().enTrajet)
        {
            Debug.Log("space appuyé");
            CombattantCourrant.GetComponent<MouvementPersonnage>().FinDeTour();
            changementTour();
        }
    }

    public void changementTour()
    {
        int indexJoueurCourrant = listeCombattant.IndexOf(CombattantCourrant);
        if(indexJoueurCourrant + 1 > listeCombattant.Count - 1)
        {
            CombattantCourrant = listeCombattant[0];
        } else
        {

        //int nextCombattant = indexJoueurCourrant + 1;
        CombattantCourrant = listeCombattant[++indexJoueurCourrant];
        int indexJoueurCourrantTemp = listeCombattant.IndexOf(CombattantCourrant);
        Debug.Log("Index : " + indexJoueurCourrantTemp);

            
        }

        CombattantCourrant.GetComponent<MouvementPersonnage>().CommencerSonTour();
    }
}
