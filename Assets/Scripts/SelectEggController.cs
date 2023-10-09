using System;
using UnityEngine;

public class SelectEggController : MonoBehaviour
{
    [SerializeField]
    private TamagotchiSO statsTamagotchi;

    void Start()
    {
        initValues();
    }

    public void initValues()
    {
        statsTamagotchi.haHatcheado = false;
        statsTamagotchi.estaSucio = false;
        statsTamagotchi.comienzaTiempo = false;
        statsTamagotchi.tiempoTranscurrido = new TimeSpan(0, 0, 0);
        statsTamagotchi.comienzaTiempoMuerte = false;
        statsTamagotchi.tiempoTranscurridoMuerte = new TimeSpan(0, 0, 0);
        statsTamagotchi.maxHambre = 6;
        statsTamagotchi.maxFelicidad = 16;
        statsTamagotchi.hambre = statsTamagotchi.maxHambre;
        statsTamagotchi.felicidad = statsTamagotchi.maxFelicidad;
        statsTamagotchi.gotchis = 500;
    }
}

