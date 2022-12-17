using DS.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class DialogInputer : MonoBehaviour
{
    [SerializeField] private DialogueStarter ds;
    [SerializeField] private DialogueNameSaver dsName;
    [SerializeField] private SC_FPSController player;
    [SerializeField] private Image pressE;
    [SerializeField] private Image inventory;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.enabled = false;
            ds.StartDialogue(dsName);
            pressE.gameObject.SetActive(false);
            inventory.gameObject.SetActive(false);
        }
    }
}