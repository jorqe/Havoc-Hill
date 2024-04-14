using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWriter : MonoBehaviour
{
    public TextAsset JSONText;
    public BulletScriptableObject BulletScriptable;
    public PlayerStatsScriptableObject playerStatsScriptable;

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
        string filePath = Path.Combine(Application.persistentDataPath, "JsonText.txt");
        File.WriteAllText(filePath, strOutput);
        Debug.Log(Application.dataPath);
    }

    public void Save()
    {
        Debug.Log("Save method has been called");
        Values();
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
            cc = BulletScriptable.critChance.ToString()
        };
        statsWrapper.stats.Clear();
        statsWrapper.stats.Add(stats);
    }
}