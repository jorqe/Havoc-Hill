using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public BulletScriptableObject bulletSO;
    public AudioClip fireSound;
    public AudioSource audioSource;
    public float fireSpeed;
    public float volume = 0.5f;
    private Coroutine _current;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //grabbable.activated.AddListener(shootBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginFire() {
        if (_current == null)
            _current = StartCoroutine(shootBullet());
    }

    public void StopFire() {
        if(_current != null) StopCoroutine(_current);
    }

    public IEnumerator shootBullet(){
        fireSpeed = bulletSO.bulletSpeed;
        audioSource.PlayOneShot(fireSound, volume);
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);

        yield return new WaitForSeconds(1f / bulletSO.fireRate);
        _current = null;

    }

}
