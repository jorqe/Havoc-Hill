using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public BulletScriptableObject bulletSO;
    public PlayerStatsScriptableObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpeedUPG(){
        Debug.Log("in SpeedUPG");
        bulletSO.bulletSpeed += 10;
        Debug.Log("bulletSpeed = " + bulletSO.bulletSpeed);
    }

    public void DamageUPG(){
        Debug.Log("in DamageUPG");
        bulletSO.bulletDamage += 10;
        Debug.Log("bulletDamage = " + bulletSO.bulletDamage);
    }

    public void FireRateUPG(){
        Debug.Log("in FireRateUPG");
        bulletSO.fireRate += 1;
        Debug.Log("fireRate = " + bulletSO.fireRate);
    }

    public void CritUPG(){
        Debug.Log("in CritUPG");
        bulletSO.critChance += 1;
        Debug.Log("critChance = " + bulletSO.critChance);
    }

    public void HealUPG(){
        Debug.Log("in HealUPG");
        player.currentHealth += 20;
        if (player.currentHealth > player.maxHealth){
            player.currentHealth = player.maxHealth;
        }
        Debug.Log("currentHealth = " + player.currentHealth);
    }

    public void MaxHealthUPG(){
        Debug.Log("in MaxHealthUPG");
        player.maxHealth += 20;
        player.currentHealth += 20;
        Debug.Log("maxHealth = " + player.maxHealth + " currentHealth = " + player.currentHealth);
    }

    public void DamageHighHealthUPG(){
        Debug.Log("in DamageHighHealthUPG");
    }

    public void DamageLowHealthUPG(){
        Debug.Log("in DamageLowHealthUPG");
    }

    public void DamageQuestionComboUPG(){
        Debug.Log("in DamageQuestionComboUPG");
    }

    public void PoisonUPG(){
        Debug.Log("in PoisonUPG");
    }
}
