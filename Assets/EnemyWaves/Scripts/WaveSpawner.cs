using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveSpawner : MonoBehaviour {
	public Transform enemyPrefab1;
	public Transform enemyPrefab2;
	public Transform enemyPrefab3;
	public Transform bossPrefab;
	public Transform spawnPoint;
	// [SerializeField] private int difficulty;
	[SerializeField] private int difficultyInc;
	[SerializeField] private float timeBetweenWaves;
	[SerializeField] private float countdown;
	// [SerializeField] private float waveNum;
	[SerializeField] private List<int> wave = new();
	private bool readyToCountDown = true;
	public WaveSpawnerScriptableObject waveSpawnerScriptable;
	public TriviaInputScriptableObject triviaInputScriptable;
	public TextBoxUpdate textBoxUpdate;
	public GameObject questionInterface;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject upgradeGUI;
	public bool flag = false;
	public bool answered = false;
	public bool flag2 = true;
	public bool flag3 = true;
	public string current_answer;
	public JSONWriter saver;


	void Start() {
		waveSpawnerScriptable.enemiesLeft = 0;
	}

	void Update() {
		//Debug.Log("Enemies left = " + waveSpawnerScriptable.enemiesLeft);

		if (readyToCountDown == true) {
			countdown -= Time.deltaTime;
		}

		if (countdown <= 0f && (!button1.activeSelf || !button2.activeSelf || !button3.activeSelf)) {
			readyToCountDown = false;
			countdown = timeBetweenWaves;
			StartCoroutine(SpawnWave());
			waveSpawnerScriptable.difficulty += difficultyInc;
			flag = true;
		}

		if (waveSpawnerScriptable.enemiesLeft == 0 && waveSpawnerScriptable.bossLeft == false) {
			//StartCoroutine(chooseUpg());
			//StartCoroutine(trivia());
			saver.Save();
			if(flag){
				StartCoroutine(endOfWave());
			}
			else{
				//Debug.Log("before readyToCountDown gets set to true");
				readyToCountDown = true;
			}
		}
	}

	IEnumerator SpawnWave() {
		Debug.Log("inside spawn wave");
        triviaInputScriptable.givenAnswer = "Testing";

        CreateWave();

		waveSpawnerScriptable.enemiesLeft += wave.Count;

		waveSpawnerScriptable.waveNum++;

		try {
			if (waveSpawnerScriptable.waveNum % 1 == 0) {
				Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
				waveSpawnerScriptable.bossLeft = true;
			}
		} catch (Exception e) {
			Debug.Log("No Boss on this spawner");
		}

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
		for (int i = 0; waveDif < waveSpawnerScriptable.difficulty; i++) {
			enemyType = UnityEngine.Random.Range(1, 4);
			wave.Add(enemyType);
			waveDif += enemyType;
		}
	}

	IEnumerator chooseUpg() {
		button1.SetActive(true);
		button2.SetActive(true);
		button3.SetActive(true);
		upgradeGUI.SetActive(true);
		yield return new WaitUntil(() => (!button1.activeSelf || !button2.activeSelf || !button3.activeSelf));
		flag = false;
		flag3 = true;

	}

	IEnumerator trivia() {
		if(flag2){
			questionInterface.SetActive(true);
			saver.Save();
			textBoxUpdate.DisplayRandomTrivia();
            current_answer = textBoxUpdate.getAnswer();
            Debug.Log("Current Answer = " + current_answer);
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
		if (triviaInputScriptable.givenAnswer == "Correct"){
            StartCoroutine(chooseUpg());
        }
		else{
			flag = false;
			flag3 = true;
		}

	}
}