using UnityEngine;

public class EnemySoundEffectPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public WaveSpawnerScriptableObject waveSpawnerScriptable;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float valueRandom = Random.value;
        float chanceNoise = 0.001f;
        if (valueRandom < chanceNoise && waveSpawnerScriptable.enemiesLeft != 0)
        {
            Debug.Log("Sound is played!");
            audioSource.Play();
        }

    }
}