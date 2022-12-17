using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private DialogInputer inputer;
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