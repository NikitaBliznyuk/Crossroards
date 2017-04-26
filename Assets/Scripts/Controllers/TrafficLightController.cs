using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    private enum Lights { Red, Yellow, Green }

    public List<Sprite> colors;

    private SpriteRenderer spriteRenderer;

    private Lights state = Lights.Red;

    public bool IsGreen { get { return state == Lights.Green; } }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ToggleState(bool on)
    {
        state = on ? Lights.Green : Lights.Red;

        spriteRenderer.sprite = colors[(int)state];
    }
}
