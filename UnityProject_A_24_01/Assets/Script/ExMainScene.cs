using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExMainScene : MonoBehaviour
{
    public void GoToShootGame()
    {
        SceneManager.LoadScene("GameScene_Gun");
    }

    public void GoToJumpGame()
    {
        SceneManager.LoadScene("GameScene_Jump");
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
