using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class bntComands : MonoBehaviour
{   
    public GameObject painel1, painel2;
    
    private soundController soundController;


    void Start()
    {
      
        soundController = FindObjectOfType(typeof(soundController)) as soundController;
        
        
    }
    public void loadScene (string sceneName) 
    {
      
        soundController.playbutton();
        SceneManager.LoadScene(sceneName);

    }

    public void jogarNovamente()
    {
        soundController.playbutton();
        int idScene = PlayerPrefs.GetInt("idTema");

            if(idScene != 0)
            {
                SceneManager.LoadScene(idScene.ToString());
            }
    }
    public void configuracoes(bool onOff)
    {   soundController.playbutton();
        painel1.SetActive(!onOff);
        painel2.SetActive(onOff);
    }

    public void limparProgresso()
    {
        soundController.playbutton();
        PlayerPrefs.DeleteAll();

    }

   
    


}
