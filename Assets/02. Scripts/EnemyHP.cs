using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{

    int hp;
    public int maxHP = 3;

    public Slider sliderHP;

    #region EnemyHP Property
    public int HP {
        get { return hp; }
        set { 
            hp = value; 
            sliderHP.value = hp;                    //update and change the slider value to the hp value
        }
    }
    #endregion EnemyHP Property

    // Start is called before the first frame update
    void Start()
    {
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }

}
