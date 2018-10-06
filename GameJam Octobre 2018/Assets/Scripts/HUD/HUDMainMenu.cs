using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using UnityEngine;

public class HUDMainMenu : MonoBehaviour {

    public void NewGameOnClick()
    {
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Assassin));
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Eclaireur));
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Guerrier));
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Sniper));

        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();

        SceneManager.LoadScene("Campement", LoadSceneMode.Single);
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
