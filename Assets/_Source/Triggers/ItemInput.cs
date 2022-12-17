using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInput : MonoBehaviour
{
    [SerializeField] private List<Image> images;
    [SerializeField] private Sprite item;
    [SerializeField] private Image pressE;
    private static int index = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            images[index].sprite = item;
            index++;
            pressE.gameObject.SetActive(false);
        }
    }
}