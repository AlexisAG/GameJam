public class Forge : Batiment
{

    private int niveauArmesEtArmuresForgeables;

    public int NiveauArmesEtArmuresForgeables
    {
        get
        {
            return NiveauArmesEtArmuresForgeables;
        }

        set
        {
            NiveauArmesEtArmuresForgeables = value;
        }
    }

    private void Start()
    {
        InitBatiment(this.GetType());
        print(this.ToString());
    }

    public override void Ameliorer()
    {
        if (UpgradePossible)
        {
            NiveauBatiment++;
            NiveauArmesEtArmuresForgeables++;
            Nom = "Baraquement Niv. " + NiveauBatiment;
            Sprite = this.GetType().ToString() + "_Niv" + NiveauBatiment + ".png";
            CoutEnRessources *= NiveauBatiment;

            switch (NiveauBatiment)
            {
                case 2:
                case 3:
                case 4:
                    TypeRessourcePourUpgrade = "bois";
                    break;
                case 5:
                case 6:
                case 7:
                    TypeRessourcePourUpgrade = "pierre";
                    break;
                case 8:
                case 9:
                case 10:
                    TypeRessourcePourUpgrade = "metal";
                    break;
            }
        }
    }

    public override string ToString()
    {
        return "Nom : " + this.Nom + ". Niveau Batiment : " + this.NiveauBatiment + "Nom : " + this.Nom + "Nom : " + this.Nom;
    }
}
