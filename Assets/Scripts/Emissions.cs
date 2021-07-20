using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissions : MonoBehaviour, IInteractable
{
    GameObject gameObj;
    public Light light;
    public Material m1;
    public int order;
    public bool on;

   

    // Start is called before the first frame update
    void Awake()
    {
        gameObj = this.gameObject;
        light = GetComponent<Light>();
        m1.DisableKeyword("_EMISSION");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ON(bool on)
    {
        if (on)
        {
            m1.EnableKeyword("_EMISSION");
            light.enabled = true;
        }
        else if(!on)
        {
            m1.DisableKeyword("_EMISSION");
            light.enabled = false;
        }
    }
    IEnumerator LightOn()
    {
        ON(true);
        yield return new WaitForSeconds(.2f);
        ON(false);
    }

    public void Interact(PlayerController script)
    {
        
        SimonSays ss = FindObjectOfType<SimonSays>();
        if (ss.lightOrder[0] == order && (!ss.s1 && !ss.s2 && !ss.s3 && !ss.s4 && !ss.s5))
        {

            ss.s1 = true;
            Debug.Log("PULL");
            StartCoroutine(LightOn());
        }
        else if(ss.lightOrder[1] == order && (ss.s1 && !ss.s2 && !ss.s3 && !ss.s4 && !ss.s5))
        {
            ss.s2 = true;
            Debug.Log("PULL");
            StartCoroutine(LightOn());
        }
        else if(ss.lightOrder[2] == order && (ss.s1 && ss.s2 && !ss.s3 && !ss.s4 && !ss.s5))
        {

            ss.s3 = true;
            Debug.Log("PULL");
            StartCoroutine(LightOn());
        }
        else if(ss.lightOrder[3] == order && (ss.s1 && ss.s2 && ss.s3 && !ss.s4 && !ss.s5))
        {

            ss.s4 = true;
            Debug.Log("PULL");
            StartCoroutine(LightOn());
        }
        else if(ss.lightOrder[4] == order && (ss.s1 && ss.s2 && ss.s3 && ss.s4 && !ss.s5))
        {

            ss.s5 = true;
            Debug.Log("PULL");
            StartCoroutine(LightOn());
        }
        else
        {
            Debug.Log("fuck");
            ss.s1 = false;
            ss.s2 = false;
            ss.s3 = false;
            ss.s4 = false;
            ss.s5 = false;
            StartCoroutine(ss.StartRound1());

        }
    }
    public void Action(PlayerController script)
    {

    }
    
}
