using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class viewRenderer : MonoBehaviour
{
    [SerializeField] Tilemap quarto;
    [SerializeField] TilemapRenderer quarto_render;
    public Color opacity;
    public bool enter = false;

    private Coroutine opacityCoroutine;
    private float targetOpacity;
    private float transitionDuration = 0.6f; 

    private void FixedUpdate()
    {
        if (enter)
        {
           quarto_render.sortingOrder = -10;
           
            targetOpacity = 0f;
        }
        else
        {
            quarto_render.sortingOrder = 9;
            
            targetOpacity = 1f;
        }

        if (opacityCoroutine == null)
        {
            opacityCoroutine = StartCoroutine(SmoothOpacityTransition());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            enter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            enter = false;
        }
    }

    private IEnumerator SmoothOpacityTransition()
    {
        float initialOpacity = opacity.a;
        float timeElapsed = 0f;

        while (timeElapsed < transitionDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / transitionDuration);

            opacity.a = Mathf.Lerp(initialOpacity, targetOpacity, t);
            quarto.color = opacity;

            yield return null;
        }

        opacity.a = targetOpacity;
        quarto.color = opacity;

        opacityCoroutine = null;
    }
}
