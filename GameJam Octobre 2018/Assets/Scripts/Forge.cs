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
        InitBatiment(this.GetType().ToString());
        this.NiveauArmesEtArmuresForgeables = 1;
    }

    public override void Ameliorer()
    {
        if (UpgradePossible == true)
        {
            NiveauBatiment++;

            if (NiveauArmesEtArmuresForgeables < 10)
                niveauArmesEtArmuresForgeables++;
            else
            {
                niveauArmesEtArmuresForgeables = 10;
                print("Niveau maximal d'armes et armures atteint");
            }
            Nom = this.GetType().ToString() + " Niv. " + NiveauBatiment;
            ChangeRessourceUpgrade();
            PayerBatiment();
        }
    }

    public override string ToString()
    {
        return "Nom: " + this.Nom +
            ". Niveau Batiment: " + this.NiveauBatiment +
            ". estDispo: " + this.UpgradePossible +
            ". Cout: " + this.CoutEnRessources +
            ". Niveau armes et armures : " + this.NiveauArmesEtArmuresForgeables + 
            ". Ressource pour upgrade : " + RessourcePourUpgrade;
    }
}
