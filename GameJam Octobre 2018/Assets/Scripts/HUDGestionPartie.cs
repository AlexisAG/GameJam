using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDGestionPartie : MonoBehaviour {

    public void RetourOnClick(GameObject refHud)
    {
        refHud.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
