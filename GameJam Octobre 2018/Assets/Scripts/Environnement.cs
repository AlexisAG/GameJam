using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Environnement : MonoBehaviour {

    public string saisonCourante;
    public int joursPasses;
    public int joursPassesDansLaSaison;
    const int SEUIL_CHANGEMENT_SAISON = 10;

    public string SaisonCourante
    {
        get
        {
            return saisonCourante;
        }

        set
        {
            saisonCourante = value;
        }
    }

    public int JoursPasses
    {
        get
        {
            return joursPasses;
        }

        set
        {
            joursPasses = value;
        }
    }
    private static Environnement instance;
    public static Environnement Instance { get { return instance; }  }

    public int JoursPassesDansLaSaison
    {
        get
        {
            return joursPassesDansLaSaison;
        }

        set
        {
            joursPassesDansLaSaison = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;

            JoursPasses = 0;
            saisonCourante = "Ete";
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
        }

        
    }

    public void UpdateEnvironnement()
    {
        JoursPasses++;
        JoursPassesDansLaSaison++;

        CampementData.Instance.missionsDisponible.Where(mission => mission.GetTypeObjectif() == Mission.TypeMission.Defense).ToList<Mission>().ForEach(defense =>
       {
           defense.SetNewPositionOnMap(defense.GetPositionOnMap() + 0.8f * (new Vector3(0, 0, 0) - defense.GetPositionOnMap()));

           int taux = (int)(Mathf.Abs(Mathf.Sqrt((0 - defense.GetPositionOnMap().x) - (0 - defense.GetPositionOnMap().y))) - 50);

           if (taux > 50)
               CampementData.Instance.nbSurvivant -= Mathf.CeilToInt(CampementData.Instance.nbSurvivant * 0.025f);
           else if (taux <= 50)
               CampementData.Instance.nbSurvivant -= Mathf.CeilToInt(CampementData.Instance.nbSurvivant * 0.05f);
           else if (taux <= 25)
               CampementData.Instance.nbSurvivant -= Mathf.CeilToInt(CampementData.Instance.nbSurvivant * 0.10f);
       });

        if (saisonCourante == "Ete" && JoursPassesDansLaSaison >= SEUIL_CHANGEMENT_SAISON)
        if (saisonCourante == "Ete" && JoursPassesDansLaSaison >= seuilSaison())
        {
            SaisonCourante = "Hiver";
            JoursPassesDansLaSaison = 0;
        }
        else if (saisonCourante == "Hiver" && JoursPassesDansLaSaison >= SEUIL_CHANGEMENT_SAISON)
        else if (saisonCourante == "Hiver" && JoursPassesDansLaSaison >= seuilSaison())
        {
            SaisonCourante = "Ete";
            JoursPassesDansLaSaison = 0;
        }
    }

    public int seuilSaison()
    {
        return SEUIL_CHANGEMENT_SAISON;
    }
}
