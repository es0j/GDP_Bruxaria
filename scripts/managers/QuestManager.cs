using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update

    //i guess the statement 'new' means to initialize the constructure of list ?? like c++?

    //just to leave code beauty
    #region Singleton

    //same stuff that python POO self.this self.that.Not scared at all.
    public static QuestManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory");
            return;
        }
        instance = this;
    }

    #endregion
    public List<QuestType.Quest> QuestList = new List<QuestType.Quest>();

    public GameObject detailPannel;
    Text detailText;

    //subscrive and publish system aparantely
    public delegate void OnQuestChanged();
    public OnQuestChanged onQuestChangedCallback;
    public GameObject questUI;
    //public QuestType.Quest teste;
    

    QuestUI questUIScript;

    




    public void Start()
    {
        questUIScript = questUI.GetComponent<QuestUI>();
        detailText = detailPannel.GetComponentInChildren<Text>();
        // Add(teste);
    }

    public bool Add(QuestType.Quest newQuest)
    {

        if (!QuestList.Contains(newQuest))
        {
            QuestList.Add(newQuest);
            
            //if has subscriptions
            if (onQuestChangedCallback != null)
            {
                onQuestChangedCallback.Invoke();
            }
            //Debug.Log(onItemChangedCallback.ToString());
            return true;
        }
    
        return false;
    }

    public void Remove(QuestType.Quest newQuest)
    {
        QuestList.Remove(newQuest);
        if (onQuestChangedCallback != null)
        {
            onQuestChangedCallback.Invoke();
        }
    }

    public void BigScreenQuest(QuestType.Quest quest)
    {
        questUI.SetActive(false);
        string formatText ="" ;
        detailPannel.SetActive(true);
        for (int i=0;i<quest.todo.Capacity;i++)
        {
            formatText += quest.todo[i] + "        " + "Status: ";
            if (quest.todoStats[i])
            {
                formatText += " Concluido!";
            }
            else
            {
                formatText += " Não Concluido!";
            }
            formatText += "\n";
        }
        detailText.text = formatText;

    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            detailPannel.SetActive(false);
            questUI.SetActive(!questUI.activeSelf);
            Inventory.instance.inventoryUI.SetActive(false);
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            detailPannel.SetActive(false);
            questUI.SetActive(false);
            Inventory.instance.inventoryUI.SetActive(false);

        }
    }



    


}
