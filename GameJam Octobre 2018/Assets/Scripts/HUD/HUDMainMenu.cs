using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using UnityEngine;

public class HUDMainMenu : MonoBehaviour {

    public void NewGameOnClick()
    {
<<<<<<< HEAD
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Assassin));
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Eclaireur));
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Guerrier));
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Sniper));

        GenerationMissionSurvivant.GenerateMission();
        GenerationMissionExploration.GenerateMission();
        GenerationMissionSurvivant.GenerateMission();
        GenerationMissionSurvivant.GenerateMission();
        GenerationMissionExploration.GenerateMission();

        SceneManager.LoadScene("Campement", LoadSceneMode.Single);
=======
        SceneManager.LoadScene("Campement", LoadSceneMode.Single);       
>>>>>>> origin/Flotest
    }

    public void LoadGameOnClick(GameObject refCanvas)
    {
        refCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void QuitOnClick()
    {
        Application.Quit();
    }
}
