using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNote : MonoBehaviour
{
    public bool hit = false;
    public GameObject HitPass;
    public GameObject HitFail;
    public float delayTime = 1.0f;
    public bool userClicked = false;
    private int i=0;

    void Update()
    {
        if(i==0 && !userClicked && Input.GetMouseButtonDown(0))
        {
            userClicked = !userClicked;
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(userClicked);
        if(userClicked && collision.CompareTag("Activator"))
        {
            hit = true;
            HitPass.SetActive(true);
            StartCoroutine(DeactivateAfterDelay(HitPass));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!userClicked && collision.tag == "Activator")
        {
            if(hit) hit = false;
            HitFail.SetActive(true);
            StartCoroutine(DeactivateAfterDelay(HitFail));
        }
    }

    private IEnumerator DeactivateAfterDelay(GameObject HitResult)
    {
        yield return new WaitForSeconds(delayTime);

        HitResult.SetActive(false);
        gameObject.SetActive(false);
    }
}
