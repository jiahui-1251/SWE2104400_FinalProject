using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleWorld
{
    public class BubbleHolder : MonoBehaviour
    {
        public int startCount = 0;

        // Start is called before the first frame update
        private void Awake()
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
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<HitNote>().finished);
            }

            if(i == transform.childCount)
            {
                gameObject.SetActive(false);
            }

            // if(inDialogue)
            // {
            //     SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
            // }
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

