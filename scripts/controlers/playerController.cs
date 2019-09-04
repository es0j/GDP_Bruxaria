using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class playerController : MonoBehaviour
{
    //'couse we dont want to click on otherstufs that not gorund

    public Interactable focus;
    bool interactable = false;

 
    // Update is called once per frame
    void Update()
    {
        //if we are not clicking over an UI, we continue
        if (Input.GetKey(KeyCode.R ))
        {
            if (interactable)
            {
                focus.Interact();
                interactable = false;
            }
        }        
    }
/*
    void SetFocus(Interactable newFocus)
    {
        Debug.Log(" focado com com  " + newFocus.name);
        if (focus!=newFocus)
        {
            if (focus!=null)
            {
                focus.OnFocused(transform);
                //focus.OnDefocused();
            }
            
            focus = newFocus;
            
        }
        
        //RemoveFocus();
        //interactable = false;
    }
    void RemoveFocus()
    {
        if (focus!=null)
        {
            //focus.OnDefocused();
        }
        focus = null;
        
    }
    */
    public void ShowPopUp(Interactable objeto,Item item)
    {
        //Debug.Log(" interagivel com  "+ item.name);
        interactable = true;
        focus = objeto;

    }
    public void HidePopUp()
    {
        //Debug.Log(" interagivel com  "+ item.name);
        interactable = false;
        focus = null;

    }

}
