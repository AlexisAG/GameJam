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

        if (saisonCourante == "Ete" && JoursPassesDansLaSaison >= SEUIL_CHANGEMENT_SAISON)
        {
            SaisonCourante = "Hiver";
            JoursPassesDansLaSaison = 0;
        }
        else if (saisonCourante == "Hiver" && JoursPassesDansLaSaison >= SEUIL_CHANGEMENT_SAISON)
        {
            SaisonCourante = "Ete";
            JoursPassesDansLaSaison = 0;
        }
    }
}
