using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public float maxLife;
    public float actualLife;
    public int intLife;
    public GameObject LifeBar;
    public GameObject LifeText;

    void Start()
    {
        LifeBar.GetComponent<Slider>().maxValue = maxLife;
        LifeBar.GetComponent<Slider>().value = maxLife;
        actualLife = maxLife;
    }

    void Update()
    {
        LifeBar.GetComponent<Slider>().value = actualLife;
        intLife = Mathf.RoundToInt(actualLife);
        LifeText.GetComponent<TMPro.TextMeshProUGUI>().text = intLife.ToString();

        if(actualLife <= 0){
            LifeText.GetComponent<TMPro.TextMeshProUGUI>().text = "0";
            this.GetComponent<GameStates>().GameOver();
        }
    }
}
