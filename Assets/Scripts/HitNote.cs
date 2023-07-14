using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleWorld
{
    public class HitNote : MonoBehaviour
    {
        public bool hit = false;
        public GameObject HitPass;
        public GameObject HitFail;
        public float delayTime = 1.0f;
        public bool userClicked = false;
        public bool finished = false;

        void Update()
        {
            if(!userClicked && Input.GetMouseButtonDown(0))
            {
                userClicked = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(userClicked);
            if(userClicked && collision.CompareTag("Activator"))
            {
                HitPass.SetActive(true);
                hit = true;
                finished = true;
                HitPass.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.tag == "Activator")
            {
                Debug.Log(hit);
                if(!hit) 
                {
                    HitFail.SetActive(true);
                    userClicked = false;
                    finished = true;
                    HitFail.SetActive(false);
                }
            }
        }

        // private IEnumerator DeactivateAfterDelay()
        // {
        //     yield return new WaitForSeconds(delayTime);
        //     // finished = true;
        //     userClicked = false;
        //     gameObject.SetActive(false);
        //     //HitResult.SetActive(false);
        // }
    }
}


