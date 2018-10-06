using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationMissionDefense {

    public static void GenerateMission ()
    {
        
    }

    private string CreateName ()
    { 
        return System.IO.File.ReadAllLines("DefenseName.txt")[Random.Range(0, 10)];
    }
}
