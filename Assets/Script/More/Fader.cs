using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{//Của Fader
    private Animator anim;
    public string lvlToLoad;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        GameManager.RegisterFader(this);
    }

    public void SetLevel(string lvl)
    {
        lvlToLoad = lvl;
        anim.SetTrigger("Fade");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

    private void Restart()
    {
        SetLevel(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        Invoke("Restart", 1f);//Thời gain chờ để thực hiện hàm Restrart
    }

    public void Exit()
    {
        Application.Quit();
    }
}
