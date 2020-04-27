using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Text text;
    Image bar;
    public Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        bar = GetComponentInChildren<Image>();
    }

    void Update()
    {        
        float fill = playerHealth._hp / playerHealth._maxHp;
        string colour = (fill > .6f) ? "lime" : (fill > .3f) ? "yellow" : "red";
        text.text = $"<color={colour}>{playerHealth._hp}/{playerHealth._maxHp}</color>";
        bar.fillAmount = fill;
    }
}