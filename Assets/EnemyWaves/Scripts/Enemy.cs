using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	[SerializeField] private float speed;
	[SerializeField] private float health;
	[SerializeField] private int waypointsNum;
	private Transform target;
	private int wavepointIndex = 0;
	private WaveSpawner waveSpawner;
	public WaveSpawnerScriptableObject waveSpawnerScriptable;
	public BulletScriptableObject bullet;
	public PlayerStatsScriptableObject playerStatsScriptable;
	//public AudioClip enemySound;
	public float volume = 0.5f;
	//public AudioSource audioSource;
	public GameObject deathSmokePrefab;
	public GameObject damageSmokePrefab;
	public Material flash_material;

	private void Start()
	{
		if (waypointsNum == 1)
			target = Waypoints.points[0];
		else if (waypointsNum == 2)
			target = Waypoints2.points[0];
		else if (waypointsNum == 3)
			target = Waypoints3.points[0];
		waveSpawner = GetComponentInParent<WaveSpawner>();
	}

	void Update() {
		Vector3 dir = target.position - transform.position;
		transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

		float valueRandom = Random.value;
		//float chanceNoise = 0.1f;
		/*
				if (valueRandom < chanceNoise)
				{
					audioSource.PlayOneShot(enemySound, volume);
				}
		*/
		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (waypointsNum == 1)
		{
			if (wavepointIndex >= Waypoints.points.Length)
			{
				Destroy(gameObject);
				waveSpawnerScriptable.enemiesLeft--;
				StartCoroutine(smoke(damageSmokePrefab));
				playerStatsScriptable.currentHealth -= waveSpawnerScriptable.damage;
				return;
			}
			target = Waypoints.points[wavepointIndex];
			transform.LookAt(target);
		}

		if (waypointsNum == 2)
		{
			if (wavepointIndex >= Waypoints2.points.Length)
			{
				Destroy(gameObject);
				waveSpawnerScriptable.enemiesLeft--;
				StartCoroutine(smoke(damageSmokePrefab));
				playerStatsScriptable.currentHealth -= waveSpawnerScriptable.damage;
				return;
			}
			target = Waypoints2.points[wavepointIndex];
			transform.LookAt(target);
		}

		if (waypointsNum == 3)
		{
			if (wavepointIndex >= Waypoints3.points.Length)
			{
				Destroy(gameObject);
				waveSpawnerScriptable.enemiesLeft--;
				StartCoroutine(smoke(damageSmokePrefab));
				playerStatsScriptable.currentHealth -= waveSpawnerScriptable.damage;
				return;
			}
			target = Waypoints3.points[wavepointIndex];
			transform.LookAt(target);
		}

		wavepointIndex++;
	}

	IEnumerator collideFlash()
	{
		SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
		Material[] mats = renderer.materials;
		Material default_material = mats[0];
		//Material flash_material = mats[1];
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
		temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y - 3f, temp.transform.position.z);
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
			StartCoroutine(smoke(deathSmokePrefab));
			Destroy(gameObject);
			waveSpawnerScriptable.enemiesLeft--;

		}
	}

}
