using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSceneMission : MonoBehaviour {
    public Text CharName;
    public Text HP;
    public Text AP;
    public Text CharClass;
    public Image CharImage;
    public Button PassTurnButton;
    /*
    public TypeCombattant joueurActuel;
    
    private CombatManager cm;

    */

    // Use this for initialization
    void Awake () {
        /*
        joueurActuel = cm.JoueurActuel();
        CharName.Text = joueurActuel.nomCombattant;
        HP.Text = joueurActuel.hpCombattant;
        AP.Text = joueurActuel.paCombattant;
        CharClass.Text = joueurActuel.nomTypeCombattant;
        switch(joueurActuel.nomTypeCombattant){
            case nomTypeCombattant.Guerrier : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_tank");
                break;
            case nomTypeCombattant.Sniper : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_archer");
                break;
            case nomTypeCombattant.Eclaireur : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_scout");
                break;
            case nomTypeCombattant.Assassin : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_assassin");
                break;
        }
        
         */
    }

    // Update is called once per frame
    void Update () {
        
	}

    /*
     void changePlayerHUD(GameObject newPlayer){
        if(newPlayer is Ennemi){
            PassTurnButton.interactable = false;
        }
        else if(newPlayer is Soldat){
            PassTurnButton.interactable = true;
        }
        CharName.Text = newPlayer.nomCombattant;
        HP.Text = newPlayer.hpCombattant;
        AP.Text = newPlayer.paCombattant;
        CharClass.Text = newPlayer.nomTypeCombattant;
        switch(joueurActuel.nomTypeCombattant){
            case nomTypeCombattant.Guerrier : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_tank");
                break;
            case nomTypeCombattant.Sniper : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_archer");
                break;
            case nomTypeCombattant.Eclaireur : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_scout");
                break;
            case nomTypeCombattant.Assassin : 
                CharImage.Sprite = Resources.Load<Sprite>("Textures/sprite_assassin");
                break;
        }
    }

    void AbandonGame(){
        cm.AbandonMission()
    }

     */
}
