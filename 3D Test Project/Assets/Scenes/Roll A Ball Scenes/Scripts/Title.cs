using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadMain()
    {
        SceneManager.LoadScene(3);
    }
    public void title()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void levelTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void levelThree()
    {
        SceneManager.LoadScene(3);
    }
}
