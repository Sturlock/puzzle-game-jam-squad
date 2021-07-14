using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1DoorLock : MonoBehaviour
{
    public GameObject doorLvl1;
    public GameObject puzManager;
    public Vector3 newLocation;
    
    [SerializeField] LayerMask layerMask;
    [SerializeField] CanvasGroup canvasGroup;
    bool uiEnable = false;
    void Start()
    {
        canvasGroup.alpha = 0;
    }

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
        if (other.gameObject.transform.name == "KeyL1")
        {
            uiEnable = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == "KeyL1")
        {
            uiEnable = false;
        }
    }

    void FixedUpdate()
    {
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (uiEnable)
            {
                canvasGroup.alpha = 1;
            }
            else
            {
                canvasGroup.alpha = 0;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3f, Color.red);
            canvasGroup.alpha = 0;
        }
    }
}

