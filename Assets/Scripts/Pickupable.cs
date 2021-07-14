using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public bool leaveColliderOn;
    public Transform placement;

    private new Collider collider;
    private Rigidbody rb;
    private bool inAir = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
            
        if (GetComponent<BoxCollider>())
            collider = GetComponent<BoxCollider>();
        else
            collider = GetComponent<MeshCollider>();
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {

        }

    }

    void Update()
    {
        if (inAir)
        {
            Debug.Log(placement.transform.localRotation.y);
        }
    }

    public void PickUp()
    {
        this.transform.position = placement.transform.position;
        this.transform.SetParent(placement.transform);
        if (!leaveColliderOn)
            collider.enabled = false;
        rb.useGravity = false;
        inAir = true;
    }

    public void Drop()
    {
        placement.DetachChildren();
        if (!leaveColliderOn)
            collider.enabled = true;
        rb.useGravity = true;
        inAir = false;
    }

    public void Place()
    {
        placement.DetachChildren();
        inAir = false;
        transform.tag = "Untagged";
    }
}
