using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu ("My Cpmponents/Teleport")]
public class Portal : MonoBehaviour
{
    [Header ("Scene Index")]
    public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
