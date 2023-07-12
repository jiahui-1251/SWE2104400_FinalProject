using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished{get; private set;}

        protected IEnumerator WriteText(string input, TextMeshProUGUI  textHolder, float delay, AudioClip sound, float delayBetweenLines)
        {
            int i;
            for(i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delayBetweenLines);

            finished = true;
        }
    }
}

