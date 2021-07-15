using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1DoorLock : MonoBehaviour
{
    public GameObject doorLvl1;
    public GameObject puzManager;
    public Vector3 newLocation;
    float x;
    [SerializeField] LayerMask layerMask;
    [SerializeField] CanvasGroup canvasGroup;
    bool interacted = false;
    [SerializeField] bool doThing = false;
    void Start()
    {
        canvasGroup.alpha = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        x += Time.fixedTime;
        Debug.Log(x);
        if (doThing)
        {
            Debug.Log("Yeah man!");
            if (other.gameObject.transform.name == "KeyL1" && !interacted)
            {
                ItemPickUp ip = other.gameObject.GetComponent<ItemPickUp>();
                ip.Drop();
                
                other.gameObject.transform.position = transform.position;
                other.gameObject.transform.rotation = transform.rotation;
                puzManager.GetComponent<PuzzleFinished>().ChangeNextLevelDoor(doorLvl1, newLocation);
                interacted = true;
                doThing = false;
                if (interacted)
                {
                    Destroy(ip);
                    return;
                }
            }
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            doThing = true;
            return;
        }
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, layerMask) && !interacted)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            canvasGroup.alpha = 1;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3f, Color.red);
            canvasGroup.alpha = 0;
        }
    }
}

