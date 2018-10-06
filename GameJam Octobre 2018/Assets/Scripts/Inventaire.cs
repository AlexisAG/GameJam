using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour {

    //singleton
    private static Inventaire instance;
    public static Inventaire Instance { get { return instance; } }

    public int qtePierre;
    public int qteBois;
    public int qteMetal;
    public int qteNourriture;
    public List<Arme> armes = new List<Arme>();
    public List<Armure> armures = new List<Armure>();

    public int qtePierreToAdd;
    public int qteBoisToAdd;
    public int qteMetalToAdd;
    public int qteNourritureToAdd;
    // Use this for initialization
    void Start () {

        if(instance==null)
        {
            qtePierre = 50;
            qteBois = 50;
            qteMetal = 50;
            qteNourriture = 50;
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        
    }

    public void AddLastDayRessources()
    {
        qteBois += qteBoisToAdd;
        qteMetal += qteMetalToAdd;
        qteNourriture += qteNourritureToAdd;
        qtePierre += qtePierreToAdd;

        qteBoisToAdd = 0;
        qteMetalToAdd = 0;
        qteNourritureToAdd = 0;
        qtePierreToAdd = 0;
    }
}
