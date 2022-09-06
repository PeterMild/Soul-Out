using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    public Stats myStats;

    UIStat uiStat;
    [SerializeField] GameObject uiWindow;
    public Text currentSTRUI;
    public Text currentAGIUI;
    public Text currentINTUI;
    public Text currentLUKUI;

     int STR=1;
     int AGI=1;
     int INT=1;
     int LUK=1;
    int levelPlayer;
    int endMatchExp;

    void Awake()
    {
        ES3AutoSaveMgr.Current.Load();

    }

    void Start()
    {
        myStats.STR = STR;
        myStats.AGI = AGI;
        myStats.INT = INT;
        myStats.LUK = LUK;

        currentSTRUI.text = STR.ToString("#");
        currentAGIUI.text = AGI.ToString("#");
        currentINTUI.text = INT.ToString("#");
        currentLUKUI.text = LUK.ToString("#");
        

    }
    void Update()
    {
        
        




    }







}








