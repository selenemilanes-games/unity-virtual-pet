using System.Collections;
using UnityEngine;


public class FoodController : MonoBehaviour
{
    [SerializeField]
    public FoodSO foodSO;
    [SerializeField]
    private TamagotchiSO statsTamagotchi;
    private AudioSource[] sfx;

    public void Awake()
    {
        sfx = GetComponents<AudioSource>();
    }

    public void Comprar()
    {
        bool yaComprado = false;
        int hambreProvisional = statsTamagotchi.hambre + foodSO.hunger;
        int felicidadProvisional = statsTamagotchi.felicidad + foodSO.happiness;


        if (statsTamagotchi.gotchis < foodSO.cost || (statsTamagotchi.hambre == statsTamagotchi.maxHambre && statsTamagotchi.felicidad == statsTamagotchi.maxFelicidad))
        {
            sfx[2].Play();
            return;
        }

        //El hambre del Tamagotchi es inferior a maxHambre (pero el hambre que ganara es superior a maxHambre) y tiene dinero para comprar = se iguala hambre a maxHambre
        if (statsTamagotchi.hambre < statsTamagotchi.maxHambre && hambreProvisional >= statsTamagotchi.maxHambre && statsTamagotchi.gotchis >= foodSO.cost)
        {
            statsTamagotchi.hambre = statsTamagotchi.maxHambre;
            statsTamagotchi.gotchis -= foodSO.cost;
            sfx[1].Play();
            StartCoroutine(playSfx());
            yaComprado = true;

        }

        //El hambre del Tamagotchi es inferior a maxHambre (y el hambre que ganara es inferior a maxHambre) y tiene dinero para comprar = se le suma el hambre
        else if (statsTamagotchi.hambre < statsTamagotchi.maxHambre && hambreProvisional < statsTamagotchi.maxHambre && statsTamagotchi.gotchis >= foodSO.cost)
        {
            statsTamagotchi.hambre += foodSO.hunger;
            statsTamagotchi.gotchis -= foodSO.cost;
            sfx[1].Play();
            StartCoroutine(playSfx());
            yaComprado = true;

            if (statsTamagotchi.comienzaTiempoMuerte && statsTamagotchi.felicidad > 0)
            {
                statsTamagotchi.comienzaTiempoMuerte = false;
                sfx[3].Play();
            }
        }

        if (statsTamagotchi.felicidad < statsTamagotchi.maxFelicidad && felicidadProvisional >= statsTamagotchi.maxFelicidad)
        {
            if (!yaComprado && statsTamagotchi.gotchis >= foodSO.cost)
            {
                statsTamagotchi.felicidad = statsTamagotchi.maxFelicidad;
                statsTamagotchi.gotchis -= foodSO.cost;
                sfx[1].Play();
                StartCoroutine(playSfx());
            }
            else
            {
                statsTamagotchi.felicidad = statsTamagotchi.maxFelicidad;
            }

        }
        else if (statsTamagotchi.felicidad < statsTamagotchi.maxFelicidad && felicidadProvisional < statsTamagotchi.maxFelicidad)
        {
            if (!yaComprado && statsTamagotchi.gotchis >= foodSO.cost)
            {
                statsTamagotchi.felicidad += foodSO.happiness;
                statsTamagotchi.gotchis -= foodSO.cost;
                sfx[1].Play();
                StartCoroutine(playSfx());
            }
            else
            {
                statsTamagotchi.felicidad += foodSO.happiness;
            }

            if (statsTamagotchi.comienzaTiempoMuerte && statsTamagotchi.hambre > 0)
            {
                statsTamagotchi.comienzaTiempoMuerte = false;
                sfx[3].Play();
            }
            }

    }

    public IEnumerator playSfx()
    {
        yield return new WaitForSeconds(0.5f);
        sfx[0].Play();
    }
}
