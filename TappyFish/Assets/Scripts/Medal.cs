using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Medal : MonoBehaviour
{

    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;

    private Image img;
    
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       
        int gameSCore = GameManager.gameScore;

        if (gameSCore > 0 && gameSCore <= 3)
        {
            img.sprite = metalMedal;
        }
       else if (gameSCore > 3 && gameSCore <= 7)
        {
            img.sprite = bronzeMedal;
        }
        else if (gameSCore > 7 && gameSCore <= 15)
        {
            img.sprite = silverMedal;
        }
        else 
        {
            img.sprite = goldMedal;
        }
    }
}
