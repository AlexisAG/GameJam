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

    public int qtePierreToAdd;
    public int qteBoisToAdd;
    public int qteMetalToAdd;
    public int qteNourritureToAdd;
    // Use this for initialization
    void Start () {


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
