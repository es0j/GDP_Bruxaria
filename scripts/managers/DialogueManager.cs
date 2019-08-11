using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialoguePanel;
    
    private Button[] currentButtons;
    private Text talk;

    private NPC_Talk currentNPC_Talk;
    private NPC currentNPC;
    private int grafoIndice;
    #region Singleton

    //same stuff that python POO self.this self.that.Not scared at all.
    public static DialogueManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance on DialogueManager");
            return;
        }
        instance = this;
    }

    #endregion

    void Start()
    {
        talk = DialoguePanel.GetComponentInChildren<Text>();
        currentButtons = DialoguePanel.transform.GetChild(1).GetComponentsInChildren<Button>();
        DialoguePanel.SetActive(false);

    }
    public void SetStart(NPC npc, int index = 0)
    {
        DialoguePanel.SetActive(true);
        grafoIndice = index;
        currentNPC_Talk = npc.talk;
        currentNPC = npc;
        SetText();
    }
    public void SetText()
    {
       
        talk.text = currentNPC_Talk.grafo[grafoIndice].fala;
        SetButtons(currentNPC_Talk.grafo[grafoIndice].respostas, currentNPC_Talk.grafo[grafoIndice].proximos);
    }
    public void SetButtons(string []responses,int []indexes)
    {
        int index = 0;
        foreach (Button button in currentButtons)
        {
            if (index < responses.Length)
            {
                button.GetComponentInChildren<Text>().text = responses[index];
                button.gameObject.SetActive(true);
            }
            else
            {
                button.gameObject.SetActive(false);
            }

            index++;
        }
    }
    public void OnSelectButton(string texto)
    {
        //not optimal fix later
        int index = 0;
        foreach(string possibleResp in currentNPC_Talk.grafo[grafoIndice].respostas)
        {
            if (possibleResp==texto)
            {
                
                grafoIndice = currentNPC_Talk.grafo[grafoIndice].proximos[index];
                currentNPC.GetComponent<NPC>().NpcCallBack(grafoIndice);
                break;
            }
            index++;
        }
        if (grafoIndice!=-1)
        {
            SetText();
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
    }
   
}
