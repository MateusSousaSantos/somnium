using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CodeMonkey.Utils;



public class Player_Shooting : MonoBehaviour
{
    [SerializeField] player_movement playerMovement;
    public Animator aim_animator;
    public Transform aimTransform;
    public PlayerAim Player_Aim;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public GameObject Flash;
    [SerializeField]zumbi_estatisticas enemy;

    public bool cooldownInProgress = false;
    public bool canShoot;
    public bool canRun;

    public bool pressed;
    public int current_amo;
    public int max_amo = 6;



    private void Start()
    {
        pressed = false;

        canRun = true;

        canShoot = true;
        
        current_amo = max_amo;
        
        aim_animator = aimTransform.GetComponent<Animator>();
    }

    public float bullet_force;

    public IEnumerator Cooldown(float time)
    {
        if (!cooldownInProgress)
        {
            cooldownInProgress = true;
            
            canShoot = false;
            yield return new WaitForSeconds(time);
            canShoot = true;
            
            cooldownInProgress = false;
        }
    }
    public IEnumerator SlowDown(float time)
    {
        canRun = false;
        playerMovement.Pitch = 150f;
        playerMovement.Speed = 11f;
        yield return new WaitForSeconds(time);
        playerMovement.Speed = playerMovement.MaxSpeed;
        playerMovement.Pitch = 100f;
        canRun = true;
    }

    private void FixedUpdate()
    {
        walk();
        if(canRun != false)
        {
        playerMovement.SoundClue();
        }
        else
        {
            return;
        }
    }
    void walk()
    {
       if (Input.GetKey(KeyCode.LeftShift)){

           pressed = true;
           
        }
        else
        {
           pressed = false;
        }
        

        if (pressed == false && canRun != false)
        {
            playerMovement.Speed = playerMovement.MaxSpeed;
        }
        else if (pressed == true && canRun != false)
        {
            
            playerMovement.Speed = 8f;
        }
        else
        {
            return;
        }
    }
    void Update()
        { 

        if(playerMovement.Current_Control == true)

        {
            if (current_amo > 0)
            {
                if (Input.GetButtonDown("Fire1") && canShoot == true)
                {
                    current_amo--;

                    

                    StartCoroutine(SlowDown(0.6f));

                    StartCoroutine(Cooldown(0.6f));
                    
                    aim_animator.SetTrigger("shoot");
                    Shoot();
                    


                }


            }
             if(Input.GetKeyDown(KeyCode.R)) {

                StartCoroutine(Cooldown(1.5f));
                aim_animator.SetTrigger("reload");
                current_amo = max_amo;
             }
        }


    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bullet_force, ForceMode2D.Impulse);

    }

}
