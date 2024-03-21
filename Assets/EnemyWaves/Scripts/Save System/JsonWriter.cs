using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWriter: MonoBehaviour
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
        public int cc;
    }

    public Stats myStats = new Stats();

    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(myStats);
        File.WriteAllText(Application.dataPath + "/JsonText.txt", strOutput);
    }
}
