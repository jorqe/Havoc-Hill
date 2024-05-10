using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSpawnerScriptableObject", menuName = "ScriptableObjects/WaveSpawner")]
public class WaveSpawnerScriptableObject : ScriptableObject {
    public int enemiesLeft;
    public int damage = 5;
    public int difficulty = 5;
    public int waveNum = 0;
    public bool bossLeft = false;
}
