using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDGestionPartie : MonoBehaviour {

    public void ButtonOnClick(GameObject refHud)
    {
        refHud.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void SauvegarderButton(int saveID = 0)
    {
        /* APPEL LA FONCTION SAVE DE GESTION PARTIE */
    }

    public void ChargerButton(int saveID)
    {
        /* APPEL LA FONCTION LOAD DE GESTION PARTIE */
    }
}
