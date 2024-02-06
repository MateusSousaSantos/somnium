using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDestroyed : TakeDamage
{
    [SerializeField] int MaxVida = 40;
    [SerializeField] int CurrentVida;

    public override void ReceiveDamage(int Damage)
    {
        CurrentVida -= Damage;
    }

    private void Update()
    {
        Died();
    }

    public void Died()
    {
        if (CurrentVida <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CurrentVida = MaxVida;
    }
}
