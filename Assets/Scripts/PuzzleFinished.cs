using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFinished : MonoBehaviour
{
    private GameObject objectChanging;
    private Vector3 startLocation;
    private Vector3 targetLocation;

    private float duration = 3f;

    float startTime;

    private void Update()
    {
        if(objectChanging != null)
        {
            Change();   
        }
    }

    public void ChangeNextLevelDoor(GameObject desiredObject)
    {
        objectChanging = desiredObject;
        
    }

    private void Change()
    {
        objectChanging.GetComponent<Animator>().SetBool("Open", true);
        
        if (objectChanging.transform.position == targetLocation)
            ChangeFinished();
    }

    private void ChangeFinished()
    {
        objectChanging = null;
    }
    

}
