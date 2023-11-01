using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletScriptableObject bulletSO;
    static public float bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void OnTriggerEnter (Collider other){
        if (other.CompareTag("SpeedUpg")){
            Debug.Log("in if statement");
            bulletSO.bulletSpeed += bulletSpeed;
            Destroy(gameObject);
        }
        else if (other.CompareTag("HealthUpg")){
            Debug.Log("in heath if stm");
            bulletSO.bulletDamage += 2;
            Destroy(gameObject);
        }
    }
    */
}

