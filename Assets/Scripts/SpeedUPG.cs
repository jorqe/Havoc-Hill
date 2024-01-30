using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUPG : MonoBehaviour
{
    public BulletScriptableObject bulletSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpdUpg() {
        bulletSO.bulletSpeed += 10;
    }
}
