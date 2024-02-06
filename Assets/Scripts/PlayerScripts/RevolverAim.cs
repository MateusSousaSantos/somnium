using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverAim : MonoBehaviour
{
    [SerializeField] SpriteRenderer Renderer;
    [SerializeField] Movment movment;

    private void FixedUpdate()
    {


        if (movment.Player_ControlCharacter! && movment.IsDead != true)
        {

                Vector3 mousePos = Input.mousePosition;
                Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

                Vector2 offset = new Vector2(mousePos.x + 1f - screenPoint.x, mousePos.y + 1f - screenPoint.y);

                float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0, 0, angle);

                if (mousePos.x < screenPoint.x)
                {
                    Renderer.flipY = true;

                }
                else
                {
                    Renderer.flipY = false;

                }


        }
        else{
            Renderer.sprite = null;
        }

    }
}
