using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampementData : MonoBehaviour {

    private static CampementData instance;
    public static CampementData Instance
    {
        get
        {
            return instance;
        }
    }
    public List<Batiment> batiments = new List<Batiment>(); // liste des batiment dans la scene a lier dans l'editeur
    public List<Soldat> soldats = new List<Soldat>();
    public List<Mission> missionsDisponible = new List<Mission>();

    public int nbSurvivant;
    public bool survivantContent;
    public int nbSurvivantNonOccupé;
    // Use this for initialization
    void Start () {

        if(instance == null)
        {
            nbSurvivant = 20; // valeur a modifier
            nbSurvivantNonOccupé = nbSurvivant;
            survivantContent = true; // valeur a modifier
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
