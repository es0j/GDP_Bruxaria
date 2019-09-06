using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButton : MonoBehaviour
{
    public string nameButton;
    public int nameButtonFunct;
    // Start is called before the first frame update
    public Button button;
    public globalOpt master;
    void Start()
    {
        button = GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = nameButton;
    }

    // Update is called once per frame
    public void OnClick()
    {
        master.setOptFriend(nameButtonFunct);
        Debug.Log("setando botao " + nameButtonFunct.ToString());
    }
    
}
