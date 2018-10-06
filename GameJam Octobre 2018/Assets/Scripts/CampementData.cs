using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampementData : MonoBehaviour {

    private static CampementData instance;
    public static CampementData Instance { get { return instance; } }

    public int nbSurvivant;
    public bool survivantContent;

    // Use this for initialization
    void Start () {

        nbSurvivant = 2; // valeur de test
        survivantContent = true;

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

	}
}
