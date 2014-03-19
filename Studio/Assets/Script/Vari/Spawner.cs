using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

    public float spawnOffset = 3.0f;
    public float SpawnDelay = 5;

    int enemyCount = 0;
    int currentWave = 1;

	// Use this for initialization
	void Start () 
    {
        enemyCount = currentWave * 4;
        Spawn();
	}

    private void Spawn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var enemyInstance = (GameObject)Instantiate(enemy, randomSpawnPoint, Quaternion.identity);

            SetAITarget(enemyInstance);
        }
    }

    void EnemyHasDied()
    {
        enemyCount--;
    }

    void OnGUI()
    {
        // Label
        GUI.Label(new Rect(10, 10, 100, 20), "Enemy: " + enemyCount);
    }

    private void SetAITarget(GameObject enemyInstance)
    {
        var ai = enemyInstance.GetComponent<EnemyAI>();

        ai.target = player.transform;

        ai.hasDied = EnemyHasDied;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (enemyCount <= 0)
        {
            currentWave++;
            enemyCount = currentWave * 4;
            Invoke("Spawn", SpawnDelay);

            Debug.Log("spawn" + currentWave);
        }
	}

    Vector3 randomSpawnPoint
    {
        get 
        {
            int randIndex = Random.Range(0, transform.childCount - 1);
            return Random.insideUnitSphere * spawnOffset + transform.GetChild(randIndex).position;
        }
    }
}
