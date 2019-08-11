using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
    // Start is called before the first frame update

    //public QuestType questObject;
    
    public Text myText;
    public GameObject tras;
    QuestType.Quest currQuest;

    public void AddItem(QuestType.Quest newQuest)
    {
        tras.SetActive(true);
        currQuest = newQuest;
        myText.text = newQuest.todo[0];
    }
    public void ClearSlot()
    {
        tras.SetActive(false);
        myText.text = "";
        
    }

    public void ClickQuest()
    {

        Debug.Log("quest clickada");
        QuestManager.instance.BigScreenQuest(currQuest);
        

    }



}
