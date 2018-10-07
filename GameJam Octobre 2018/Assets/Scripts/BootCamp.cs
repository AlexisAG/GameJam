public class BootCamp : Batiment
{
    public int niveauDesCombattants;

    private void Start()
    {
        InitBatiment((this.GetType().ToString()));
        this.niveauDesCombattants = 1;
    }

    public override void Ameliorer()
    {
        if (UpgradePossible == true)
        {
            NiveauBatiment++;

            if (niveauDesCombattants < 10)
                niveauDesCombattants += 1;
            else
            {
                niveauDesCombattants = 10;
                print("Niveau des combattants maximale atteint");
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
            ". Niveau armes et armures : " + this.niveauDesCombattants +
            ". Ressource pour upgrade : " + RessourcePourUpgrade;
    }

    public void UpgradeSoldat(Soldat _unSoldat)
    {
        GestionXP.Instance.AugmenterNiveauSoldat(_unSoldat,0);
    }
}
