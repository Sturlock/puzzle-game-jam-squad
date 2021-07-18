using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public List<Emissions> em;
    int x = 10;
    int i = 0;
    public int[] lightOrder;


    

    // Start is called before the first frame update
    IEnumerator StartRound1()
    {
       x = Random.Range(0, em.Count);
        Debug.Log(x);
        yield return new WaitForSeconds(0.5f);
        em[x].ON(false);
        x = 10;
        x = Random.Range(0, em.Count);
        Debug.Log(x);
        yield return new WaitForSeconds(0.5f);
        em[x].ON(false);
        x = 10;
        x = Random.Range(0, em.Count);
        Debug.Log(x);
        yield return new WaitForSeconds(0.5f);
        em[x].ON(false);
        x = 10;
        x = Random.Range(0, em.Count);
        Debug.Log(x);
        yield return new WaitForSeconds(0.5f);
        em[x].ON(false);
        x = 10;
        x = Random.Range(0, em.Count);
        Debug.Log(x);
        yield return new WaitForSeconds(0.5f);
        em[x].ON(false);
        x = 10;
    }
    IEnumerator StartRound()
    {
        em[4].ON(true);
        yield return new WaitForSeconds(0.5f);
        em[4].ON(false);
        em[8].ON(true);
        yield return new WaitForSeconds(0.5f);
        em[8].ON(false);
        em[0].ON(true);
        yield return new WaitForSeconds(0.5f);
        em[0].ON(false);
        em[3].ON(true);
        yield return new WaitForSeconds(0.5f);
        em[3].ON(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(StartRound());
        }

        if (x == 0)
        {
            em[0].ON(true);
        }
        else if (x == 1)
        {
            em[1].ON(true);
        }
        else if (x == 2)
        {
            em[2].ON(true);
        }
        else if (x == 3)
        {
            em[3].ON(true);
        }
        else if (x == 4)
        {
            em[4].ON(true);
        }
        else if (x == 5)
        {
            em[5].ON(true);
        }
        else if (x == 6)
        {
            em[6].ON(true);
        }
        else if (x == 7)
        {
            em[7].ON(true);
        }
        else if (x == 8)
        {
            em[8].ON(true);
        }
        else
        {
            return;
        }
        
    }
    

   
}
