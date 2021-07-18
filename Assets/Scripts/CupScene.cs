using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CupScene : MonoBehaviour
{
    public VideoPlayer player;
    [SerializeField] CanvasGroup canvasGroup;
    public Image image;
    public LayerMask layerMask;
    public bool play;
    

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            canvasGroup.alpha = 1;
            if (Input.GetKeyDown(KeyCode.E))
            {
                image.gameObject.SetActive(false);
                FindObjectOfType<Movement>().enabled = false;
                FindObjectOfType<FirstPersonCamera>().enabled = false;
                player.Play();
                StartCoroutine(Reactivate());
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3f, Color.red);
            canvasGroup.alpha = 0;
        }
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(53f);
        image.gameObject.SetActive(true);
        FindObjectOfType<Movement>().enabled = true;
        FindObjectOfType<FirstPersonCamera>().enabled = true;
        player.Stop();
    }
}
