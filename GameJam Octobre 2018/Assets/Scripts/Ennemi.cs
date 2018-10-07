using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    public TypeCombattant combattant;
    private string ennemiClasse;
    public string GetClasse()
    {
        return ennemiClasse;
    }
    public Ennemi(int classe, int niveau)
    {
        // Niveau set en fonction de la mission
        // 1 pour Guerrier
        if (classe == 0)
        {
            Combattant = new Guerrier(niveau);
            ennemiClasse = "Guerrier";
        }
        // 2 pour Assassin
        if (classe == 1)
        {
            Combattant = new Assassin(niveau);
            ennemiClasse = "Assassin";
        }

        // 3 pour Sniper
        if (classe == 2)
        {
            Combattant = new Sniper(niveau);
            ennemiClasse = "Sniper";
        }

        // 4 pour Eclaireur
        if (classe == 3)
        {
            Combattant = new Eclaireur(niveau);
            ennemiClasse = "Eclaireur";
        }

    }

    public TypeCombattant Combattant
    {
        get
        {
            return combattant;
        }

        set
        {
            combattant = value;
        }
    }

<<<<<<< HEAD
    public void AttaqueAdversaire(TypeCombattant adversaire)
    {
        adversaire.recoitDegats(Combattant);
=======
    public void AttaqueAdversaire(TypeCombattant adversaire){
        adversaire.RecoitDegats(combattant);
>>>>>>> origin/Flotest
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
