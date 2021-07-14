using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1DoorLock : MonoBehaviour
{
    public GameObject doorLvl1;
    public GameObject puzManager;
    public Vector3 newLocation;


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Woah there soldier. " + Time.time);
        if (Input.GetButton("Interact"))
        {
            Debug.Log("Yeah man!");
            if (other.gameObject.transform.name == "KeyL1")
            {
                other.gameObject.GetComponent<Pickupable>().Place();
                other.gameObject.transform.position = transform.position;

                GameObject.Find("Player").GetComponent<PlayerInteract>().OverrideHoldingItem();
                puzManager.GetComponent<PuzzleFinished>().ChangeNextLevelDoor(doorLvl1, newLocation);
            }

        }
    }
}
