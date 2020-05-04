using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject player;
    [SerializeField]
    bool Horizontal;
    [SerializeField]
    float X;
    [SerializeField]
    float Y;
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        Vector3 playerPos = player.transform.position;
        if (Horizontal == true)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
            if (playerPos.x <= 0)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
            else if (playerPos.x >= X)
            {
                transform.position = new Vector3(X, transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
            if (playerPos.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            else if (playerPos.y >= Y)
            {
                transform.position = new Vector3(transform.position.x, Y, transform.position.z);
            }
           
        }
	}
}
