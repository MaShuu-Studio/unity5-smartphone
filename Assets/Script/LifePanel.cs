using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour {

    public GameObject[] Icons;
    
    public void UpdateLife(int life)
    {
        for(int i = 0; i <Icons.Length; i++)
        {
            if (i < life) Icons[i].SetActive(true);
            else Icons[i].SetActive(false);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
