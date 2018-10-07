using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDMission : MonoBehaviour {

    public List<GameObject> MissionsPins;

	// Use this for initialization
	void Awake () {

        GenerationMissionDefense.GenerateMission();

        for (int i = 0; i < MissionsPins.Count; i++)
            MissionsPins[i].transform.position = CampementData.Instance.missionsDisponible[i].GetPositionOnMap();
                    
    }
	
	public void CheckMission(int index)
    {
        Debug.Log(CampementData.Instance.missionsDisponible[index]);
    }

    public void GoBack()
    {
        gameObject.SetActive(false);
    }

}
