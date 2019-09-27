using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int playerHealth = 10;
    [SerializeField] int healthDecrease = 1;

    [SerializeField] Text health;

    [SerializeField] AudioClip enemyWinSFX;

	// Use this for initialization
	void Start () {
        health.text = playerHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(enemyWinSFX);
        playerHealth -= healthDecrease;
        health.text = playerHealth.ToString();
    }
}
