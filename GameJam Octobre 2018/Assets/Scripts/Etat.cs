using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etat : MonoBehaviour {

    public const string etatNeutre = "Neutre";
    public const string etatFaible = "Faible";
    public const string etatEnForme = "EnForme";

    private string nomEtat;
    public Etat()
    {
        this.NomEtat = etatNeutre;
    }

    public string NomEtat
    {
        get
        {
            return nomEtat;
        }

        set
        {
            nomEtat = value;
        }
    }

    public void PasAssezDeNourriture(){
        this.NomEtat = etatFaible;
    }

    public void NourritureOk() {
        this.NomEtat = etatNeutre;
    }

    public void TropDeNourriture()
    {
        this.NomEtat = etatEnForme;
    }

    public override string ToString()
    {
        return NomEtat;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
