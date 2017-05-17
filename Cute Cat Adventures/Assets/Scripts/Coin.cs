using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject scoreUIText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreUIText = GameObject.FindGameObjectWithTag("Score");
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Add 50points to score
            scoreUIText.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }
}
