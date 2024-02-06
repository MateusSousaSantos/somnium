using UnityEngine;
using Cinemachine;
using CodeMonkey.Utils;
using UnityEngine.Rendering.VirtualTexturing;

public class PlayerAim : MonoBehaviour
{
    public float currentSize = 5f;
    public float newSize = 5f;
    public float angle;
    public GameObject aim_transform;
    player_movement player_movement;

    public Vector3 AimDirection { get; private set; }

    private Transform aimTransform;
    private SpriteRenderer aimSpriteRenderer;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimSpriteRenderer = aimTransform.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        HandleAiming();
        

    }

    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        AimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        aimSpriteRenderer.flipY = (angle > 90 || angle < -90);


    }



    /*private void UpdateFov()
    {
        scpFov.SetAimDirection(AimDirection);
        scpFov.SetOringin(transform.position);
    }*/
}
