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
	
	// Update is called once per frame
	void Update () {
		
	}
}
