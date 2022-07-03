using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    //velocidad
    public float velocidad = 30.0f;

    //audio source
    AudioSource fuenteDeAudio;

    //clips de audio
    public AudioClip audioGol, audioRaqueta, audioRebote, audioStart, audioVictoria;

    //contadores de goles
    public int golesIzquierda = 0;
    public int golesDerecha = 0;

    //variable para incrementar la velocidad de la bola cuando se anote un gol
    public bool velocidadEstado = false;

    //cajas de texto de los contadores
    public Text ContadorIzquierda;
    public Text ContadorDerecha;
    public Text TextoGanador;



    // Start is called before the first frame update
    void Start()
    {
        //velocidad inicial a la derecha
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

        //recupero el componente audio source
        fuenteDeAudio = GetComponent<AudioSource>();

        //pongo los contadores a 0
        ContadorIzquierda.text = golesIzquierda.ToString();
        ContadorDerecha.text = golesDerecha.ToString();
        fuenteDeAudio.clip = audioStart;
        fuenteDeAudio.Play();

    }

    //se ejecuta al colisionar
    void OnCollisionEnter2D(Collision2D micolision)
    {
        //Col Contiene toda la informacion de la colision
        //Si la bola colisiona con la raqueta
        //  micolision.gameObject es la raqueta
        //  micolision.transform.position es la posicion de la raqueta

        //si choca con la raqueta izquierda
        if (micolision.gameObject.name == "RaquetaIzquierda")
        {
            //valor de x
            int x = 1;

            //valor de y
            int y = direccionY(transform.position, micolision.transform.position);

            //calculo direccion
            Vector2 direccion = new Vector2(x, y);

            //aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            //aplico la velocidad a la bola
            //GetComponent<Rigidbody2D>().velocity = direccion * velocidad;



            //reproduzco el audio de la raqueta
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }

        //si choca con la raqueta derecha
        if (micolision.gameObject.name == "RaquetaDerecha")
        {
            //valor de x
            int x = -1;

            //valor de y
            int y = direccionY(transform.position, micolision.transform.position);

            //Calculo direccion (normalizada para que de 1 o -1)
            Vector2 direccion = new Vector2(x, y);

            //aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            //reproduzco el sonido de la raqueta
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }

        //para el sonido del rebote
        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo")
        {
            //reproduzco el sonido del rebote
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }
    }

    //direccion y
    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
    {
        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }else if (posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }else{
            return 0;
        }
    }

    public void reiniciarBola(string direccion)
    {
        //posicion 0 de la bola
        transform.position = Vector2.zero;

        //Vector2.zero es lo mismo que new Vector2(0,0);

        //Velocidad inicial de la bola
        //velocidad = 30;
        velocidadEstado = false;
        //Velocidad y direccion
        if (direccion == "Derecha")
        {
            velocidadEstado = true;
            //incremento goles al de la derecha
            golesDerecha++;
            //lo escribo en el marcador
            ContadorDerecha.text = golesDerecha.ToString();
            //reinicio la bola
            if(golesDerecha == 5)
            {
                TextoGanador.text = "Derecha WINS!!!";
                fuenteDeAudio.clip = audioVictoria;
                fuenteDeAudio.Play();
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 0;
                
            }else{
                fuenteDeAudio.clip = audioGol;
                fuenteDeAudio.Play();
                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
            }
            //Vector2.right es lo mismo que new Vector2(1,0)
        }else if (direccion == "Izquierda"){

            velocidadEstado = true;
            //incremento goles al de la izquierda
            golesIzquierda++;
            //lo escribo en el marcador
            ContadorIzquierda.text = golesIzquierda.ToString();
            //reinicio la bola
            if(golesIzquierda == 5)
            {
                fuenteDeAudio.clip = audioVictoria;
                fuenteDeAudio.Play();
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 0;
                TextoGanador.text = "Izquierda WINS!!!";
                
            }else{
                fuenteDeAudio.clip = audioGol;
                fuenteDeAudio.Play();

                GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
            }
            //Vector2.right es lo mismo que new Vector2(-1,0)
        }

        //reproduzco el sonido del gol
        
    }

    // Update is called once per frame
    void Update()
    {
        if(velocidadEstado == true){
            //incremento la velocidad de la bola 
            velocidad = velocidad + 0.01f;
        }
    }
}
