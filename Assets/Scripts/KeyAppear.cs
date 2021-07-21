using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAppear : MonoBehaviour
{
    public GameObject key;
    public WeightedPads wp1;
    public WeightedPads wp2;

    [SerializeField] bool hit1;
    [SerializeField] bool hit2;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
        hit1 = false;
        hit2 = false;
    }

    void Update()
    {
        hit1 = wp1.GetHit1();
        hit2 = wp2.GetHit2();
        if (hit1 && hit2)
        {
            key.SetActive(true);
            key.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
