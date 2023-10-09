using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TamagotchiSO : ScriptableObject
{
    [Header("Características")]
    public string colorHuevo;
    public int maxHambre;
    public int maxFelicidad;
    public int hambre;
    public int felicidad;
    public int gotchis;

    [Space(10)]
    [Header("Animaciones")]
    public List<RuntimeAnimatorController> m_animators = new List<RuntimeAnimatorController>();
    public RuntimeAnimatorController animatorActual;

    [Space(10)]
    [Header("Estados")]
    public bool haHatcheado;
    public bool estaSucio;

    [Space(10)]
    [Header("Tiempo")]
    public bool comienzaTiempo;
    public bool comienzaTiempoMuerte;
    public TimeSpan tiempoTranscurrido;
    public TimeSpan tiempoTranscurridoMuerte;
}
