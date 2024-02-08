using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEstatisticas : TomarDano
{

    [SerializeField] Movment movment;
    public int VidaMax = 100;
    public int CurrentVida;

    public int SaniMax = 250;
    public int CurrentSani;

    Animator Playeranimator;
    private Vector3 originalPosition;
    [SerializeField] GameObject bodyPrefab;

    public bool cooldownInProgress = false;



    private void Start()
    {
        CurrentVida = VidaMax;
        CurrentSani = SaniMax;
        Playeranimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Dead();
    }

    public void Dead()
    {
        if(CurrentVida <= 0 && !cooldownInProgress)
        {
            movment.IsDead = true;
            cooldownInProgress = true;
            Playeranimator.SetBool("isDead",true);
            originalPosition = transform.position;
            SpawnBodyAfterAnimation();
        }
    }

    public override void Ataque(int Damage)
    {
        CurrentVida -= Damage;
    }

    private IEnumerator SpawnBodyAfterAnimation()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(bodyPrefab, originalPosition, Quaternion.identity);

        Destroy(gameObject);
    }
}
