using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TamagotchiController : MonoBehaviour
{

    [SerializeField]
    private TamagotchiSO statsTamagotchi;
    [SerializeField]
    private ParticleSystem m_dustParticle;
    private GameObject m_tamagotchi;
    [SerializeField]
    private GameObject m_pooldePoops;

    private AudioSource[] m_audios;
    private Animator m_animator;

    //GESTION DEL HATCHING
    private bool izq = false;
    private bool der = false;

    [Header("Gestión de tiempos")]
    [SerializeField]
    private float m_tiempoHatching; //Tiempo que tarda en hatchear
    [SerializeField]
    private float m_tiempoPoop; //Tiempo que tarda en cagar
    [SerializeField]
    private float m_tiempoHambre; //Tiempo que tarda en quitarse uno de hambre
    [SerializeField]
    private float m_tiempoFelicidad; //Tiempo que tarda en quitarse uno de felicidad
    [SerializeField]
    private float m_tiempoMuerte; //Tiempo que tarda en morir
    [SerializeField]
    private float m_tiempoSuciedad; //Tiempo que tarda ensuciarse

    [Header("Game events")]
    public GameEvent bajarHambre;
    public GameEvent bajarFelicidad;

    void Awake()
    {
        m_tamagotchi = this.gameObject;
        m_animator = GetComponent<Animator>();
        m_audios = GetComponents<AudioSource>();

        if (!statsTamagotchi.haHatcheado)
        {
            if (statsTamagotchi.colorHuevo == "BlueEgg")
            {
                m_animator.runtimeAnimatorController = statsTamagotchi.m_animators[0];
                statsTamagotchi.animatorActual = m_animator.runtimeAnimatorController;
                m_tamagotchi.transform.position = new Vector2(0, -2.24f);
            }
            else if (statsTamagotchi.colorHuevo == "GreenEgg")
            {
                m_animator.runtimeAnimatorController = statsTamagotchi.m_animators[1];
                statsTamagotchi.animatorActual = m_animator.runtimeAnimatorController;
                m_tamagotchi.transform.position = new Vector2(0, -2.24f);
            }
            else if (statsTamagotchi.colorHuevo == "OrangeEgg")
            {
                m_animator.runtimeAnimatorController = statsTamagotchi.m_animators[2];
                statsTamagotchi.animatorActual = m_animator.runtimeAnimatorController;
                m_tamagotchi.transform.position = new Vector2(0, -2.24f);
            }
            m_animator.SetBool("estaHatcheando", false);
            statsTamagotchi.estaSucio = false;
        }
        else
        {
            m_animator.runtimeAnimatorController = statsTamagotchi.animatorActual;
            m_tamagotchi.transform.position = new Vector2(0, -2.24f);
        }
    }

    private void Start()
    {
        if (!statsTamagotchi.haHatcheado)
        {
            StartCoroutine(procesoHatching());
        }
        else
        {
            IniciarCorutinas();
            StartCoroutine(gestionTiempo());
        }

    }

    void Update()
    {

        if (m_dustParticle.isPlaying)
        {
            m_dustParticle.transform.position = m_tamagotchi.transform.position; 
        }
    }

    private void IniciarCorutinas()
    {
        StartCoroutine(cooldownHambre());
        StartCoroutine(cooldownFelicidad());
        StartCoroutine(Cagar());
        StartCoroutine(seEnsucia());
        comprobarSiEstaSucio();
    }

    private IEnumerator procesoHatching()
    {
        while (m_tiempoHatching != 0)
        {
            yield return new WaitForSeconds(1);
            m_audios[2].Play(); //Sfx Tiktok
            m_tiempoHatching -= 1;

            if (izq == false)
            {
                m_tamagotchi.transform.eulerAngles = new Vector3(0, 0, 20);
                izq = true;
                der = false;

            }
            else if (der == false)
            {
                m_tamagotchi.transform.eulerAngles = new Vector3(0, 0, -20);
                der = true;
                izq = false;
            }

            if (m_tiempoHatching == 0) //Lo devolvemos a la posicion original cuando acaba el tiempo
            {
                m_tamagotchi.transform.eulerAngles = new Vector3(m_tamagotchi.transform.eulerAngles.x, m_tamagotchi.transform.eulerAngles.y, 0);
                m_animator.SetBool("estaHatcheando", true);
            }
        }
        statsTamagotchi.haHatcheado = true;
        m_audios[2].Stop();

    }

    public void sonidoHatchear()
    {
        m_audios[0].Play(); //Sfx EggCracking
    }

    public void huevoAbierto()
    {
        m_animator.SetBool("estaHatcheando", false);

        int randomNumber = UnityEngine.Random.Range(0, 2);
        if (randomNumber == 0)
        {
            m_audios[1].Play(); //Sfx Magic
            m_animator.runtimeAnimatorController = statsTamagotchi.m_animators[3]; //Aparece baby girl
            statsTamagotchi.animatorActual = m_animator.runtimeAnimatorController;
        }
        else
        {
            m_audios[1].Play(); //Sfx magic
            m_animator.runtimeAnimatorController = statsTamagotchi.m_animators[4]; //Aparece baby boy
            statsTamagotchi.animatorActual = m_animator.runtimeAnimatorController;
        }

        m_tamagotchi.transform.position = new Vector2(0, -2.24f);
        m_animator.SetBool("hambriento", false);
        m_animator.SetBool("poop", false);
        statsTamagotchi.haHatcheado = true;

        StartCoroutine(gestionTiempo());
        IniciarCorutinas();
    }

    private IEnumerator gestionTiempo()
    {
        statsTamagotchi.comienzaTiempo = true;

        while (true)
        {
            //print("Tiempo transcurrido" + statsTamagotchi.tiempoTranscurrido);

            statsTamagotchi.tiempoTranscurrido = statsTamagotchi.tiempoTranscurrido.Add(new TimeSpan(0, 0, 1));

            yield return new WaitForSeconds(1);
        }

    }

    private IEnumerator Cagar()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_tiempoPoop);
            for (int i = 0; i < m_pooldePoops.transform.childCount; i++)
            {
                GameObject caca = m_pooldePoops.transform.GetChild(i).gameObject;
                if (!caca.activeInHierarchy)
                {
                    caca.SetActive(true);
                    m_animator.SetBool("poop", true);
                    break;
                }
            }
        }
    }

    public void limpiarPoops()
    {
        for (int i = 0; i < m_pooldePoops.transform.childCount; i++)
        {
            GameObject caca = m_pooldePoops.transform.GetChild(i).gameObject;
            if (caca.activeInHierarchy)
            {
                caca.SetActive(false);
            }
        }
        m_animator.SetBool("poop", false);
    }

    private IEnumerator cooldownHambre()
    {
        while (true && statsTamagotchi.haHatcheado)
        {
            yield return new WaitForSeconds(m_tiempoHambre);
            
            if (statsTamagotchi.hambre > 0)
            {
                modificarHambre(-1);
            }
            else if (statsTamagotchi.hambre == 0 && !statsTamagotchi.comienzaTiempoMuerte)
            {
                comienzaMuerte();
            }
        }
    }

    private void modificarHambre(int valor)
    {
        statsTamagotchi.hambre += valor;

        if (statsTamagotchi.hambre > 0 && statsTamagotchi.felicidad > 0)
            m_animator.SetBool("hambriento", false);
        else
            m_animator.SetBool("hambriento", true);

        bajarHambre.Raise();
    }

    private IEnumerator cooldownFelicidad()
    {
        while (true && statsTamagotchi.haHatcheado)
        {
            yield return new WaitForSeconds(m_tiempoFelicidad);
            
            if (statsTamagotchi.felicidad > 0)
            {
                modificarFelicidad(-1);
            }
            else if (statsTamagotchi.felicidad == 0 && !statsTamagotchi.comienzaTiempoMuerte)
            {
                comienzaMuerte();
            }
        }
    }

    private void modificarFelicidad(int valor)
    {
        statsTamagotchi.felicidad += valor;

        if (statsTamagotchi.felicidad > statsTamagotchi.maxFelicidad)
        {
            statsTamagotchi.felicidad = statsTamagotchi.maxFelicidad;
        }

        if (statsTamagotchi.felicidad > 0 && statsTamagotchi.hambre > 0)
            m_animator.SetBool("hambriento", false); //Utilizo la misma animacion de hambriento como la de felicidad
        else
            m_animator.SetBool("hambriento", true);

        bajarFelicidad.Raise();
    }

    private void comienzaMuerte()
    {
        //print("COMIENZA MUERTE");
        statsTamagotchi.tiempoTranscurridoMuerte = new TimeSpan(0, 0, 0);
        statsTamagotchi.comienzaTiempoMuerte = true;
        StartCoroutine(cooldownMuerte());
    }

    private IEnumerator cooldownMuerte()
    {
        while (statsTamagotchi.comienzaTiempoMuerte)
        {
            statsTamagotchi.tiempoTranscurridoMuerte = statsTamagotchi.tiempoTranscurridoMuerte.Add(new TimeSpan(0, 0, 1)); ;

            if (statsTamagotchi.tiempoTranscurridoMuerte.Seconds != 0 && statsTamagotchi.tiempoTranscurridoMuerte.Seconds % m_tiempoMuerte == 0)
            {
                SceneManager.LoadScene("Death");
            }
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator seEnsucia()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_tiempoSuciedad);
            if (!statsTamagotchi.estaSucio)
            {
                m_dustParticle.gameObject.SetActive(true);
                m_dustParticle.Play();
                statsTamagotchi.estaSucio = true;
            }

        }

    }

    private void seBaña()
    {
        m_dustParticle.gameObject.SetActive(false);
        m_dustParticle.Stop();
        statsTamagotchi.estaSucio = false;
    }

    private void comprobarSiEstaSucio()
    {
        if (statsTamagotchi.estaSucio)
        {
            StartCoroutine(seEnsucia());
        }
        else
        {
            seBaña();
        }
    }

}
