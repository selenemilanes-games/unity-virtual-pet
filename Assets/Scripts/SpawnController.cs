using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnController : MonoBehaviour
{
    private float speed;
    [SerializeField]
    private GameObject m_fruta;
    [SerializeField]
    private GotchisMinigameController gotchisConseguidos;
    [SerializeField]
    private TamagotchiSO statsTamagotchi;
    private int tiempoTranscurridoGame;
    public TextMeshProUGUI title;
    bool seMuestraTitulo;

    private void Start()
    {
        speed = 2;
        tiempoTranscurridoGame = 0;
        seMuestraTitulo = true;
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        while(seMuestraTitulo)
        {
            yield return new WaitForSeconds(1);
            title.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            title.gameObject.SetActive(false);
            yield return new WaitForSeconds(2);
            StartCoroutine(crearFruta());
            seMuestraTitulo = false;
        }
    }

    private IEnumerator crearFruta()
    {
        while (true)
        {
            tiempoTranscurridoGame++;

            if (tiempoTranscurridoGame % 10 == 0 && speed >= 1)
            {
                speed -= 0.5f;
            }

            GameObject nuevaFruta = Instantiate(m_fruta);

            float posicionIzquierda = -6.78f;
            float posicionPlataformaIzq = -3.99f;
            float posicionPlataformaDer = -2.6f;
            float posicionCentro = 0.67f;
            float posicionDerecha = 5.34f;

            int randomPosicion = Random.Range(0, 5);

            switch (randomPosicion)
            {
                case 0:
                    posicionarFruta(nuevaFruta, posicionIzquierda);
                    break;
                case 1:
                    posicionarFruta(nuevaFruta, posicionCentro);
                    break;
                case 2:
                    posicionarFruta(nuevaFruta, posicionDerecha);
                    break;
                case 3:
                    posicionarFruta(nuevaFruta, posicionPlataformaIzq);
                    break;
                case 4:
                    posicionarFruta(nuevaFruta, posicionPlataformaDer);
                    break;
            }

            yield return new WaitForSeconds(speed);
        }
    }

    private void posicionarFruta(GameObject nuevaFruta, float posicion)
    {
        nuevaFruta.transform.position = new Vector2(posicion, this.gameObject.transform.position.y);
    } 

    public void pararCorutinas()
    {
        StopAllCoroutines();
        gestionGameOver();
    }

    private void gestionGameOver()
    {
        statsTamagotchi.gotchis += gotchisConseguidos.monedas;

        if (gotchisConseguidos.monedas >= 50)
        {
            modificarFelicidad(3);
        }
        else if (gotchisConseguidos.monedas >= 20 && gotchisConseguidos.monedas < 50)
        {
            modificarFelicidad(2);
        }
        else
        {
            modificarFelicidad(1);
        }
    }

    private void modificarFelicidad(int valor)
    {
        statsTamagotchi.felicidad += valor;

        if (statsTamagotchi.felicidad > statsTamagotchi.maxFelicidad)
        {
            statsTamagotchi.felicidad = statsTamagotchi.maxFelicidad;
        }
    }

}
