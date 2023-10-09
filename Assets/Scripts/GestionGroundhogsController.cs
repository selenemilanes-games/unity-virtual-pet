using System.Collections;
using TMPro;
using UnityEngine;

public class GestionGroundhogsController : MonoBehaviour
{
    [SerializeField]
    private TamagotchiSO statsTamagotchi;
    [SerializeField]
    private GotchisGroundhogController gotchisConseguidos;
    private GameObject poolGroundhogs;
    private GameObject poolAngryGroundhogs;
    float speed;
    private int tiempoTranscurridoGame;
    public TextMeshProUGUI title;
    bool seMuestraTitulo;


    private void Awake()
    {
        poolGroundhogs = gameObject.transform.GetChild(0).gameObject;
        poolAngryGroundhogs = gameObject.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        speed = 4;
        tiempoTranscurridoGame = 0;
        seMuestraTitulo = true;
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        while (seMuestraTitulo)
        {
            yield return new WaitForSeconds(1);
            title.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            title.gameObject.SetActive(false);
            yield return new WaitForSeconds(2);
            StartCoroutine(gestionGroundhogs());
            StartCoroutine(gestionAngryGroundhogs());
            seMuestraTitulo = false;
        }
    }

    private IEnumerator gestionGroundhogs()
    {
        while (true)
        {
            tiempoTranscurridoGame++;

            if (tiempoTranscurridoGame % 10 == 0 && speed >= 1)
            {
                speed -= 0.5f;

                if (speed == 0.5f)
                {
                    StartCoroutine(hardcore());
                }
            }

            int random = Random.Range(0, 8);

            GameObject groundHog;

            for (int i = 0; i < poolGroundhogs.transform.childCount; i++)
            {
                if (i == random)
                {
                    if (!poolGroundhogs.transform.GetChild(i).gameObject.activeInHierarchy && !poolAngryGroundhogs.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        groundHog = poolGroundhogs.transform.GetChild(i).gameObject;
                        groundHog.SetActive(true);
                    }
                }
            }

            yield return new WaitForSeconds(Random.Range(0.5f, speed));
            poolGroundhogs.transform.GetChild(random).gameObject.SetActive(false);
        }
    }

    private IEnumerator gestionAngryGroundhogs()
    {
        while (true)
        {
            tiempoTranscurridoGame++;

            if (tiempoTranscurridoGame % 10 == 0 && speed >= 1)
            {
                speed -= 0.5f;

                if (speed == 0.5f)
                {
                    StartCoroutine(hardcore());
                }
            }
            int random = Random.Range(0, 8);

            GameObject angryGroundHog;

            for (int i = 0; i < poolAngryGroundhogs.transform.childCount; i++)
            {
                if (i == random)
                {
                    if (!poolGroundhogs.transform.GetChild(i).gameObject.activeInHierarchy && !poolAngryGroundhogs.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        angryGroundHog = poolAngryGroundhogs.transform.GetChild(i).gameObject;
                        angryGroundHog.SetActive(true);
                    }
                }
            }

            yield return new WaitForSeconds(Random.Range(0.5f, speed));
            poolAngryGroundhogs.transform.GetChild(random).gameObject.SetActive(false);
        }
    }

    private IEnumerator hardcore()
    {
        while (true)
        {
            int random = Random.Range(0, 8);

            GameObject angryGroundHog;

            for (int i = 0; i < poolAngryGroundhogs.transform.childCount; i++)
            {
                if (i == random)
                {
                    if (!poolGroundhogs.transform.GetChild(i).gameObject.activeInHierarchy && !poolAngryGroundhogs.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        angryGroundHog = poolAngryGroundhogs.transform.GetChild(i).gameObject;
                        angryGroundHog.SetActive(true);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            poolAngryGroundhogs.transform.GetChild(random).gameObject.SetActive(false);
        }
    }

    public void pararCorutinas()
    {
        StopAllCoroutines();
        gestionGameOver();
    }

    private void gestionGameOver()
    {
        statsTamagotchi.gotchis += gotchisConseguidos.monedasGroundhog;

        if (gotchisConseguidos.monedasGroundhog >= 50)
        {
            modificarFelicidad(3);
        }
        else if (gotchisConseguidos.monedasGroundhog >= 20 && gotchisConseguidos.monedasGroundhog < 50)
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
