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
        InitBatiment((GetType().ToString()));
        this.NiveauDesNouvellesRecrues = 1;
    }

    public override void Ameliorer()
    {
        if (UpgradePossible == true)
        {
            NiveauBatiment++;

            if (NiveauDesNouvellesRecrues < 10)
                NiveauDesNouvellesRecrues += 1;
            else
            {
                NiveauDesNouvellesRecrues = 10;
                print("Niveau des nouvelles recrues maximal atteint");
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
            ". Niveau armes et armures : " + this.NiveauDesNouvellesRecrues +
            ". Ressource pour upgrade : " + RessourcePourUpgrade;
    }
}
