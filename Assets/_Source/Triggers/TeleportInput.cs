using UnityEngine;
using UnityEngine.UI;

public class TeleportInput : MonoBehaviour
{
    [SerializeField] private Transform teleportPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Image pressE;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            characterController.enabled = false;
            player.transform.position = teleportPosition.position;
            characterController.enabled = true;
            pressE.gameObject.SetActive(false);
        }
    }
}