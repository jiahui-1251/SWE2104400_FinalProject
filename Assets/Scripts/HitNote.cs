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
        public GameObject Bubble;
        public float delayTime = 1.0f;
        public bool userClicked = false;
        private int i=0;
        public bool finished = false;
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && userClicked)
            {
                userClicked = false;
            }
            else if (!userClicked && Input.GetMouseButtonDown(0))
            {
                userClicked = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(userClicked && collision.CompareTag("Activator"))
            {
                //Debug.Log(gameObject.hit);
                // if(transform.position.y > 3.0f)
                // {
                //     hit = true;
                    
                //      HitPass.SetActive(true);
                //      StartCoroutine(DeactivateAfterDelay(HitPass, Bubble));
                // }
                // else
                // {
                //      HitFail.SetActive(true);
                //      StartCoroutine(DeactivateAfterDelay(HitFail, Bubble));
                // }
                hit = true;
                HitPass.SetActive(true);
                StartCoroutine(DeactivateAfterDelay(HitPass, Bubble));
            }
    
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            // if(!userClicked && collision.tag == "Activator")
            // {
            //     if(hit) hit = false;
            //     HitFail.SetActive(true);
            //     finished = true;
            //     StartCoroutine(DeactivateAfterDelay());
            // }
                if (!userClicked && collision.CompareTag("Activator"))
                {
                    if (hit)
                    {
                        HitPass.SetActive(true);
                        StartCoroutine(DeactivateAfterDelay(HitPass, Bubble));
                    }
                    else
                    {
                        HitFail.SetActive(true);
                        StartCoroutine(DeactivateAfterDelay(HitFail, Bubble));
                    }
                }

            userClicked = false;
        }

        private IEnumerator DeactivateAfterDelay(GameObject HitResult, GameObject Bubble)
        {
            yield return new WaitForSeconds(delayTime);
            // if (hit)
            // {
            //     HitPass.SetActive(false);
            // }
            // else
            // {
            //     HitFail.SetActive(false);   
            // }
            HitResult.SetActive(false);
            //Bubble.SetActive(false);
            finished = true;
            //gameObject.SetActive(false);
        }
    }

}

