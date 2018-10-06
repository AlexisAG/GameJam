using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampementData : MonoBehaviour {

    private static CampementData instance;
    public static CampementData Instance { get { return instance; } }

    public List<Batiment> batiments; // liste des batiment dans la scene a lier dans l'editeur
    public List<Soldat> soldats;
    public List<Mission> missionsDisponible;

    public int nbSurvivant;
    public int nbSurvivantNonOccupé;
    public bool survivantContent;

    // Use this for initialization
    void Start () {

        nbSurvivant = 20; // valeur a modifier
        nbSurvivantNonOccupé = nbSurvivant;
        survivantContent = true; // valeur a modifier

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }


}
