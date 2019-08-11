using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    // Start is called before the first frame update
    public int daySpeed=1;
    //meia hora por padra0o

    Vector3 rotacao = new Vector3(1,0,0);

    public void Update()
    {
        transform.Rotate(rotacao, .1f*Time.deltaTime *daySpeed);
    }

}
