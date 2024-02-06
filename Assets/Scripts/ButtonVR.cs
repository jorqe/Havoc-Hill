using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public TMP_Text UpgDesc1;
    public TMP_Text UpgDesc2;
    public TMP_Text UpgDesc3;
    public GameObject upgradesScript;
    //public GameObject Upgrades;
    public UnityEvent onPress, onRelease;
    GameObject presser;
    System.Random rnd = new System.Random();
    bool isPressed;
    int upg;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable(){
        string desc = "";
        Debug.Log("buttons have been enabled");
        upg = rnd.Next(1, 11);
        Debug.Log("upg = " + upg + " name = " + gameObject.name);
        switch (upg){
                case 1:
                    desc = "Bullet Speed Upgrade";
                    break;
                case 2:
                    desc = "Bullet Damage Upgrade";
                    break;
                case 3:
                    desc = "Fire Rate Upgrade";
                    break;
                case 4:
                    desc = "Critical Chance Upgrade";
                    break;
                case 5:
                    desc = "Heal Upgrade";
                    break;
                case 6:
                    desc = "Increase Max Health";
                    break;
                case 7:
                    desc = "Do more damage at high health";
                    break;
                case 8:
                    desc = "Do more damage at low health";
                    break;
                case 9:
                    desc = "Question combo increases damage";
                    break;
                case 10:
                    desc = "Poison damage";
                    break;
            }

        if (gameObject.name == "UpgBtn1"){
            UpgDesc1.text = desc;
        }
        else if (gameObject.name == "UpgBtn2"){
            UpgDesc2.text = desc;
        }
        else if (gameObject.name == "UpgBtn3"){
            UpgDesc3.text = desc;
        }
        

    }

    private void OnTriggerEnter(Collider other){
        if (!isPressed){
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            //onPress.Invoke();
            isPressed = true;
            
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject == presser){
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            //onRelease.Invoke();
            switch (upg){
                case 1:
                    upgradesScript.GetComponent<Upgrades>().SpeedUPG();
                    break;
                case 2:
                    upgradesScript.GetComponent<Upgrades>().DamageUPG();
                    break;
                case 3:
                    upgradesScript.GetComponent<Upgrades>().FireRateUPG();
                    break;
                case 4:
                    upgradesScript.GetComponent<Upgrades>().CritUPG();
                    break;
                case 5:
                    upgradesScript.GetComponent<Upgrades>().HealUPG();
                    break;
                case 6:
                    upgradesScript.GetComponent<Upgrades>().MaxHealthUPG();
                    break;
                case 7:
                    upgradesScript.GetComponent<Upgrades>().DamageHighHealthUPG();
                    break;
                case 8:
                    upgradesScript.GetComponent<Upgrades>().DamageLowHealthUPG();
                    break;
                case 9:
                    upgradesScript.GetComponent<Upgrades>().DamageQuestionComboUPG();
                    break;
                case 10:
                    upgradesScript.GetComponent<Upgrades>().PoisonUPG();
                    break;
            }
            isPressed = false;
            //Upgrades.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
        }
    }
}
