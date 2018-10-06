public class Baraquement : Batiment
{

    public int niveauDesRecrues;
    public string typeRessourcePourUpgrade;
    public int nbRessourcesPourUpgrade;

    private void Start()
    {
        Nom = "Baraquement Niv. 1";
        NiveauBatiment = 1;
        niveauDesRecrues = 1;
        UpgradePossible = Inventaire.Instance.qteBois >= nbRessourcesPourUpgrade && typeRessourcePourUpgrade == "bois" ? true : false;
        Sprite = "";
        Cout = 10;
        typeRessourcePourUpgrade = "bois";
    }

    public override void Ameliorer()
    {
        if (UpgradePossible)
        {
            NiveauBatiment++;
            niveauDesRecrues++;
            Nom = "Baraquement Niv. " + NiveauBatiment;
            Sprite = "" + NiveauBatiment + ".png";
            Cout++;
            nbRessourcesPourUpgrade *= NiveauBatiment;

            switch (NiveauBatiment)
            {
                case 2:
                case 3:
                case 4:
                    typeRessourcePourUpgrade = "bois";
                    break;
                case 5:
                case 6:
                case 7:
                    typeRessourcePourUpgrade = "pierre";
                    break;
                case 8:
                case 9:
                case 10:
                    typeRessourcePourUpgrade = "metal";
                    break;
            }
        }
    }
}
