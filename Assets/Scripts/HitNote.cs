using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNote : MonoBehaviour
{
    public bool hit = false;

    // public void ActivateDialogue()
    // {
    //     dialogue.SetActive(true);
    // }

    // public bool DialogueActive()
    // {
    //     return dialogue.activeInHierarchy;
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            hit = true;
            
        }
        gameObject.SetActive(false);
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if(collision.tag == "Activator")
    //     {
    //         hit = false;
    //         gameObject.SetActive(false);
    //     }
    // }
}
