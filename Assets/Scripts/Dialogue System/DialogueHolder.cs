using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        [SerializeField] private GameObject parentObject;
        [SerializeField] private GameObject locationBox;
        
        //Load next scene
        public bool inDialogue = false;
        public string SceneName;

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
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            gameObject.SetActive(false);

            if(i == transform.childCount)
            {
                parentObject.SetActive(false);
                locationBox.SetActive(true);
            }

            if(inDialogue)
            {
                SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
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
