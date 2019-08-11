using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playGame : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<Text>().text = "Jogar.";
    }
    // Start is called before the first frame update
    public void PlayGameFinally()
    {
        SceneManager.LoadScene("map02", LoadSceneMode.Single);
    }


}
