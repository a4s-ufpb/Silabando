using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public int waitTime;

    void Start()
    {
        StartCoroutine("Wait");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds (waitTime);
        SceneManager.LoadScene("Tela 1");
    }
}
