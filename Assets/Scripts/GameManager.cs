﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    float health = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(health > .01f)
        {
            health = health - 0.01f;
            healthBar.SetSize(health);
        }
    }
}