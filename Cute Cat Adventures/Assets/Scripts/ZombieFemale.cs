using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFemale : MonoBehaviour {

    public GameObject headCollider;
    public GameObject bodyCollider;

	// Use this for initialization
	void Awake () {
        headCollider = headCollider.GetComponent<GameObject>();
        bodyCollider = bodyCollider.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("EnemyCollided !");
    }
}
