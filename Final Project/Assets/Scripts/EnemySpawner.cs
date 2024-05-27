using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPool = new List<GameObject>();
    private float timePassed = 0f;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float timeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > timeToSpawn)
        {
            timePassed = 0f;
            //Vector3 spawnDirection = (Random.insideUnitCircle * transform.position).normalized;
            //Vector3 spawnPosition = transform.position + spawnDirection * spawnRadius;
            Vector3 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius + new Vector2(transform.position.x, transform.position.y);
            Instantiate(enemyPool[0], spawnPosition, Quaternion.identity);
        }
    }
}
