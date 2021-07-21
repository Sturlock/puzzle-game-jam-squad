using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenR4 : MonoBehaviour
{
    [SerializeField] Animator am;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            am.SetBool("Open", true);
        }
    }
}
