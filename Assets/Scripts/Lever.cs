using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField]Animator am;
    [SerializeField] Animator hatch;
    public float WaitTime = 2f;
    public void Action(PlayerController script)
    {
        return;
    }

    public void Interact(PlayerController script)
    {
        StartCoroutine(HatchOpen());
        
    }

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
    }

    IEnumerator HatchOpen()
    {
        am.SetTrigger("Go");
        yield return new WaitForSeconds(WaitTime);
        hatch.SetBool("Open", true);
    }
}
