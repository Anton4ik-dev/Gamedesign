using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DS.ScriptableObjects
{
    public class CharacterAppearance : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI UIText;
        [SerializeField] private DialogueStarter starterScript;
        private float timeOfAppearance;
        private string text;

        private void Start()
        {
            timeOfAppearance = AppearanceTimers.Instance.TimeForCharacters;
        }
        public void TextAppearance(string textForAppearance)
        {
            text = textForAppearance;
            UIText.text = "";
            StartCoroutine(TextCoroutine());
        }

        IEnumerator TextCoroutine()
        {
            foreach (char abc in text)
            {
                if (!Input.GetMouseButton(0))
                {
                    UIText.text += abc;
                    yield return new WaitForSeconds(timeOfAppearance);
                } else
                {
                    UIText.text = text;
                    break;
                }
            }
            starterScript.CheckDialogueType();
        }
    }
}