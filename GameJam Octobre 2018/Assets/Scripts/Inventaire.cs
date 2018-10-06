using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour {

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
}
