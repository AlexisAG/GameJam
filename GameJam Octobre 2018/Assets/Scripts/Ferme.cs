public class Ferme : Batiment
{

    private int quantiteNourritureProduite;

    public int QuantiteNourritureProduite
    {
        get
        {
            return quantiteNourritureProduite;
        }

        set
        {
            quantiteNourritureProduite = value;
        }
    }

    private void Start()
    {
        InitBatiment((this.GetType().ToString()));
        this.QuantiteNourritureProduite = 1;
    }

    public override void Ameliorer()
    {
        if (UpgradePossible == true)
        {
            NiveauBatiment++;

            if (QuantiteNourritureProduite < 200)
                QuantiteNourritureProduite += 5;
            else
            {
                QuantiteNourritureProduite = 200;
                print("Quantite productible maximale atteinte");
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
            ". Niveau armes et armures : " + this.QuantiteNourritureProduite +
            ". Ressource pour upgrade : " + RessourcePourUpgrade;
    }
}
