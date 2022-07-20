using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    [SerializeField] private string[] _sceneNames;

    protected override void OnCollide(Collider2D collider2D)
    {
        if (collider2D.name == "Player")
        {
            GameManager.Instance.SaveState();
            string sceneName = _sceneNames[Random.Range(0, _sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
