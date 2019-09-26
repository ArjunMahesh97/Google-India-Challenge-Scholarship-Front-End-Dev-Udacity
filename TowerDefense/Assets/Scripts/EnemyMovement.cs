using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = 1f;
    [SerializeField] ParticleSystem winParticle;

	// Use this for initialization
	void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        EnemyWin();
    }

    private void EnemyWin()
    {
        var deathEffect = Instantiate(winParticle, transform.position, Quaternion.identity);
        deathEffect.Play();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
