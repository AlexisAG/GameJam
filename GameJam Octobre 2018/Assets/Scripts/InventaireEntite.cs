using System;
using UnityEngine;

public class InventaireEntite : MonoBehaviour
{

    Arme arme;
    Armure epaulieres;
    Armure jambieres;
    Armure casque;

    // Use this for initialization
    void Start()
    {
        switch (GetType().ToString())
        {
            case "Eclaireur":
                epaulieres.PvSupplementaires = 10;
                jambieres.PvSupplementaires = 10;
                casque.PvSupplementaires = 10;
                //Nom de l'arme en fonction de son niveau
                checkNiveauArme(this.arme);
                arme.Type = "corps a corps";
                break;

                
            case "Guerrier":
                epaulieres.PvSupplementaires = 5;
                jambieres.PvSupplementaires = 5;
                casque.PvSupplementaires = 5;
                //Nom de l'arme en fonction de son niveau
                checkNiveauArme(this.arme);
                arme.Type = "corps a corps";
                break;
                
            case "Assassin":
                epaulieres.PvSupplementaires = 2;
                jambieres.PvSupplementaires = 2;
                casque.PvSupplementaires = 2;
                //Nom de l'arme en fonction de son niveau
                checkNiveauArmeSniper(this.arme);
                arme.Type = "corps a corps";
                break;


                
            case "Sniper":
                epaulieres.PvSupplementaires = 1;
                jambieres.PvSupplementaires = 1;
                casque.PvSupplementaires = 1;
                arme.Type = "distance";
                //Nom de l'arme en fonction de son niveau
                checkNiveauArmeSniper(this.arme);
                arme.Type = "distance";
                break;
        }
    }

    private void checkNiveauArmeSniper(Arme arme)
    {
        if (arme.NiveauArme == 2)
            arme.Nom = "arc";
        else
            arme.Nom = "arbalete";
    }

    private void checkNiveauArmeCAC(Arme arme)
    {
        switch (arme.NiveauArme)
        {
            case 2:
                arme.Nom = "marteau";
                break;

            case 3:
                arme.Nom = "epee";
                break;

            default:
                arme.Nom = "baton";
                break;
        }
    }
}
