using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class goblinFight : MonoBehaviour
{
    [SerializeField]
    public Sprite []spriteList;
    public float tempoAnim=2f;
    float tempo;
    int index=0;
    public bool sideFlipped = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = spriteList[index];
        if (sideFlipped)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if (tempo> tempoAnim)
        {
            tempo = 0;
            if (index== spriteList.Length-1){
                index = 0;
            }
            else {
                index += 1;
            }
            GetComponent<Image>().sprite = spriteList[index];
           

        }
    }
}
