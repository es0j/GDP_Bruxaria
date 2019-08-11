using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{
    //'couse we dont want to click on otherstufs that not gorund
    public LayerMask movementMask;
    public Interactable focus;


    playerMotor motor;
    // Start is called before the first frame update
    //no need to be public, linking on start call.
    Camera camera;

    void Start()
    {
        //main camera avaiable in the  scene
        camera = Camera.main;
        motor = GetComponent<playerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //if we are not clicking over an UI, we continue
        
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //ray casting to detect where we clicked
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if an hit happens..
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Debug.Log(hit.point);
                motor.MoveTo(hit.point);
            }
            RemoveFocus();
        }
        if (Input.GetMouseButtonDown(1))
        {
            //ray casting to detect where we clicked
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if an hit happens
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //if its an interactable. focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(focus!=newFocus)
        {
            if (focus!=null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
            motor.follow(focus);
        }
        focus.OnFocused(transform);

    }
    void RemoveFocus()
    {
        if (focus!=null)
        {
            focus.OnDefocused();
        }
        focus = null;
        motor.leave();
    }


}
