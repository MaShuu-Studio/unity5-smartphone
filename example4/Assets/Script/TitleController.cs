using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    public Text highScoreLabel;
    public void OnstartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
	// Use this for initialization
	void Start () {
        highScoreLabel.text = "High Score : " + PlayerPrefs.GetInt("HighScore") + "m";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
