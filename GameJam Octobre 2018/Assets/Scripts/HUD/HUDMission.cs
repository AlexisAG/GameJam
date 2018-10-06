using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDMission : MonoBehaviour {

    public List<GameObject> MissionsPins;

	// Use this for initialization
	void Start () {

        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();


        for (int i = 0; i < MissionsPins.Count; i++)
            MissionsPins[i].transform.position = CampementData.Instance.missionsDisponible[i].GetPositionOnMap();
                    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
