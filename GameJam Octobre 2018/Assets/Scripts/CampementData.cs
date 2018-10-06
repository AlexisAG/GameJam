using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampementData : MonoBehaviour {

    private static CampementData instance;
    public static CampementData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("CampementData").GetComponent<CampementData>();
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(instance.gameObject);
                
            }
            return instance;
        }
    }
    public List<Batiment> batiments; // liste des batiment dans la scene a lier dans l'editeur
    public List<Soldat> soldats;
    public List<Mission> missionsDisponible;

    public int nbSurvivant;
    public bool survivantContent;

    // Use this for initialization
    void Start () {

        nbSurvivant = 2; // valeur a modifier
        survivantContent = true; // valeur a modifier
        soldats = new List<Soldat>();
        missionsDisponible = new List<Mission>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}
