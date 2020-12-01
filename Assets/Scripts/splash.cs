using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour
{
    public int tempoEspera;

    void Start()
    {
        StartCoroutine("esperar");
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds (tempoEspera);
        SceneManager.LoadScene("Tela 1");
    }
}
