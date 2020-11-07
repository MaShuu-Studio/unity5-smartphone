using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {

    const int StageTipSize = 30;

    int currentTipIndex;

    public Transform character;
    public GameObject[] stageTips;
    public int startTipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
	}
	
	// Update is called once per frame
	void Update () {
        int characterPositionIndex = (int)(character.position.z / StageTipSize);

        if(characterPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(characterPositionIndex + preInstantiate);
        }
	}
    
    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(0, 0, tipIndex * StageTipSize),
            Quaternion.identity
            );

        return stageObject;
    }
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;

        for (int i = currentTipIndex; i < toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            stageObject.transform.parent = transform.parent;
            generatedStageList.Add(stageObject);
        }

        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

        currentTipIndex = toTipIndex;

    }

    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}

