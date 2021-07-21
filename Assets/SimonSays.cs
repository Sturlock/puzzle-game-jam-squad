using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour, IInteractable
{
    public List<Emissions> em;
    int x = 10;
    int i = 0;
    public int[] lightOrder;
    

    public bool s1 = false;
    public bool s2 = false;
    public bool s3 = false;
    public bool s4 = false;
    public bool s5 = false;
    
    [Header("Completed Settings")]
    public Material mComplete;
    [SerializeField] bool completed = false;
    [SerializeField] Animator am;
    [SerializeField] Animator hatch;
    [SerializeField] Animator doors;

    void Start()
    {
        am = GetComponentInParent<Animator>();
    }
    // Start is called before the first frame update
    public IEnumerator StartRound1()
    {
        for (int i = 0; i < lightOrder.Length; i++)
        {
            lightOrder[i] = Random.Range(0, em.Count);
            //Debug.Log(lightOrder[i]);
        }
        
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < lightOrder.Length; i++)
        {
            em[lightOrder[i]].ON(true);
            yield return new WaitForSeconds(.3f);
            em[lightOrder[i]].ON(false);
            yield return new WaitForSeconds(.1f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (s1 && s2 && s3 && s4 && s5)
        {
            Debug.Log("Complete");
            completed = true;
            s1 = false;
            s2 = false; 
            s3 = false;
            s4 = false; 
            s5 = false;
        }
        if (completed)
        {
            gameObject.GetComponent<MeshRenderer>().material = mComplete;
        }
    }

    public void Interact(PlayerController script)
    {
        if (completed)
        {
            StartCoroutine(Elevator());
            
        }
        else
        {
            StartCoroutine(StartRound1());
        }
        
    }

    private IEnumerator Elevator()
    {
        hatch.SetBool("Open", false);
        yield return new WaitForSeconds(.1f);
        am.SetTrigger("Go");
        yield return new WaitForSeconds(3f);
        doors.SetBool("Open", true);
    }

    public void Action(PlayerController script)
    {
        return;
    }
}
