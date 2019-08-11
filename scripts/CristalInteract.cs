using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalInteract : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        Debug.Log("INTERAGIU COM O OBJETO");
        base.Interact();
        GlobalConfigs.instance.ENEMY_LIFE_MODIFIER = 4;
        Destroy(gameObject);

    }
}
