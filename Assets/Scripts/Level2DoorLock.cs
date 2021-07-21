using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DoorLock : MonoBehaviour
{
    public GameObject lvlDoor;
    public PuzzleFinished puzManager;
    public GameObject newLocation;
    float x;
    [SerializeField] LayerMask layerMask;
    [SerializeField] CanvasGroup canvasGroup;
    bool interacted = false;
    [SerializeField] bool doThing = false;
    [SerializeField] bool canDoThing = false;
    void Start()
    {
        canvasGroup.alpha = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        canDoThing = other;
        //x += Time.time;
        //Debug.Log(x);
        if (doThing)
        {
            Debug.Log("Yeah man!");
            if (other.gameObject.transform.name == "KeyL2" && !interacted)
            {
                ItemPickUp ip = other.gameObject.GetComponent<ItemPickUp>();
                ip.Drop();
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.transform.position = newLocation.transform.position;
                other.gameObject.transform.rotation = newLocation.transform.rotation;
                puzManager.GetComponent<PuzzleFinished>().ChangeNextLevelDoor(lvlDoor);
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
        if (Input.GetButtonDown("Interact") && canDoThing)
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

