using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    public WeightedPads wp1;
    public WeightedPads wp2;
    Animator am;
    

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wp1.GetHit3() && wp2.GetHit4())
        {
           
            am.SetTrigger("Go");
        }
    }
}
