using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DS.ScriptableObjects
{
    public class ButtonAppearance : MonoBehaviour
    {
        [SerializeField] private Image _buttonColor;
        [SerializeField] private TextMeshProUGUI _textColor;
        private float appearance;
        private void Start()
        {
            appearance = AppearanceTimers.Instance.TimeForButtons;
        }
        private void OnEnable()
        {
            StartCoroutine(MakeVisible());
        }

        IEnumerator MakeVisible()
        {
            for(float f = 0.05f; f <= 1f; f += 0.05f)
            {
                Color buttonColor = _buttonColor.color;
                Color textColor = _textColor.color;
                buttonColor.a = f;
                textColor.a = f;
                _buttonColor.color = buttonColor;
                _textColor.color = textColor;
                yield return new WaitForSeconds(appearance);
            }
        }
    }
}