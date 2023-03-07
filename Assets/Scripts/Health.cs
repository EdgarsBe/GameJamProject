using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int NumOfHearts;

    public Image[] hearts;
    public Sprite Heart;
    public Sprite EmptyHeart;

    void Update()
    {
        if(health > NumOfHearts)
        {
            health = NumOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = Heart;
            }
            else 
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < NumOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
