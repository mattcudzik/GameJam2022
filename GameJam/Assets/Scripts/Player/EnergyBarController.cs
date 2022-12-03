using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float hp;
    public GameObject hpController;
    void Start()
    {
        hpController = GameObject.FindGameObjectWithTag("HP");
        hp = hpController.GetComponent<playersHp>().hp;
        slider.maxValue = hp;
        slider.value = hp;
        fill.color = gradient.Evaluate(1f);

        var players= GameObject.FindGameObjectsWithTag("Player");
        for (int i =0; i< players.Length; i++)
        {
            players[i].GetComponent<PlayerEventHandler>().OnPowerDownEvent.AddListener(BarDown);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BarDown()
    {
       
        slider.value = hpController.GetComponent<playersHp>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
