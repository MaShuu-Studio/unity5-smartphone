using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInchecker : MonoBehaviour {

    public Hole red;
    public Hole blue;
    public Hole green;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        string label = " ";

        if(red.IsFallIn() && blue.IsFallIn() && green.IsFallIn())
        {
            label = "Fall In hole!";
        }
        int width = Screen.width;
        int height = Screen.height;
        GUI.Label(new Rect(0, 0, 500, 200), label);
    }
}
