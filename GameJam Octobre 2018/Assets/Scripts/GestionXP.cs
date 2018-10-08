using System.Collections.Generic;
using UnityEngine;

public class GestionXP : MonoBehaviour
{
    private static GestionXP instance;

    public List<Soldat> soldats;
    public int gainXPMission = 2000;

    public static GestionXP Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Start()
    {
        if (instance == null)
        {
            soldats = CampementData.Instance.soldats;
            //missions = CampementData.Instance.missionsDisponible;
            DontDestroyOnLoad(gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public GestionXP(List<Soldat> _soldats)
    {
        soldats = _soldats;
    }

    public void AugmenterNiveauSoldat(Soldat _unSoldat, double _surplusXP)
    {
        _unSoldat.niveauSoldat.XPActuelle = 0;
        _unSoldat.niveauSuivant = new NiveauXP(_unSoldat.niveauSoldat, _surplusXP); //Creation du nouvel objet representant le niveau actuel d'un soldat avec les valeurs telles que /!\ PSEUDO CODE /!\ niveau = niveauActuel+1 /!\ PSEUDO CODE /!\ et le surplus d'XP eventuel
        _unSoldat.niveauSoldat.Niveau = _unSoldat.niveauSuivant.Niveau; 
    }
    

    public class NiveauXP
    {
        //ex. 10
        public double Niveau;

        //ex. 2500
        public double XPActuelle;

        //ex. 15000
        public double XPMax;

        public NiveauXP()
        {
            Niveau = 1;
            XPActuelle = 0;
            XPMax = 5000;
        }

        public NiveauXP(NiveauXP _niveauPrec, double _surplusXP)
        {
            this.Niveau = _niveauPrec.Niveau + 1;
            XPActuelle = _surplusXP;
            XPMax = _niveauPrec.XPMax + 100 * this.Niveau * 1.1;
        }
    }
}
