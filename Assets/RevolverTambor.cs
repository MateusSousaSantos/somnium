using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverTambor : MonoBehaviour
{

    [SerializeField] RevolverShooting revolverShooting;
    public Image tambor;
    [SerializeField] Sprite[] tamborSprites = new Sprite[9];
    [SerializeField] int CurrentAmunition;
    private void FixedUpdate()
    {
        CurrentAmunition = revolverShooting.CurrentAmunition;

        switch(CurrentAmunition)
        {
            case 0: 
                tambor.sprite = tamborSprites[0];
                    break;
            case 1:
                tambor.sprite = tamborSprites[1];
                break;
            case 2:
                tambor.sprite = tamborSprites[2];
                break;
            case 3:
                tambor.sprite = tamborSprites[3];
                break;
            case 4:
                tambor.sprite = tamborSprites[4];
                break;
            case 5:
                tambor.sprite = tamborSprites[5];
                break;
            case 6:
                tambor.sprite = tamborSprites[6];
                break;
            case 7:
                tambor.sprite = tamborSprites[7];
                break;
            case 8:
                tambor.sprite = tamborSprites[8];
                break;
        }

    }


}
