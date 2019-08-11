using UnityEngine;

public class NPC : Interactable
{

    public NPC_Talk talk;
    //override is used to override virtual functions
    public override void Interact()
    {

        base.Interact();
        DialogueStart();
    }
    public virtual void DialogueStart()
    {
        Debug.Log("fazendo dialogo");
        DialogueManager.instance.SetStart(this);
    }

    public virtual void NpcCallBack(int grafoIndice)
    {
        Debug.Log("ok, fim do chat "+ grafoIndice.ToString());
    }

}
