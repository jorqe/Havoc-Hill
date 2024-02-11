using UnityEngine;

public class Enemy : MonoBehaviour {

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

    private void Start() {
		if(waypointsNum == 1)
			target = Waypoints.points[0];
		else if(waypointsNum == 2)
			target = Waypoints2.points[0];
		else if(waypointsNum == 3)
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
		if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
			GetNextWaypoint();
		}
    }

	void GetNextWaypoint() {
		if(waypointsNum == 1) {
			if(wavepointIndex >= Waypoints.points.Length) {
				Destroy(gameObject);
				waveSpawnerScriptable.enemiesLeft--;
				playerStatsScriptable.currentHealth -= waveSpawnerScriptable.damage;
				return;
			}
			target = Waypoints.points[wavepointIndex];
			transform.LookAt(target);
		}

		if(waypointsNum == 2) {
			if(wavepointIndex >= Waypoints2.points.Length) {
				Destroy(gameObject);
				waveSpawnerScriptable.enemiesLeft--;
				playerStatsScriptable.currentHealth -= waveSpawnerScriptable.damage;
				return;
			}
			target = Waypoints2.points[wavepointIndex];
			transform.LookAt(target);
		}

		if(waypointsNum == 3) {
			if(wavepointIndex >= Waypoints3.points.Length) {
				Destroy(gameObject);
				waveSpawnerScriptable.enemiesLeft--;
				playerStatsScriptable.currentHealth -= waveSpawnerScriptable.damage;
				return;
			}
			target = Waypoints3.points[wavepointIndex];
			transform.LookAt(target);
		}

		wavepointIndex++;
	}
	
	void OnTriggerEnter(Collider other) {
		bool crit;
		if (other.CompareTag("Bullet")) {
            Debug.Log("Enemy health: " + health);
			crit = bullet.CalculateCrit(bullet.critChance);
			if (crit){
				health = health - (2 * bullet.bulletDamage);
			}
			else{
            	health -= bullet.bulletDamage;
			}

			Debug.Log("Enemy health: " + health);
        }

        if (health <= 0) {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
			waveSpawnerScriptable.enemiesLeft--;
        }
	}

}
