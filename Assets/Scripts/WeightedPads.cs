using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPads : MonoBehaviour
{
    public GameObject pad;

    [SerializeField] bool hit1;
    [SerializeField] bool hit2;
    [SerializeField] bool hit3;
    [SerializeField] bool hit4;
    [SerializeField] bool hit5;
    // Start is called before the first frame update
    void Start()
    {
        pad = this.gameObject;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (pad.tag == "Pad1" && collision.gameObject.tag == "Intractable")
        {
            hit1 = true;
        }
        if (pad.tag == "Pad2" && collision.gameObject.tag == "Intractable")
        {
            hit2 = true;
        }
        if (pad.tag == "Pad3" && collision.gameObject.tag == "Intractable")
        {
            hit3 = true;
        }
        if (pad.tag == "Pad4" && collision.gameObject.tag == "Intractable")
        {
            hit4 = true;
        }
        if (pad.tag == "Pad5" && collision.gameObject.tag == "Intractable")
        {
            hit5 = true;
        }
    }

    public bool GetHit1()
    {
        return hit1;
    }
    public bool GetHit2()
    {
        return hit2;
    }
    public bool GetHit3()
    {
        return hit3;
    }
    public bool GetHit4()
    {
        return hit4;
    }
    public bool GetHit5()
    {
        return hit5;
    }
}
