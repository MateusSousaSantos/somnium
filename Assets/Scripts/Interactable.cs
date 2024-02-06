using UnityEngine;


[RequireComponent (typeof(CircleCollider2D))]
public abstract class Interactable : MonoBehaviour
{

    private void Reset()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    public abstract void Interact();

}
