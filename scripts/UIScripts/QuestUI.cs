using UnityEngine;

public class QuestUI : MonoBehaviour
{

    public Transform itemsParent;
    QuestManager quest;
    QuestSlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        quest = QuestManager.instance;
        //Debug.Log(inventory);
        quest.onQuestChangedCallback += UpdateQuestUI;
        slots = itemsParent.GetComponentsInChildren<QuestSlot>();
        gameObject.SetActive(false);
        UpdateQuestUI();

    }


    public void UpdateQuestUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < quest.QuestList.Count)
            {
                slots[i].AddItem(quest.QuestList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
