using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWriter : MonoBehaviour
{
    public TextAsset JSONText;
    public BulletScriptableObject BulletScriptable;
    public PlayerStatsScriptableObject playerStatsScriptable;
    public WaveSpawnerScriptableObject WaveScript;
    public SaveSelection Select;
    public string savePath;
    public string filePath;
    



         void Start()
         {
            savePath = Path.Combine(Application.persistentDataPath, "SaveSelection.txt");
            string textFromFile = File.ReadAllText(savePath);
            filePath = Path.Combine(Application.persistentDataPath, textFromFile);
         }

    [System.Serializable]
    public class Stats
    {
        public string ph;
        public string mH;
        public string bD;
        public string bS;
        public string dhh;
        public string dlh;
        public string fR;
        public string cc;
        public string dif;
        public string wave;
    }

    [System.Serializable]
    public class StatsWrapper
    {
        public List<Stats> stats = new List<Stats>();
    }

    public StatsWrapper statsWrapper = new StatsWrapper();

    public void OutputJSON()
    {
        string strOutput = JsonUtility.ToJson(statsWrapper, true);
        File.WriteAllText(filePath, strOutput);
        Debug.Log(Application.dataPath);
    }

    public void Save()
    {
        Debug.Log("Save method has been called");
        Values();
        OutputJSON();
    }

    public void deathSave()
    {
        DefValues();
        OutputJSON();
    }

    public void killSave()
    {
        TestVal();
        OutputJSON();
    }

    public void DemoSave()
    {
        DemoVal();
        OutputJSON();
    }


    //calls button press
    void Values()
    {
        Stats stats = new Stats
        {
            ph = playerStatsScriptable.currentHealth.ToString(),
            mH = playerStatsScriptable.maxHealth.ToString(),
            bD = BulletScriptable.bulletDamage.ToString(),
            bS = BulletScriptable.bulletSpeed.ToString(),
            dhh = BulletScriptable.DHH.ToString(),
            dlh = BulletScriptable.DLH.ToString(),
            fR = BulletScriptable.fireRate.ToString(),
            cc = BulletScriptable.critChance.ToString(),
            dif = WaveScript.difficulty.ToString(),
            wave = WaveScript.waveNum.ToString()
        };
        statsWrapper.stats.Clear();
        statsWrapper.stats.Add(stats);
    }

    void DefValues()
    {
        Stats stats = new Stats
        {
            ph = 120.ToString(),
            mH = 120.ToString(),
            bD = 10.ToString(),
            bS = 10.ToString(),
            dhh = 0.ToString(),
            dlh = 0.ToString(),
            fR = 4.ToString(),
            cc = 1.ToString(),
            dif = 5.ToString(),
            wave = 0.ToString()
        };
        statsWrapper.stats.Clear();
        statsWrapper.stats.Add(stats);
    }

    void TestVal()
    {
        Stats stats = new Stats
        {
            ph = 0.ToString(),
            mH = 200.ToString(),
            bD = 10.ToString(),
            bS = 10.ToString(),
            dhh = 0.ToString(),
            dlh = 0.ToString(),
            fR = 5.ToString(),
            cc = 1.ToString(),
            dif = 5.ToString(),
            wave = 0.ToString()
        };
        statsWrapper.stats.Clear();
        statsWrapper.stats.Add(stats);
    }

    void DemoVal()
    {
        Stats stats = new Stats
        {
            ph = 1000.ToString(),
            mH = 1000.ToString(),
            bD = 50.ToString(),
            bS = 20.ToString(),
            dhh = 100.ToString(),
            dlh = 100.ToString(),
            fR = 15.ToString(),
            cc = 50.ToString(),
            dif = 12.ToString(),
            wave = 2.ToString()
        };
        statsWrapper.stats.Clear();
        statsWrapper.stats.Add(stats);
    }


}