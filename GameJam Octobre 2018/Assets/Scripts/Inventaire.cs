using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{

    //singleton
    private static Inventaire instance;
    public static Inventaire Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("CampementData").GetComponent<Inventaire>();
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(instance.gameObject);

            }
            return instance;
        }
    }

    public int qtePierre;
    public int qteBois;
    public int qteMetal;
    public int qteNourriture;

    public int qtePierreToAdd;
    public int qteBoisToAdd;
    public int qteMetalToAdd;
    public int qteNourritureToAdd;
    public List<Arme> armes;
    public List<Armure> armures;

    // Use this for initialization
    void Start()
    {

        armes = new List<Arme>();
        armures = new List<Armure>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
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
