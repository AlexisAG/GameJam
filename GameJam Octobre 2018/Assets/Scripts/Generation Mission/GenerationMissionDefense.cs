using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationMissionDefense {

    public static void GenerateMission ()
    {
        Mission mission = new Mission(Mission.TypeMission.Defense, (byte)Random.Range(3, 7), CreateLvlMission(),
                                                       0, CreateName(), new Vector3(Random.Range(5, 50), Random.Range(5, 50)));
        mission.Ennemis = CreateEnnemi(mission.GetLvlMission());
        Debug.Log(mission);
        CampementData.Instance.missionsDisponible.Add(mission);
    }

    private static string CreateName ()
    {
        string[] temp = System.IO.File.ReadAllLines("Assets/Scripts/Generation Mission/DefenseName.txt");
        return temp[Random.Range(0, temp.Length)];
    }

    private static byte CreateLvlMission()
    {
        byte lvlMoyen = 0;

        for (int i = 0; i < CampementData.Instance.soldats.Count; i++)
            lvlMoyen += (byte)CampementData.Instance.soldats[i].GetTypeCombattant().NiveauCombattant;

        return (byte)(lvlMoyen / CampementData.Instance.soldats.Count);
    }

    private static List<Ennemi> CreateEnnemi(byte lvl)
    {
        List<Ennemi> ennemis = new List<Ennemi>();

        for (int i = 0; i < lvl * 1.5; i++)
            ennemis.Add(new Ennemi(Random.Range(0, 3), lvl));

        return ennemis;
    }
}
