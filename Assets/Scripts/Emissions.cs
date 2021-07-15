using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissions : MonoBehaviour
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            on = !on;
        }

        if (on)
        {
            m1.EnableKeyword("_EMISSION");
            light.enabled = true;
        }
        else
        {
            m1.DisableKeyword("_EMISSION");
            light.enabled = false;
        }
    }
}
