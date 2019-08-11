using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    private bool isFocus;
    private bool hasInteracted;
    private Transform player;
    public Transform interactionTransform;


    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance<radius)
            {
                Interact();
                hasInteracted = true;
            }
            
        }
    }

    //just for the sake of objects heritages
    public virtual void Interact()
    {
        //Debug.Log("INTERAGIU");
    }


    void OnDrawGizmosSelected()
    {
        if (interactionTransform==null)
        {
            interactionTransform = GetComponent<Transform>();
        }
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
        
    }



}
