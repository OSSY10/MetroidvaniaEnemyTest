using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    Monster[] monsters;
    // Start is called before the first frame update
    void OnEnable()
    {
        monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AllMonstersDie())
        {
            LoadNextLevel();
        }
        
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    bool AllMonstersDie()
    {
        foreach(var monster in monsters)
        {
            if(monster.gameObject.activeSelf)
            {
                return false;
            }
            
        }
        return true;

    }
}
