using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class H_Scale : MonoBehaviour {

    public PlayerStatsScriptableObject playerStatsScriptable;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1.0f, 0.5f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {

            float ph = playerStatsScriptable.currentHealth;
            float x = ph/100;

            transform.localScale = new Vector3(x, 0.5f, 0.25f);
            //playerStatsScriptable = x;
    }
}
