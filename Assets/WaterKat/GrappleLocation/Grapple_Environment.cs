using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_Environment : MonoBehaviour
{
    [SerializeField]
    private new SpriteRenderer renderer;
    [SerializeField]
    private Color outOfRange;
    [SerializeField]
    private Color withinRange;
    [SerializeField]
    private Color active;

    [SerializeField]
    private float colorChangeSpeed = 0.1f;

    private Coroutine colorChangeCoroutine;

    private enum grappleIconStates
    {
        debug = 0,
        outofrange=1,
        withinrange=2,
        active=3,
    }
    private grappleIconStates state = grappleIconStates.outofrange;

    private void Start()
    {
        ChangeColorOutOfRange();
        Debug.Log("active icon");
    }

    public void ChangeColorActive()
    {
        if (state == grappleIconStates.active)
            return;
        state = grappleIconStates.active;

        if (colorChangeCoroutine != null)
        {
            StopCoroutine(colorChangeCoroutine);
        }
        colorChangeCoroutine = StartCoroutine(changeColor(renderer.color, active));
    }

    public void ChangeColorWithinRange()
    {
        if (state == grappleIconStates.withinrange)
            return;
        state = grappleIconStates.withinrange;

        if (colorChangeCoroutine != null)
        {
            StopCoroutine(colorChangeCoroutine);
        }
        colorChangeCoroutine = StartCoroutine(changeColor(renderer.color, withinRange));
    }

    public void ChangeColorOutOfRange()
    {
        if (state == grappleIconStates.outofrange)
            return;
        state = grappleIconStates.outofrange;

        Debug.Log("coloroutofrange"); 

        if (colorChangeCoroutine != null)
        {
            StopCoroutine(colorChangeCoroutine);
        }
        colorChangeCoroutine = StartCoroutine(changeColor(renderer.color, outOfRange));
    }

    IEnumerator changeColor(Color colorA,Color colorB)
    {
        float timeElapsed = 0f;
        while (timeElapsed < colorChangeSpeed)
        {
            timeElapsed += Time.deltaTime;

            renderer.color = Color.Lerp(colorA, colorB, timeElapsed / colorChangeSpeed);
            yield return null;
        }

        renderer.color = colorB;
        Debug.Log("coloroutofrangefinished");
    }
}
