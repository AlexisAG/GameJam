using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using UnityEngine;

public class HUDMainMenu : MonoBehaviour {

    public GameObject HUDLoadGameCanvas;

    public void NewGameOnClick()
    {
        SceneManager.LoadScene("Campement", LoadSceneMode.Single);
    }

    public void LoadGameOnClick()
    {
        HUDLoadGameCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void QuitOnClick()
    {
        Application.Quit();
    }


}
