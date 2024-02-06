using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Cinemachine.Utility;
using Cinemachine;

public class CameraAim : MonoBehaviour
{
    [SerializeField] Movment movment;

    [SerializeField] CinemachineVirtualCamera Vcam;
    [SerializeField] Camera cam;
    [SerializeField] Transform playerTra;
    [SerializeField] float threshold;

    private void Update()
    {
         if (movment.IsAiming!)
         {
             Vcam.Follow = this.transform;
             Vcam.LookAt = null;
             CameraLookAhead();
         }
         else
         {
            Vcam.Follow = playerTra;
             Vcam.LookAt = playerTra;
         }
    }

    private void CameraLookAhead()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (playerTra.position + mousePos) / 2f;


        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + playerTra.position.x, threshold + playerTra.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + playerTra.position.y, threshold + playerTra.position.y);

        this.transform.position = targetPos;

    }

}
