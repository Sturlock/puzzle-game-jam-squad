using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Fernando747
public class LigthController : MonoBehaviour
{
    [SerializeField] private Light myLight;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Volume;
    void Start()
    {
        myLight.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Volume.gameObject.SetActive(false);
    }

    public void OnMouseEnter()
    {
        myLight.gameObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        myLight.gameObject.SetActive(false);
    }

    public void OnMouseUpAsButton()
    {
        string Name = this.gameObject.name;

        switch (Name)
        {
            case "Start":
                SceneManager.LoadScene(1);
                break;

            case "Settings":
                StartCoroutine(MoveCanvas(new Vector3(0,-14,0)));
                break;

            case "Back":
                StartCoroutine(MoveCanvas(Vector3.zero));
                Volume.gameObject.SetActive(false);
                Credits.gameObject.SetActive(false);
                break;

            case "Credits":
                Credits.gameObject.SetActive(!Credits.gameObject.activeInHierarchy);
                Volume.gameObject.SetActive(false);
                break;

            case "Volume":
                Volume.gameObject.SetActive(!Volume.gameObject.activeInHierarchy);
                Credits.gameObject.SetActive(false);
                break;
        }
    }

    public IEnumerator MoveCanvas(Vector3 Target)
    {
            while (Canvas.transform.position != Target)
        {
            Canvas.transform.position = Vector3.MoveTowards(Canvas.transform.position, Target, 10 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
