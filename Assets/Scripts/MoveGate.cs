using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGate : MonoBehaviour
{
    public GameObject pad;
    public WeightedPads wp;
    public Animator am;
    // Start is called before the first frame update
    void Start()
    {
        wp = pad.GetComponent<WeightedPads>();
        am = am.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wp.GetHit1() == true)
        {
            am.SetTrigger("Go");
        }
        
    }
}
