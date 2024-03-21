using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset JSONText;
    public BulletScriptableObject BulletScriptable;
    public PlayerStatsScriptableObject playerStatsScriptable;
    

    [System.Serializable]
    public class Stats
    {
        public PlayerStatsScriptableObject playerStatsScriptable;
        public BulletScriptableObject BulletScriptable;

        public int ph;
        public int mH;
        public int bD;
        public float bS;
        public int dhh;
        public int dlh;
        public int fR;
        public int cc;//local variables to pull the values

        public void DebugStats()
        {
            Debug.Log($"Player Health: {ph}, Max Health: {mH}, Bullet Damage: {bD}, Bullet Speed: {bS}, Damage High Health: {dhh}, Damage Low Health: {dlh}, Fire Rate: {fR}, Crit Chance: {cc}");
        }//shows values pulled, if any were pulled.
    }


    [System.Serializable]
    public class StatsList
    {
        public Stats[] stats;
    }


    public StatsList myStatsList = new StatsList();


    void Start()
    {

        myStatsList = JsonUtility.FromJson<StatsList>(JSONText.text);
        StartCoroutine(WaitAndPrint());
        AssignValuesToScriptableObjects();
    }

    IEnumerator WaitAndPrint()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(3);

        // The code here will run after the 5-second wait
        Debug.Log("5 seconds have passed!");
    }

    void AssignValuesToScriptableObjects()
    {
        /*
        foreach (Stats stat in myStatsList.stats)
        {
            playerStatsScriptable.currentHealth = stat.ph;
            playerStatsScriptable.maxHealth = stat.mH;
            BulletScriptable.bulletDamage = stat.bD;
            BulletScriptable.bulletSpeed = stat.bS;
            BulletScriptable.DHH = stat.dhh;
            BulletScriptable.DLH = stat.dlh;
            BulletScriptable.fireRate = stat.fR;
            BulletScriptable.critChance = stat.cc;
        }

        */
        
            foreach (Stats stat in myStatsList.stats)
        {

            stat.DebugStats();

            if (playerStatsScriptable == null)
            {
                Debug.LogError("playerStatsScriptable is null");
            }
            else
            {
                playerStatsScriptable.currentHealth = stat.ph;
                playerStatsScriptable.maxHealth = stat.mH;
            }

            if (BulletScriptable == null)
            {
                Debug.LogError("BulletScriptable is null");
            }
            else
            {
                
                BulletScriptable.bulletDamage = stat.bD;
                BulletScriptable.bulletSpeed = stat.bS;
                BulletScriptable.DHH = stat.dhh;
                BulletScriptable.DLH = stat.dlh;
                BulletScriptable.fireRate = stat.fR;
                BulletScriptable.critChance = stat.cc;
            }
            stat.DebugStats();
        }
    }



    /*
    [System.Serializable]
    public class Stats
    {
        public PlayerStatsScriptableObject playerStatsScriptable;
        public BulletScriptableObject BulletScriptable;

        public int ph;
        public int mH;
        public int bD;
        public double bS;
        public int dhh;
        public int dlh;
        public int fR;
        public int cc;
        public List<values> stats = new List<values>();


        void Update()
        {
            ph = playerStatsScriptable.currentHealth;
            mH = playerStatsScriptable.maxHealth;
            bD = BulletScriptable.bulletDamage;
            bS = BulletScriptable.bulletSpeed;
            dhh = BulletScriptable.DHH;
            dlh = BulletScriptable.DLH;
            fR = BulletScriptable.fireRate;
            cc = BulletScriptable.critChance;


        }

    }*/

}