using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator dialogueSequence()
    {
        int i;
        for (i = 0; i < transform.childCount; i++)
        {
            Deactivate();
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            //yield return new WaitUntil(() => transform.GetChild(i).GetComponent<BubbleController>().finished);
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
