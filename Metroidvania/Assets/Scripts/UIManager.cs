using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private string firstLevel = "0";

    public void PlayButton()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
