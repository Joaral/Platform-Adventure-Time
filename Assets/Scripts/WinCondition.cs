using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public string tagCollision = "Player";
    public string sceneName = "MainMenu";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == tagCollision)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
