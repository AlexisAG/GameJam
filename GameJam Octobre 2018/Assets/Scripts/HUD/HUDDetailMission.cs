using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDDetailMission : MonoBehaviour {

    public Text nom, type, difficulte, gain;
    public static Mission Mission;
    public GameObject refHUD;

    public void Start()
    {
        
    }

    public void DisplayMission()
    {
        nom.text = Mission.GetName();
        switch (Mission.GetTypeObjectif())
        {
            case Mission.TypeMission.Defense:
                type.text = "Mission de défense";
                gain.text = "";
                break;
            case Mission.TypeMission.Recherche:
                type.text = "Mission recherche d'équipements";
                gain.text = "Vous pouvez trouver jusqu'à " + Mission.GetGainMission() + " équipement(s).";
                break;
            case Mission.TypeMission.Survivant:
                type.text = "Mission recherche de survivant";
                gain.text = "Vous gagnerez " + Mission.GetGainMission() +" survivants en cas de réussite.";
                break;

        }
        difficulte.text = "La mission a une difficultée de " + Mission.GetLvlMission();
    }   
    
    public void Refuser (GameObject hud)
    {
        //hud.SetActive(true);
        gameObject.SetActive(false);
    }
	
    public void Accepter ()
    {
        refHUD.SetActive(true);
        gameObject.SetActive(false);
    }
}
