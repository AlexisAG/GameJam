public class Baraquement : Batiment
{

    private int niveauDesNouvellesRecrues;

    public int NiveauDesNouvellesRecrues
    {
        get
        {
            return niveauDesNouvellesRecrues;
        }

        set
        {
            niveauDesNouvellesRecrues = value;
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
            NiveauDesNouvellesRecrues++;
            Nom = "Baraquement Niv. " + NiveauBatiment;
            Sprite = this.GetType().ToString() + "_Niv" +  NiveauBatiment + ".png";
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
}
