using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuResumeSaveQuitIG : MonoBehaviour
{

    public static bool enPause = false;
    public static bool visible = false;
    public GameObject HUDMenuPause;


    private void Start()
    {
        if (visible == false)
        {
            HUDMenuPause.SetActive(false);
        }
    }

    private void Update()
    {
        OpenMenuOnKeyDown();
    }

    public void OpenMenuOnKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enPause)
            {
                Resume();
            }
            else
            {
                Pause();
                print("You've successfully open the Resume/Save/Quit menu");
            }
        }
    }

    public void Pause()
    {
        HUDMenuPause.SetActive(true);
        enPause = true;
    }

    public void Resume()
    {
        HUDMenuPause.SetActive(false);
        enPause = false;
    }

    public void SaveGame()
    {
        GestionPartie.control.Save();
        print("You've successfully saved the game !");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu_Principal");
        print("You're now in the main menu boi !");
    }
}
