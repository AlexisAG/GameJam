using UnityEngine;

public class Armure : MonoBehaviour
{

    private string nom;
    private string type;
    private int pvSupplementaires;

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

    public int PvSupplementaires
    {
        get
        {
            return pvSupplementaires;
        }

        set
        {
            pvSupplementaires = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        nom = this.Nom;
        type = this.Type;
        PvSupplementaires = this.pvSupplementaires;
    }
}
