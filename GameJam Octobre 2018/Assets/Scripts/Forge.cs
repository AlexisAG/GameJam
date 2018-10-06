using UnityEngine;

public class Forge : Batiment
{

    private int niveauArmesEtArmuresForgeables;

    public int NiveauArmesEtArmuresForgeables
    {
        get
        {
            return niveauArmesEtArmuresForgeables;
        }

        set
        {
            niveauArmesEtArmuresForgeables = value;
        }
    }

    public void Start()
    {
        InitBatiment(GetType().ToString());
        NiveauArmesEtArmuresForgeables = 1;
    }

    public override void Ameliorer()
    {
        if (UpgradePossible == true)
        {
            NiveauBatiment++;

            if (NiveauArmesEtArmuresForgeables < 10)
            {
                niveauArmesEtArmuresForgeables++;
            }
            else
            {
                niveauArmesEtArmuresForgeables = 10;
                print("Niveau maximal d'armes et armures atteint");
            }
            Nom = GetType().ToString() + " Niv. " + NiveauBatiment;
            ChangeRessourceUpgrade();
            PayerBatiment();
        }
    }

    public override string ToString()
    {
        return "Nom: " + Nom +
            ". Niveau Batiment: " + NiveauBatiment +
            ". estDispo: " + UpgradePossible +
            ". Cout: " + CoutEnRessources +
            ". Niveau armes et armures : " + NiveauArmesEtArmuresForgeables +
            ". Ressource pour upgrade : " + RessourcePourUpgrade;
    }

    public void creerArme(string _nom, string _type, int _degats)
    {
        Arme arme = new Arme();
        arme.Nom = _nom;
        arme.Type = _type;
        arme.Degats = _degats;
        arme.NiveauArme = Random.Range(2, 4);

        Inventaire.Instance.armes.Add(arme);
    }

    public void creerArmure(string _nom, string _type, int _pvSupplementaires)
    {
        Armure armure = new Armure();
        armure.Nom = _nom;
        armure.Type = _type;
        armure.PvSupplementaires = _pvSupplementaires;

        Inventaire.Instance.armures.Add(armure);
    }
}
