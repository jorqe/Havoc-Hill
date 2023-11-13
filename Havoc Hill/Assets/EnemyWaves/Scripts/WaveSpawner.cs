using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
	public Transform enemyPrefab1;
	public Transform enemyPrefab2;
	public Transform enemyPrefab3;
	public Transform spawnPoint;
	[SerializeField] private int difficulty = 5;
	[SerializeField] private int difficultyInc = 5;
	[SerializeField] private float timeBetweenWaves = 5f;
	[SerializeField] private float countdown = 2f;
	[SerializeField] private List<int> wave = new();
	private bool readyToCountDown = false;
	public WaveSpawnerScriptableObject waveSpawnerScriptable;
	public GameObject button;

	void Update() {

		if (readyToCountDown == true) {
			countdown -= Time.deltaTime;
		}

		if (countdown <= 0f) {
			//button.SetActive(false);
			readyToCountDown = false;
			countdown = timeBetweenWaves;
			StartCoroutine(SpawnWave());
			difficulty += difficultyInc;
		}

		if (waveSpawnerScriptable.enemiesLeft == 0) {
			Debug.Log("in enemeiesLeft if statement");
			StartCoroutine(chooseUpg());
			readyToCountDown = true;
		}
	}

	IEnumerator SpawnWave() {

		CreateWave();

		waveSpawnerScriptable.enemiesLeft = wave.Count;

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
		button.SetActive(true);
		Debug.Log("value of button is " + button.activeSelf);
		yield return new WaitUntil(() => !button.activeSelf);
		Debug.Log("value of button is " + button.activeSelf);
		//while (button.activeSelf);
	}
}