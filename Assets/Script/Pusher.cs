using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

    Vector3 startPostion;

    public float amplitude;
    public float speed;

	// Use this for initialization
	void Start () {
        startPostion = transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () {
        float z = amplitude * Mathf.Sin(Time.time * speed);

        transform.localPosition = startPostion + new Vector3(0, 0, z);
	}
}
