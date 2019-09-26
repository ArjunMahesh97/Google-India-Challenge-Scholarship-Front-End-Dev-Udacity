using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.5f,60f)][SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;

    [SerializeField] Text score;
    int playerScore;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemies());

        playerScore = 0;
        score.text = playerScore.ToString();
    }
	
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            UpdateScore();

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    public void UpdateScore()
    {
        playerScore++;
        score.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
