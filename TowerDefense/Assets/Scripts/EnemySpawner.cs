using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.5f,60f)][SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}
	
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
