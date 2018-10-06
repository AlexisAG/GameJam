using UnityEngine;

public class Arme : MonoBehaviour
{

    private string nom;
    private string type;
    private int degats;
    private int niveauArme;

    public string Nom
    {
        get
        {
            return nom;
        }

        set
        {
            nom = value;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public int Degats
    {
        get
        {
            return degats;
        }

        set
        {
            degats = value;
        }
    }

    public int NiveauArme
    {
        get
        {
            return niveauArme;
        }

        set
        {
            niveauArme = value;
        }
    }

    //public bool aDeuxMains;
    //public bool estAFeu;


    // Use this for initialization
    void Start()
    {
        nom = this.Nom;
        type = this.Type;
        degats = this.Degats;
        niveauArme = this.NiveauArme;
    }
}
