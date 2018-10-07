using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;


using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GestionPartie : MonoBehaviour {

    public static GestionPartie control;
    public Inventaire inventaire;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileInventaire = File.Create(Application.persistentDataPath + "/inventaireInfo.dat");
        FileStream fileEnvironnement = File.Create(Application.persistentDataPath + "/environnementInfo.dat");
        FileStream fileCampement = File.Create(Application.persistentDataPath + "/campementInfo.dat");

        InfosInventaire infosInventaire = new InfosInventaire();
        InfosEnvironnement infosEnvironnement = new InfosEnvironnement();
        InfosCampement infosCampement = new InfosCampement();

        //on serialise l'instance d'inventaire dans une variable fileInventaire
        bf.Serialize(fileInventaire, infosInventaire);

        //on serialise l'instance d'environnement dans une variable fileEnvironnement
        bf.Serialize(fileEnvironnement, infosEnvironnement);

        //on serialise l'instance de campement dans une variable fileCampement
        bf.Serialize(fileCampement, infosCampement);

        fileInventaire.Close();
        fileEnvironnement.Close();
        fileCampement.Close();

        print("save");
    }

    public void Load()
    {
        //Si le fichier d'inventaire sérialisé existe alors on le deserialise sous forme d'inventaire
        if (File.Exists(Application.persistentDataPath + "/inventaireInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/inventaireInfo.dat", FileMode.Open);
            InfosInventaire inventaireData = (InfosInventaire)bf.Deserialize(file);

            Inventaire.Instance.qteBois = inventaireData.qteBois;
            Inventaire.Instance.qtePierre = inventaireData.qtePierre;
            Inventaire.Instance.qteMetal = inventaireData.qteMetal;
            Inventaire.Instance.qteNourriture = inventaireData.qteNourriture;
            Inventaire.Instance.armes = inventaireData.armes;
            Inventaire.Instance.armures = inventaireData.armures;
            Inventaire.Instance.qtePierreToAdd = inventaireData.qtePierreToAdd;
            Inventaire.Instance.qteBoisToAdd = inventaireData.qteBoisToAdd;
            Inventaire.Instance.qteMetalToAdd = inventaireData.qteMetalToAdd;
            Inventaire.Instance.qteNourritureToAdd = inventaireData.qteNourritureToAdd;

            file.Close();
        }
        //Si le fichier d'environnement sérialisé existe alors on le deserialise sous forme d'environnement
        else if (File.Exists(Application.persistentDataPath + "/environnementInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/environnementInfo.dat", FileMode.Open);
            Environnement environnementData = (Environnement)bf.Deserialize(file);

            Environnement.Instance.SaisonCourante = environnementData.SaisonCourante;
            Environnement.Instance.JoursPasses = environnementData.JoursPasses;
            Environnement.Instance.JoursPassesDansLaSaison = environnementData.JoursPassesDansLaSaison;

            file.Close();
        }
        //Si le fichier de campement sérialisé existe alors on le deserialise sous forme de campement
        else if (File.Exists(Application.persistentDataPath + "/campementInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/campementInfo.dat", FileMode.Open);
            InfosCampement campementData = (InfosCampement)bf.Deserialize(file);

            CampementData.Instance.batiments = campementData.batiments;
            CampementData.Instance.soldats = campementData.soldats;
            CampementData.Instance.missionsDisponible = campementData.missions;
            CampementData.Instance.nbSurvivant = campementData.nbSurvivant;
            CampementData.Instance.survivantContent = campementData.survivantContent;
            CampementData.Instance.nbSurvivantNonOccupé = campementData.nbSurvivantNonOccupe;

            file.Close();
        }
    }
}

[Serializable]
public class InfosEnvironnement
{
    public string saisonCourante;
    public int joursPasses;
    public int joursPassesDansLaSaison;

    public InfosEnvironnement()
    {
         saisonCourante = Environnement.Instance.SaisonCourante;
         joursPasses = Environnement.Instance.JoursPasses;
         joursPassesDansLaSaison = Environnement.Instance.JoursPassesDansLaSaison;
    }
}

[Serializable]
public class InfosCampement
{
    public List<Batiment> batiments;
    public List<Soldat> soldats;
    public List<Mission> missions;
    public int nbSurvivant;
    public bool survivantContent;
    public int nbSurvivantNonOccupe;

    public InfosCampement()
    {
         batiments = CampementData.Instance.batiments;
         soldats = CampementData.Instance.soldats;
         missions = CampementData.Instance.missionsDisponible;

         nbSurvivant = CampementData.Instance.nbSurvivant;
         survivantContent = CampementData.Instance.survivantContent;
         nbSurvivantNonOccupe = CampementData.Instance.nbSurvivantNonOccupé;
    }
 }

[Serializable]
public class InfosInventaire
{
    public List<Arme> armes;
    public List<Armure> armures;
    public int qtePierre;
    public int qteBois;
    public int qteMetal;
    public int qteNourriture;
    
    public int qtePierreToAdd;
    public int qteBoisToAdd;
    public int qteMetalToAdd;
    public int qteNourritureToAdd;

    public InfosInventaire()
    {
         qtePierre = Inventaire.Instance.qtePierre;
         qteBois = Inventaire.Instance.qteBois;
         qteMetal = Inventaire.Instance.qteMetal;
         qteNourriture = Inventaire.Instance.qteNourriture;
         armes = Inventaire.Instance.armes;
         armures = Inventaire.Instance.armures;
         qtePierreToAdd = Inventaire.Instance.qtePierreToAdd;
         qteBoisToAdd = Inventaire.Instance.qteBoisToAdd;
         qteMetalToAdd = Inventaire.Instance.qteMetalToAdd;
         qteNourritureToAdd = Inventaire.Instance.qteNourritureToAdd;
    }
}
