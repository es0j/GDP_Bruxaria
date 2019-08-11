using UnityEngine;
using UnityEngine.UI;

public class DialogueSlot : MonoBehaviour
{
    // Start is called before the first frame update



    public void OnSelectButton()
    {
        
        string texto = gameObject.GetComponentInChildren<Text>().text;
        DialogueManager.instance.OnSelectButton(texto);
    }

}
