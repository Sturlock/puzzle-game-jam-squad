using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissions : MonoBehaviour, IInteractable
{
    public Light light;
    public Material m1;
    public bool on;

    // Start is called before the first frame update
    void Awake()
    {
        light = GetComponent<Light>();
        m1.DisableKeyword("_EMISSION");
    }
    // Update is called once per frame
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

    public void Interact(PlayerController script)
    {
        SimonSays ss = FindObjectOfType<SimonSays>();
        if (ss.em[4] == this)
        {
            StartCoroutine(LightOn());
            return;
        }
        if (ss.em[8] == this)
        {
            StartCoroutine(LightOn());
            return;
        }
        if (ss.em[0] == this)
        {
            StartCoroutine(LightOn());
            return;
        }
        if (ss.em[3] == this)
        {
            StartCoroutine(LightOn());
            return;
        }
    }
    public void Action(PlayerController script)
    {

    }
    IEnumerator LightOn()
    {
        ON(true);
        yield return new WaitForSeconds(.2f);
        ON(false);
    }
}
