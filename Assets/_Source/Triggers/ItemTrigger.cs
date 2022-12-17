using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTrigger : MonoBehaviour
{
    [SerializeField] private ItemInput inputer;
    [SerializeField] private Image pressE;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            inputer.enabled = true;
            pressE.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            inputer.enabled = false;
            pressE.gameObject.SetActive(false);
        }
    }
}
