using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    const int SphereCandyFrequency = 4;
    const int MaxShotPower = 5;
    const int Recoveryseconds = 3;

    public GameObject[] candyPrefab;
    public GameObject[] candySquarePrefab;
    public CandyHolder candys;
    public float shotSpeed;
    public float shotTorque;
    public float baseWidth;

    int shotPower = MaxShotPower;
    AudioSource shotSound;

	// Use this for initialization
	void Start () {
        shotSound = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
    }
    
    GameObject SampleCandy()
    {
        GameObject prefab = null;

        if (Random.Range(1, SphereCandyFrequency) == 1)
        {
            int index = Random.Range(0, candyPrefab.Length);
            prefab = candyPrefab[index];
        }
        else
        {
            int index = Random.Range(0, candySquarePrefab.Length);
            prefab = candySquarePrefab[index];
        }

        return prefab;
    }

    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth *
            (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    void Shot()
    {
        if (candys.GetCandyAmount() <= 0 || shotPower <= 0) return;
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            Quaternion.identity
            );

        candy.transform.parent = candys.transform;

        Rigidbody candyRigidbody = candy.GetComponent<Rigidbody>();
        candyRigidbody.AddForce(transform.forward * shotSpeed);
        candyRigidbody.AddTorque(new Vector3(0, shotTorque, 0));

        shotSound.Play();
        candys.ConsumeCandy();
        ConsumePower();
    }
    
    void ConsumePower()
    {
        shotPower--;
        StartCoroutine(RecoveryPower());
    }

    IEnumerator RecoveryPower()
    {
        yield return new WaitForSeconds(Recoveryseconds);
        shotPower++;
    }

    void OnGUI()
    {
        GUI.color = Color.black;

        GUIStyle labelstyle = new GUIStyle();
        labelstyle.fontSize = 100;

        string label = "";
        for (int i = 0; i < shotPower; i++) label = label + "◎";

        GUI.Label(new Rect(10, 70, 500, 500), label, labelstyle);
       
    }

}
