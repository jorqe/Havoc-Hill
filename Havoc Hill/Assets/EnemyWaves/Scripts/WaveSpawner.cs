using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
	public Transform enemyPrefab1;
	public Transform enemyPrefab2;
	public Transform enemyPrefab3;
	public Transform spawnPoint;
	[SerializeField] private int difficulty;
	[SerializeField] private int difficultyInc;
	[SerializeField] private float timeBetweenWaves;
	[SerializeField] private float countdown;
	[SerializeField] private List<int> wave = new();
	private bool readyToCountDown = false;
	public WaveSpawnerScriptableObject waveSpawnerScriptable;
	public TextBoxUpdate textBoxUpdate;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;

	void Update() {

		if (readyToCountDown == true) {
			countdown -= Time.deltaTime;
		}

		if (countdown <= 0f && (!button1.activeSelf || !button2.activeSelf || !button3.activeSelf)) {
			readyToCountDown = false;
			countdown = timeBetweenWaves;
			StartCoroutine(SpawnWave());
			difficulty += difficultyInc;
		}

		if (waveSpawnerScriptable.enemiesLeft == 0) {
			StartCoroutine(chooseUpg());
			textBoxUpdate.DisplayRandomTrivia();
			readyToCountDown = true;
		}
	}

	IEnumerator SpawnWave() {

		CreateWave();

		waveSpawnerScriptable.enemiesLeft += wave.Count;

		for(int i = 0; i < wave.Count; i++) {
			if (wave[i] == 1)
				Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
			else if (wave[i] == 2)
				Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
			else if (wave[i] == 3)
				Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
			yield return new WaitForSeconds(1f);
		}
	}

	void CreateWave() {
		//empty last wave
		wave.Clear();
		//create new wave using difficulty
		int enemyType;
		int waveDif = 0;
		for (int i = 0; waveDif < difficulty; i++) {
			enemyType = Random.Range(1, 4);
			wave.Add(enemyType);
			waveDif += enemyType;
		}
	}

	IEnumerator chooseUpg() {
		button1.SetActive(true);
		button2.SetActive(true);
		button3.SetActive(true);
		yield return new WaitUntil(() => (!button1.activeSelf || !button2.activeSelf || !button3.activeSelf));
	}
}