using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUpdate : MonoBehaviour
{
    public PlayerStatsScriptableObject playerStatsScriptable;
    public TMP_Text scoreOutput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreOutput.text = playerStatsScriptable.score.ToString();
    }
}
