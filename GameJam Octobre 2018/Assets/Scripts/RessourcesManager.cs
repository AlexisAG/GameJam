using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesManager : MonoBehaviour {

    static public float RatioBesoin()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 2.0f;
        }
        else
        {
            return 3.0f;
        }
         
    }

    static public float RatioFestin()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 2.0f;
        }
        else
        {
            return 3.0f;
        }
    }

    static public float RatioRecolteBois()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 5.0f;
        }
        else
        {
            float enfonctionJour = (float)(Environnement.Instance.seuilSaison() - Environnement.Instance.JoursPassesDansLaSaison) / Environnement.Instance.seuilSaison();
            return CampementData.Instance.survivantContent == true ?
                (float)Mathf.Pow(4.0f, enfonctionJour)
                : (float)Mathf.Pow(4.0f, enfonctionJour) / 2;
        }
    }

    static public float RatioRecolteMetal()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 5.0f;
        }
        else
        {
            float enfonctionJour = (float)(Environnement.Instance.seuilSaison() - Environnement.Instance.JoursPassesDansLaSaison) / Environnement.Instance.seuilSaison();
            return CampementData.Instance.survivantContent == true ?
                (float)Mathf.Pow(4.0f, enfonctionJour)
                : (float)Mathf.Pow(4.0f, enfonctionJour) / 2;
        }
    }

    static public float RatioRecoltePierre()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return CampementData.Instance.survivantContent == true ? 5.0f : 5.0f / 2;
        }
        else
        {
            float enfonctionJour = (float)(Environnement.Instance.seuilSaison() - Environnement.Instance.JoursPassesDansLaSaison) / Environnement.Instance.seuilSaison();
            return CampementData.Instance.survivantContent == true ?
                (float)Mathf.Pow(4.0f, enfonctionJour)
                : (float)Mathf.Pow(4.0f, enfonctionJour) / 2;
        }
    }

    static public float RatioRecolteNourriture()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return CampementData.Instance.survivantContent == true ? 5.0f : 5.0f / 2;
        }
        else
        {
            float enfonctionJour = (float)(Environnement.Instance.seuilSaison() - Environnement.Instance.JoursPassesDansLaSaison) / Environnement.Instance.seuilSaison();
            return CampementData.Instance.survivantContent == true ?
                (float)Mathf.Pow(4.0f, enfonctionJour)
                : (float)Mathf.Pow(4.0f, enfonctionJour) / 2;
        }
    }

    static public float RatioRecolteFourrure()
    {
        return 1.0f;
    }

    static public float RisqueMission()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 1.0f;
        }
        else
        {
            return 1.0f;
        }
    }

}
 