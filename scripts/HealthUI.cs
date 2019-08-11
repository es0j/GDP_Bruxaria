using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{

    public GameObject uiPrefab;
    public Transform target;
    public Canvas c;

    Transform ui;
    Image healthSlider;
    Transform cam;
    

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main.transform;
        if (c.renderMode ==RenderMode.WorldSpace)
        {
            ui = Instantiate(uiPrefab, c.transform).transform;
            healthSlider = ui.GetChild(0).GetComponent<Image>();
        }
        else
        {
            Debug.LogError("Invalid canvas type");
        }
        
        
    }

    void OnHealthChanged(int maxHealth,int currHealth)
    {
        if (ui!=null)
        {
            healthSlider.gameObject.SetActive(true);
            float healthPercent = currHealth / (float)maxHealth;
            healthSlider.fillAmount = healthPercent;
            if (currHealth <= 0)
            {
                Destroy(ui.gameObject);
            }
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ui!=null)
        {
            ui.position = target.position;
            ui.forward = -cam.forward;
        }


    }
}
