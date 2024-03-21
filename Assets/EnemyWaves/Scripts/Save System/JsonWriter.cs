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
        File.WriteAllText(Application.dataPath + "/EnemyWaves/Scripts/Save System/JsonText.txt", strOutput);
        Debug.Log(Application.dataPath);
    }

    public void Save()
    {
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

        statsWrapper.stats.Add(stats);
    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Add this for file writing

public class JSONWriter : MonoBehaviour
{
    public TextAsset JSONText;
    public BulletScriptableObject BulletScriptable;
    public PlayerStatsScriptableObject playerStatsScriptable;

    [System.Serializable]
    public class Stats
    {
        public int ph;
        public int mH;
        public int bD;
        public float bS;
        public int dhh;
        public int dlh;
        public int fR;
        public int cc; // local variables to pull the values

        public void DebugStats()
        {
            Debug.Log($"Player Health: {ph}, Max Health: {mH}, Bullet Damage: {bD}, Bullet Speed: {bS}, Damage High Health: {dhh}, Damage Low Health: {dlh}, Fire Rate: {fR}, Crit Chance: {cc}");
        } //shows values pulled, if any were pulled.
    }


    public Stats stats = new Stats();

    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(stats);
        File.WriteAllText(Application.dataPath + "/EnemyWaves/Scripts/Save System/JsonText.txt", strOutput);
        Debug.Log(Application.dataPath);
    }


    
    void Start()
    {
        Values();
        outputJSON();
    }


    void Values()
    {
        stats.ph = playerStatsScriptable.currentHealth;
        stats.mH = playerStatsScriptable.maxHealth;
        stats.bD = BulletScriptable.bulletDamage;
        stats.bS = BulletScriptable.bulletSpeed;
        stats.dhh = BulletScriptable.DHH;
        stats.dlh = BulletScriptable.DLH;
        stats.fR = BulletScriptable.fireRate;
        stats.cc = BulletScriptable.critChance;
    }
}*/