using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesManager : MonoBehaviour {

    static public float RatioBesoin()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 0.9f;
        }
        else
        {
            return 1.5f;
        }
         
    }

    static public float RatioFestin()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 1.0f;
        }
        else
        {
            return 1.5f;
        }
    }

    static public float RatioRecolteBois()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 1.0f;
        }
        else
        {
            return 0.7f;
        }
    }

    static public float RatioRecolteMetal()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 1.0f;
        }
        else
        {
            return 0.7f;
        }
    }

    static public float RatioRecoltePierre()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 1.0f;
        }
        else
        {
            return 0.8f;
        }
    }

    static public float RatioRecolteNourriture()
    {
        if (Environnement.Instance.SaisonCourante == "Ete")
        {
            return 1.0f;
        }
        else
        {
            return 0.5f;
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
