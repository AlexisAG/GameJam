using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSceneMission : MonoBehaviour {
    public Text CharName;
    public Text HP;
    public Text AP;
    public Text CharClass;
    public Text PaMessage;
    public RawImage CharImage;
    public Button PassTurnButton;
    public Texture AssassinTexture, EclaireurTexture, GuerrierTexture, ArcherTexture,EnnemiTexture;
    
    private GameObject joueurActuel;
    
    public CombatManager cm;

    

    // Use this for initialization
    public void StartHUD () {
        
        joueurActuel = cm.CombattantCourrant;
        CharName.text = joueurActuel.GetComponent<MouvementPersonnage>().statCombatant.NomCombattant;
        HP.text = "HP : "+joueurActuel.GetComponent<MouvementPersonnage>().statCombatant.HpCombattant;
        AP.text = "AP : " + joueurActuel.GetComponent<MouvementPersonnage>().paDispo;
        CharClass.text = joueurActuel.GetComponent<MouvementPersonnage>().StatSoldat.GetClasse();
        switch (joueurActuel.GetComponent<MouvementPersonnage>().StatSoldat.GetClasse())
        {
            case "Guerrier":
                CharImage.texture = GuerrierTexture;
                break;
            case "Sniper" :
                CharImage.texture = ArcherTexture;
                break;
            case "Eclaireur":
                CharImage.texture = EclaireurTexture;
                break;
            case "Assassin":
                CharImage.texture = AssassinTexture;
                break;
        }
        
         
    }

    // Update is called once per frame
    void Update () {
        AP.text = "PA : " + joueurActuel.GetComponent<MouvementPersonnage>().paDispo;
        HP.text = "HP : " + joueurActuel.GetComponent<MouvementPersonnage>().statCombatant.HpCombattant;
    }


    public void changePlayerHUD(GameObject newPlayer){

        if (!newPlayer.GetComponent<MouvementPersonnage>().unJoueurControle)
        {
            PassTurnButton.interactable = false;
            PassTurnButton.GetComponentInChildren<Text>().text = "veuillez patienter";

            CharName.text = newPlayer.GetComponent<MouvementPersonnage>().statCombatant.NomCombattant;
            HP.text = "HP : " + newPlayer.GetComponent<MouvementPersonnage>().statCombatant.HpCombattant;
            AP.text = "PA : " + newPlayer.GetComponent<MouvementPersonnage>().paDispo;
            CharClass.text = newPlayer.GetComponent<MouvementPersonnage>().StatEnnemi.GetClasse();
            CharImage.texture = EnnemiTexture;
        }
        else if (newPlayer.GetComponent<MouvementPersonnage>().unJoueurControle)
        {
            PassTurnButton.interactable = true;
            PassTurnButton.GetComponentInChildren<Text>().text = "finir votre tour";

            CharName.text = newPlayer.GetComponent<MouvementPersonnage>().statCombatant.NomCombattant;
            HP.text = "HP : " + newPlayer.GetComponent<MouvementPersonnage>().statCombatant.HpCombattant;
            AP.text = "PA : " + newPlayer.GetComponent<MouvementPersonnage>().paDispo;
            CharClass.text = newPlayer.GetComponent<MouvementPersonnage>().StatSoldat.GetClasse();
            switch (newPlayer.GetComponent<MouvementPersonnage>().StatSoldat.GetClasse())
            {
                case "Guerrier":
                    CharImage.texture = GuerrierTexture;
                    break;
                case "Sniper":
                    CharImage.texture = ArcherTexture;
                    break;
                case "Eclaireur":
                    CharImage.texture = EclaireurTexture;
                    break;
                case "Assassin":
                    CharImage.texture = AssassinTexture;
                    break;
            }
        }

        joueurActuel = newPlayer;
    }

    public void updateMessagePA(string message)
    {
        PaMessage.text = message;
    }

    /*void AbandonGame(){
        cm.AbandonMission()
    }*/

     
}
