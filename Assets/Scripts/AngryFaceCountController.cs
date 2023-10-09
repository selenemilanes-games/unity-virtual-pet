using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AngryFaceCountController : MonoBehaviour
{
    public AngryGroundhogController[] angryGroundhogController;
    private TextMeshProUGUI m_TextMeshPro;
    public int angryFacesGroundhog;
    private AudioSource m_audio;
    public GameEvent loser;

    void Awake()
    {
        angryFacesGroundhog = 0;
        m_TextMeshPro = this.GetComponent<TextMeshProUGUI>();
        m_TextMeshPro.text = "" + angryFacesGroundhog;
        m_audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        foreach (var angryGroundhog in angryGroundhogController)
        {
            angryGroundhog.angryFacesConseguidas += aumentarAngryFaces;
        }
    }

    private void aumentarAngryFaces(int cantidad)
    {
        m_audio.Play();
        angryFacesGroundhog += cantidad;
        m_TextMeshPro.text = "" + angryFacesGroundhog;
        if (angryFacesGroundhog == 3)
        {
            loser.Raise();
        }
    }
}
