using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        [Header("Text")]
        [SerializeField] private string input;
        private TextMeshProUGUI textHolder;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            imageHolder.sprite = characterSprite;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input,textHolder, delay, sound, delayBetweenLines));
        }
    }
}

