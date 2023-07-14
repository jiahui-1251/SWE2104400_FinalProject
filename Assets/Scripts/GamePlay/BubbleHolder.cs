using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleWorld
{
    public class BubbleHolder : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject nextLevel;

        void Start()
        {
            StartCoroutine(dialogueSequence());
        }

        private IEnumerator dialogueSequence()
        {
            int i;
            for (i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                //yield return new WaitForSeconds(1.0f);
                HitNote hitNote = transform.GetChild(i).GetComponent<HitNote>();
                hitNote.finished = false;
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<HitNote>().finished);
            }

            if(i == transform.childCount)
            {
                gameObject.SetActive(false);
                nextLevel.SetActive(true);
            }
        }
            private void Deactivate()
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
    }    
}


