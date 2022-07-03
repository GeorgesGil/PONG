using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // si pulsa la letra P o hace click izquierdo empieza el juego
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0)){
            //cargo la escena del juego
            //nombre de la escena del juego
            SceneManager.LoadScene("Juego");
        }
        if (Input.GetKeyDown(KeyCode.O) ){
            //cargo la escena del juego
            //nombre de la escena del juego
            SceneManager.LoadScene("Final");
        }

        
    }
}
