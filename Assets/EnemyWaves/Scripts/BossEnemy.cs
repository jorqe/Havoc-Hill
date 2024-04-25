using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{

	[SerializeField] private float speed;
	[SerializeField] public float health;
	private int pointsWorth = 100;
	private Transform target;
	private int wavepointIndex = 0;
	private WaveSpawner waveSpawner;
	public WaveSpawnerScriptableObject waveSpawnerScriptable;
	public BulletScriptableObject bullet;
	public PlayerStatsScriptableObject playerStatsScriptable;
	public TriviaInputScriptableObject triviaInputScriptable;
	//public SoundEffectPlayer SFXPlayer;
	//public AudioClip enemySound;
	public float volume = 0.5f;
	public GameObject deathSmokePrefab;
	public GameObject damageSmokePrefab;
	public AudioSource idleSound;
	public Material flash_material;
	Animator animator;
	private bool readyToAttack = true;

	private void Start()
	{
		target = Waypoints.points[0];
		waveSpawner = GetComponentInParent<WaveSpawner>();
		animator = GetComponent<Animator>();
		// health = maxHealth;
	}

	void Update() {
		Vector3 dir = target.position - transform.position;
		transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
		/*
		float valueRandom = Random.value;
		float chanceNoise = 0.1f;
		if (valueRandom < chanceNoise)
		{
			SFXPlayer.PlaySound();
		}
		*/
		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			StartCoroutine(GetNextWaypoint());
		}

        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     health -= 10;
        // }

		// if (health <= 0)
		// {
		// 	Debug.Log("Enemy Dead");
		// 	playerStatsScriptable.score += pointsWorth;
		// 	Debug.Log("Score = " + playerStatsScriptable.score);
		// 	StartCoroutine(smoke(deathSmokePrefab));
		// 	waveSpawnerScriptable.bossLeft = false;
		// 	Destroy(gameObject); 
		// }
	}

	IEnumerator GetNextWaypoint() {
		if (wavepointIndex >= Waypoints.points.Length) {
			animator.SetTrigger("Attack");
			while (health > 0 && readyToAttack == true) {
				playerStatsScriptable.currentHealth -= waveSpawnerScriptable.damage;
				StartCoroutine(smoke(damageSmokePrefab));
				Debug.Log("Boss Attacks");
				readyToAttack = false;
				yield return new WaitForSeconds(1);
				readyToAttack = true;
			}
		} else {
			target = Waypoints.points[wavepointIndex];
			transform.LookAt(target);
		}
		wavepointIndex++;
	}

	IEnumerator collideFlash()
	{
		SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
		Material[] mats = renderer.materials;
		Material default_material = mats[0];
		mats[0] = flash_material;
		renderer.materials = mats;
		yield return new WaitForSeconds(0.1f);
		mats[0] = default_material;
		renderer.materials = mats;
	}

	IEnumerator smoke(GameObject smokeType)
	{
		Debug.Log("in smoke");
		GameObject temp = Instantiate(smokeType, gameObject.transform);
		temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y - 2f, temp.transform.position.z);
		temp.transform.SetParent(null);
		yield return new WaitForSeconds(3);
		Destroy(temp);
	}

	void OnTriggerEnter(Collider other)
	{
		int DHH = 0;
		int DLH = 0;

		if ( ((float) playerStatsScriptable.currentHealth / (float) playerStatsScriptable.maxHealth) > .8 )
			DHH = bullet.DHH;
		else if ( ((float) playerStatsScriptable.currentHealth / (float) playerStatsScriptable.maxHealth) < .2)
			DLH = bullet.DLH;

		bool crit;
		if (other.CompareTag("Bullet"))
		{
			Debug.Log("Enemy health: " + health);
			crit = bullet.CalculateCrit(bullet.critChance);
			if (crit)
			{
				health = health - (2 * bullet.bulletDamage);
				StartCoroutine(collideFlash());
			}
			else
			{
				health = health - bullet.bulletDamage - DHH - DLH;
				StartCoroutine(collideFlash());
			}
			Debug.Log("Enemy health: " + health);
		}

		if (health <= 0)
		{
			Debug.Log("Enemy Dead");
			playerStatsScriptable.score += pointsWorth;
			Debug.Log("Score = " + playerStatsScriptable.score);
			StartCoroutine(smoke(deathSmokePrefab));
			waveSpawnerScriptable.bossLeft = false;
			Destroy(gameObject);
		}
	}
}