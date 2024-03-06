using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clockLifeScript : MonoBehaviour
{
    Image relogioLife;


    [SerializeField] Sprite[] sprites = new Sprite[7];
    void Start()
    {
        relogioLife = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
  


    }
}
