using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour {

    public List<GameObject> listeCombattant = new List<GameObject>();

    public GameObject CombattantCourrant;

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
        if(listeCombattant.Where(combattant => combattant.GetComponent<MouvementPersonnage>().unJoueurControle == false).ToList<GameObject>().Count == 0)
        {
            switch (HUDDetailMission.Mission.GetTypeObjectif())
            {
                case Mission.TypeMission.Defense:
                    break;
                case Mission.TypeMission.Survivant:
                    CampementData.Instance.nbSurvivant += HUDDetailMission.Mission.GetGainMission();
                    break;
                case Mission.TypeMission.Recherche:
                    break;
                default:
                    break;
            }

            Environnement.Instance.JoursPasses += 1;
            CampementData.Instance.missionsDisponible.RemoveAt(CampementData.Instance.missionsDisponible.IndexOf(HUDDetailMission.Mission));
            int random = Random.Range(0, 2);

            switch (random)
            {
                case 0:
                    GenerationMissionDefense.GenerateMission();
                    break;
                case 1:
                    GenerationMissionExploration.GenerateMission();
                    break;
                case 2:
                    GenerationMissionSurvivant.GenerateMission();
                    break;
            }

            SceneManager.LoadScene("Campement", LoadSceneMode.Single);
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
