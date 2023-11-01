using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSpawnerScriptableObject", menuName = "ScriptableObjects/WaveSpawner")]
public class WaveSpawnerScriptableObject : ScriptableObject {
    public int enemiesLeft;
    public int damage = 5;
}
