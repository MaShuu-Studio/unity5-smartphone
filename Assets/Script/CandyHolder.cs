using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour {

    const int DefaultCandyAmount = 30;
    const int RecoveryTime = 10;

    int candy;
    int counter;
    bool counterEnd = true;
    bool counterContinue = false;

    // Use this for initialization
    void Start () {
        candy = DefaultCandyAmount;
	}

    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }
    public void AddCandy(int amount)
    {
        candy += amount;
    }
    public int GetCandyAmount()
    {
        return candy;
    }

    // Update is called once per frame
   
    private void OnGUI()
    {
        GUI.color = Color.black;
        GUIStyle labelstyle = new GUIStyle();
        labelstyle.fontSize = 70;

        string label = "Candy : " + candy;

        if (counter > 0) label = label + " (" + counter + "s)";

        GUI.Label(new Rect(0, 0, 500, 500), label, labelstyle);
    }
    
    IEnumerator RecoveryCandy()
    {
        while (counter > 0 && candy < DefaultCandyAmount)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        if (counter == 0)
        {
            candy++;
            counterEnd = true;
        }
        else
            counterContinue = true;
    }
    void Update()
    {
        if (candy < DefaultCandyAmount)
        {
            if (counterEnd == true)
            {
                counterEnd = false;
                if (counter <= 0)
                    counter = RecoveryTime;
                StartCoroutine(RecoveryCandy());
            }
            else if (counterContinue == true)
            {
                counterContinue = false;
                StartCoroutine(RecoveryCandy());
            }
        }
    }

}
