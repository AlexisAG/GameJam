using UnityEngine;

public abstract class Batiment : MonoBehaviour
{
    
    private string nom;
    private int niveauBatiment;
    private bool upgradePossible;
    private int coutEnRessources;
    private string ressourcePourUpgrade;

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

    public int NiveauBatiment
    {
        get
        {
            return niveauBatiment;
        }

        set
        {
            niveauBatiment = value;
        }
    }

    public bool UpgradePossible
    {
        get
        {
            return upgradePossible;
        }

        set
        {
            upgradePossible = value;
        }
    }

    public int CoutEnRessources
    {
        get
        {
            return coutEnRessources;
        }

        set
        {
            coutEnRessources = value;
        }
    }

    public string RessourcePourUpgrade
    {
        get
        {
            return ressourcePourUpgrade;
        }

        set
        {
            ressourcePourUpgrade = value;
        }
    }

    public abstract void Ameliorer();

    public void InitBatiment(string typeBatiment)
    {
        Nom = typeBatiment + " Niv. 1";
        NiveauBatiment = 0;
        CoutEnRessources = 10;
        RessourcePourUpgrade = "bois";
        UpgradePossible = Inventaire.Instance.qteBois >= CoutEnRessources && ressourcePourUpgrade == "bois" ? true : false;
    }

    public void ChangeRessourceUpgrade()
    {
        switch(NiveauBatiment)
        {
            case 1:
                CoutEnRessources = 10;
                break;
            case 2:
                CoutEnRessources = 20;
                break;
            case 3:
                CoutEnRessources = 30;
                break;
            case 4:
                RessourcePourUpgrade = "pierre";
                coutEnRessources = 10;
                break;
            case 5:
                RessourcePourUpgrade = "pierre";
                coutEnRessources = 20;
                break;
            case 6:
                RessourcePourUpgrade = "pierre";
                coutEnRessources = 30;
                break;
            case 7:
                RessourcePourUpgrade = "Metal";
                coutEnRessources = 10;
                break;
            case 8:
                RessourcePourUpgrade = "Metal";
                coutEnRessources = 20;
                break;
            case 9:
                RessourcePourUpgrade = "Metal";
                coutEnRessources = 30;
                print("max");
                break;
            default:
                CoutEnRessources = 0;
                break;
        }
    }

    public void PayerBatiment()
    {
        if (RessourcePourUpgrade == "bois")
            Inventaire.Instance.qteBois -= CoutEnRessources;
        else if (RessourcePourUpgrade == "pierre")
            Inventaire.Instance.qtePierre -= CoutEnRessources;
        else
            Inventaire.Instance.qteMetal -= CoutEnRessources;
    }
}
