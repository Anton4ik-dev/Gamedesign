using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace DS.ScriptableObjects
{
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] private SC_FPSController player;
        [SerializeField] private Image inventory;
        [SerializeField] private GameObject _dialogueUI;

        [SerializeField] private GameObject _player;
        [SerializeField] private Image _playerIcon;
        [SerializeField] private TextMeshProUGUI _playerName;

        [SerializeField] private GameObject _person;
        [SerializeField] private Image _personIcon;
        [SerializeField] private TextMeshProUGUI _personName;

        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private Button _nextDialogueButton;

        [SerializeField] private GameObject _multipleChoices;

        [SerializeField] private CharacterAppearance characterClass;

        private DSDialogueSO so;
        private string _folderName;
        private DialogueNameSaver nextDialogueName;
        public void StartDialogue(DialogueNameSaver folderName)
        {
            _folderName = folderName.DialogueName;
            nextDialogueName = folderName;
            Object[] arr = Resources.LoadAll($"Dialogues/{_folderName}/Global/Dialogues", typeof(DSDialogueSO));
            _dialogueUI.SetActive(true);
            for (int i = 0; i < arr.Length; i++)
            {
                so = (DSDialogueSO)arr[i];
                if(so.IsStartingDialogue)
                {
                    break;
                }
            }
            CheckInterlocutor();
            TextAppear();            
        }
        public void StartDialogue(string folderName)
        {
            _folderName = folderName;
            Object[] arr = Resources.LoadAll($"Dialogues/{_folderName}/Global/Dialogues", typeof(DSDialogueSO));
            _dialogueUI.SetActive(true);
            for (int i = 0; i < arr.Length; i++)
            {
                so = (DSDialogueSO)arr[i];
                if (so.IsStartingDialogue)
                {
                    break;
                }
            }
            CheckInterlocutor();
            TextAppear();
        }
        public void NextDialogue(int choiceNumber)
        {
            _multipleChoices.SetActive(false);
            _nextDialogueButton.gameObject.SetActive(false);
            _person.SetActive(false);
            _player.SetActive(false);
            if (so.Choices[choiceNumber].NextDialogue != null)
            {
                so = Resources.Load<DSDialogueSO>($"Dialogues/{_folderName}/Global/Dialogues/{so.Choices[choiceNumber].NextDialogue.ID}");
            } else
            {
                FinishDialogue();
                return;
            }
            CheckInterlocutor();
            TextAppear();
        }

        public void CheckDialogueType()
        {
            if (so.DialogueType == 0)
            {
                _nextDialogueButton.gameObject.SetActive(true);
            }
            else
            {
                _multipleChoices.SetActive(true);
                for (int i = 0; i < _multipleChoices.transform.childCount; i++)
                {
                    if(i < so.Choices.Count)
                    {
                        _multipleChoices.transform.GetChild(i).gameObject.SetActive(true);
                        _multipleChoices.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = $"{i+1}. " + so.Choices[i].Text;
                    } else
                    {
                        _multipleChoices.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
        }
        private void CheckInterlocutor()
        {
            if (!so.IsInterlocutor)
            {
                _player.SetActive(true);
                _playerIcon.sprite = so.iconPerson;
                _playerName.text = so.DialogueName;
            }
            else
            {
                _person.SetActive(true);
                _personIcon.sprite = so.iconPerson;
                _personName.text = so.DialogueName;
            }
        }

        private void FinishDialogue()
        {
            _dialogueUI.SetActive(false);
            _player.SetActive(false);
            _person.SetActive(false);
            _nextDialogueButton.gameObject.SetActive(false);
            _multipleChoices.SetActive(false);
            nextDialogueName.DialogueName = so.NextDialogue;
            player.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventory.gameObject.SetActive(true);
        }

        private void TextAppear()
        {
            if (so.IsAppear)
            {
                characterClass.TextAppearance(so.Text);
            }
            else
            {
                _dialogueText.text = so.Text;
                CheckDialogueType();
            }
        }
    }
}