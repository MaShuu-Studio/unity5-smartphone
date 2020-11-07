using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public CandyHolder candys;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Candy")
        {
            candys.AddCandy(reward);

            Destroy(other.gameObject);

            if(effectPrefab != null)
            {
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation)
                    );
            }
        }
            
    }
}
