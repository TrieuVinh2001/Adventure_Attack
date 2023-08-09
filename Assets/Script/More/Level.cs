using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public string lvlToLoad;//Tên scene
    // Start is called before the first frame update
    public void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

}
