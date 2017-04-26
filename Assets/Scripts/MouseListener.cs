using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseListener : MonoBehaviour
{
    public GameObject controlPanel;

    private Image image;
    private Color color;

    private void Start()
    {
        image = GetComponent<Image>();
        color = image.color;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && image.enabled)
        {
            controlPanel.SetActive(true);
        }
    }

    private void OnMouseEnter()
    {
        image.enabled = true;
    }

    private void OnMouseExit()
    {
        if(!controlPanel.activeSelf)
            image.enabled = false;
    }

    public void Close()
    {
        image.enabled = false;
        controlPanel.SetActive(false);
    }
}
