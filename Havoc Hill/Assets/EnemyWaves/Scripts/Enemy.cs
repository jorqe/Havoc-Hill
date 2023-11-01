using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float health;
	private Transform target;
	private int wavepointIndex = 0;
	private WaveSpawner waveSpawner;
	public WaveSpawnerScriptableObject waveSpawnerScriptable;
	private void Start() {
		target = Waypoints.points[0];
		waveSpawner = GetComponentInParent<WaveSpawner>();
	}

    void Update() {
		Vector3 dir = target.position - transform.position;
		transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

		if(Vector3.Distance(transform.position, target.position) <= 0.4f) {
			GetNextWaypoint();
		}
    }

	void GetNextWaypoint() {
		if(wavepointIndex >= Waypoints.points.Length - 1) {
			Destroy(gameObject);
			waveSpawnerScriptable.enemiesLeft--;
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}
}
