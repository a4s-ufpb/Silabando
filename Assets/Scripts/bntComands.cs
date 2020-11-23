using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bntComands : MonoBehaviour
{
   public void loadScene (string sceneName) 
   {
       SceneManager.LoadScene(sceneName);
   }

   public void closeGame ( ) 
   {
       Application.Quit();
   }

   public void jogarNovamente()
   {
       int idScene = PlayerPrefs.GetInt("idTema");

        if(idScene != 0)
        {
            SceneManager.LoadScene(idScene.ToString());
        }
   }
}
