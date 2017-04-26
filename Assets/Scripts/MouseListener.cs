using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseListener : MonoBehaviour
{
    private Image image;
    private Color color;

    private void Start()
    {
        image = GetComponent<Image>();
        color = image.color;
    }

    private void OnMouseEnter()
    {
        image.color = color;
    }

    private void OnMouseExit()
    {
        image.color = new Color(0, 0, 0, 0);
    }
}
