//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/Bullet")]
public class BulletScriptableObject : ScriptableObject
{
    System.Random rnd = new System.Random();
    public float bulletSpeed = 10;
    public int bulletDamage = 1;
    public int DHH = 0;
    public int DLH = 0;

    public int critChance = 1;
    public int fireRate = 1;

    public bool CalculateCrit(int weight){
        int number = rnd.Next(1, 101);
        for (int i = 0; i < weight; i++){
            if (number == i){
                Debug.Log("Critical Hit");
                return true;
            }
        }

        return false;
    }
}
