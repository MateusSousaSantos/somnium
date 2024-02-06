using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class viewRenderer2 : MonoBehaviour
{
    [SerializeField] Tilemap quarto2;
    [SerializeField] TilemapRenderer quarto_render2;
    public Color opacity2;
    public bool enter2 = false;

    private Coroutine opacityCoroutine2;
    private float targetOpacity2;
    private float transitionDuration2 = 0.6f;

    private void FixedUpdate()
    {
        if (enter2)
        {
           // quarto_render2.sortingOrder = -10;

            targetOpacity2 = 0f;
        }
        else
        {
           // quarto_render2.sortingOrder = 0;

            targetOpacity2 = 1f;
        }

        if (opacityCoroutine2 == null)
        {
            opacityCoroutine2 = StartCoroutine(SmoothOpacityTransition2());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            enter2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            enter2 = false;
        }
    }

    private IEnumerator SmoothOpacityTransition2()
    {
        float initialOpacity = opacity2.a;
        float timeElapsed = 0f;

        while (timeElapsed < transitionDuration2)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / transitionDuration2);

            opacity2.a = Mathf.Lerp(initialOpacity, targetOpacity2, t);
            quarto2.color = opacity2;

            yield return null;
        }

        opacity2.a = targetOpacity2;
        quarto2.color = opacity2;

        opacityCoroutine2 = null;
    }
}
