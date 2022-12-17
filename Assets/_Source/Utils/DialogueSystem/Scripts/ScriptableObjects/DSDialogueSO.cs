using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DS.ScriptableObjects
{
    using Data;
    using Enumerations;

    public class DSDialogueSO : ScriptableObject
    {
        [field: SerializeField] public string ID { get; set; }
        [field: SerializeField] public string DialogueName { get; set; }
        [field: SerializeField] [field: TextArea()] public string Text { get; set; }
        [field: SerializeField] public List<DSDialogueChoiceData> Choices { get; set; }
        [field: SerializeField] public DSDialogueType DialogueType { get; set; }
        [field: SerializeField] public string NextDialogue { get; set; }
        [field: SerializeField] public bool IsStartingDialogue { get; set; }
        [field: SerializeField] public Sprite iconPerson;
        [field: SerializeField] public bool IsInterlocutor {get; set;}
        [field: SerializeField] public bool IsAppear {get; set;}

        public void Initialize(string id, string dialogueName, string text, List<DSDialogueChoiceData> choices, DSDialogueType dialogueType, string nextDialogue, bool isStartingDialogue, Object obj, bool isInterlocutor, bool isAppear)
        {
            ID = id;
            DialogueName = dialogueName;
            Text = text;
            Choices = choices;
            DialogueType = dialogueType;
            NextDialogue = nextDialogue;
            IsStartingDialogue = isStartingDialogue;
            iconPerson = obj.ConvertTo<Sprite>();
            IsInterlocutor = isInterlocutor;
            IsAppear = isAppear;
        }
    }
}