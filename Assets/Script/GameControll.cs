using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour {

    public NejikoController nejiko;
    public Text scoreLabel;
    public LifePanel lifePanel;

	// Use this for initialization
	void Start () {
		
	}
	
    int CalcScore()
    {
        return (int)nejiko.transform.position.z;
    }
	// Update is called once per frame
	void Update () {
        int score = CalcScore();
        scoreLabel.text = "Score : " + score + "m";
        lifePanel.UpdateLife(nejiko.Life());

        if (nejiko.Life() <= 0)
        {
            enabled = false;

            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            Invoke("ReturnToTitle", 2.0f);
        }
	}
    void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
