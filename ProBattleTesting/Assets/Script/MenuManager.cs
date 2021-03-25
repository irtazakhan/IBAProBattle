using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play()
    {
       
        Camera.main.GetComponent<Animator>().SetTrigger("Play");
        Door.GetComponent<Animator>().SetTrigger("Open");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
