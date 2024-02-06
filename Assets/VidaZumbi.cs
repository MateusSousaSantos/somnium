using System.Collections;
using UnityEngine;

public class VidaZumbi : TakeDamage
{
    public int MaxVida = 120;
    public int CurrentVida;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bodyPrefab;

    private SpriteRenderer spriteRenderer;
    public float blinkDuration = 1;
    private Color originalColor;

    private Vector3 originalPosition;

    public bool isDead = false;
    public bool cooldownInProgress = false;

    public override void ReceiveDamage(int Damage)
    {
        CurrentVida -= Damage;
        StartCoroutine(BlinkWhite());
    }

    private void Update()
    {
        Died();
    }

    public void Died()
    {
        if (CurrentVida <= 0 && !cooldownInProgress)
        {
            isDead = true;

            cooldownInProgress = true;

            originalPosition = transform.position;

            animator.SetTrigger("dead");

            StartCoroutine(SpawnBodyAfterAnimation());
        }
    }

    private IEnumerator SpawnBodyAfterAnimation()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(bodyPrefab, originalPosition, Quaternion.identity);

        Destroy(gameObject);
    }

    private IEnumerator BlinkWhite()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(blinkDuration);

        spriteRenderer.color = originalColor;
    }

    private void Start()
    {
        CurrentVida = MaxVida;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
}
