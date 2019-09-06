using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    private bool isFocus;
    private bool hasInteracted;
    private Transform player;
    public Transform interactionTransform;
    bool hasRange = false;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
        if (interactionTransform==null)
        {
            interactionTransform = transform;
        }
    }

    void Update()
    {
        
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        //Debug.Log(distance.ToString());
        if (distance < radius)
        {
            hasRange = true;
            
        }
        else { hasRange = false; }


        if (isFocus && !hasInteracted)
        {
            if (hasRange)
            {
                Interact();
                hasInteracted = true;
            }   
        }
        if (hasRange)
        {
            HasRange();
        }
        else
        {
            HasNOTRange();
        }
        
    }
    public virtual void HasRange()
    {
        //Debug.Log("Has Range");
    }
    public virtual void HasNOTRange()
    {
        //Debug.Log("Has Range");
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
