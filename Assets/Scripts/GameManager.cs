using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int enemyDefeated = 0;

    public Image healthBar;
    public GameObject healthBarUI;
    public GameObject winUI;
    public GameObject loseUI;

    public void Win()
    { 
        winUI.SetActive(true);
    }

    public void Lose()
    {
        healthBarUI.SetActive(false);
        loseUI.SetActive(true);
    }
}
