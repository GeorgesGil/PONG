using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    //velocidad
    public float velocidad= 30.0f;

    //eje vertical
    public string eje;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Es llamado una vez cada fixed frame
    void FixedUpdate ()
    {
        //capto el valor del eje vertical en la raqueta
        float v = Input.GetAxisRaw(eje);
        //modifico la velocidad de la raqueta
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * velocidad);
        
    }
}
