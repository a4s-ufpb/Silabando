using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for calling the pre-screen.
/// </summary>
public class Splash : MonoBehaviour
{
    public int waitTime;

    /// <summary>
    /// Starts the coroutine and waits for a predetermined time that is configured in the scene. 
    /// </summary>
    void Start()
    {
        StartCoroutine("Wait");
    }
    /// <summary>
    /// Wait any seconds before call the next scene.
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        yield return new WaitForSeconds (waitTime);
        SceneManager.LoadScene("Tela 1");
    }
}
