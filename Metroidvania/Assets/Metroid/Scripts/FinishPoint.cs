using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player") && playerController.holdingCube)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
