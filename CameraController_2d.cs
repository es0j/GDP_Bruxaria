using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_2d: MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerManager.instance.player.transform;
        transform.position = target.position + offset;
        transform.LookAt(target);

    }
}
