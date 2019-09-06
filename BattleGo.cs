using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGo : MonoBehaviour
{

    public globalOpt master;
   
    // Update is called once per frame
    public void OnClick()
    {
        master.go();
    }
}
