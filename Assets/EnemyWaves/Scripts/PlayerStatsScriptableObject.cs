using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsScriptableObject", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStatsScriptableObject : ScriptableObject {
    public int maxHealth = 200;
    public int currentHealth = 200;
    public int score = 0;
    public int combo = 1;
}
