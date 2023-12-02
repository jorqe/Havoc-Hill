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
	public GameObject questionInterface;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public bool flag = false;
	public bool answered = false;
	public bool flag2 = true;
	public bool flag3 = true;

	void Update() {
		Debug.Log("Enemies left = " + waveSpawnerScriptable.enemiesLeft);

		if (readyToCountDown == true) {
			countdown -= Time.deltaTime;
		}

		if (countdown <= 0f && (!button1.activeSelf || !button2.activeSelf || !button3.activeSelf)) {
			readyToCountDown = false;
			countdown = timeBetweenWaves;
			StartCoroutine(SpawnWave());
			difficulty += difficultyInc;
			flag = true;
		}

		if (waveSpawnerScriptable.enemiesLeft == 0) {
			//StartCoroutine(chooseUpg());
			//StartCoroutine(trivia());
			if(flag){
				StartCoroutine(endOfWave());
			}
			else{
				Debug.Log("before readyToCountDown gets set to true");
				readyToCountDown = true;
			}
		}
	}

	IEnumerator SpawnWave() {
		Debug.Log("inside spawn wave");

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
		flag = false;
		flag3 = true;

	}

	IEnumerator trivia() {
		if(flag2){
			questionInterface.SetActive(true);
			textBoxUpdate.DisplayRandomTrivia();
			flag2 = false;
		}
		yield return new WaitUntil(() => !questionInterface.activeSelf);
		answered = true;
		flag2 = true;
	}

	IEnumerator endOfWave() {
		if (flag3){
			flag3 = false;
			StartCoroutine(trivia());
		}
		yield return new WaitUntil(() => answered);
		answered = false;
		StartCoroutine(chooseUpg());
	}
}