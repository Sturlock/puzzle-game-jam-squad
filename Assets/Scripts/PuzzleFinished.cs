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

    public void ChangeNextLevelDoor(GameObject desiredObject, Vector3 desiredLocation)
    {
        objectChanging = desiredObject;
        startLocation = objectChanging.transform.position;
        targetLocation = desiredLocation;
        startTime = Time.time;
    }

    private void Change()
    {
        float t = (Time.time - startTime) / duration;
        
        objectChanging.transform.position = new Vector3(Mathf.SmoothStep(startLocation.x, targetLocation.x, t),
                                                        Mathf.SmoothStep(startLocation.y, targetLocation.y, t),
                                                        Mathf.SmoothStep(startLocation.z, targetLocation.z, t));
        
        if (objectChanging.transform.position == targetLocation)
            ChangeFinished();
    }

    private void ChangeFinished()
    {
        objectChanging = null;
    }
    

}
