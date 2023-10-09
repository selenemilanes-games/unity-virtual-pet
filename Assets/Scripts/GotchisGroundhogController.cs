using TMPro;
using UnityEngine;

public class GotchisGroundhogController : MonoBehaviour
{

    public GroundhogController[] groundhogController;
    private TextMeshProUGUI m_TextMeshPro;
    public int monedasGroundhog;
    private AudioSource m_audio;

    void Awake()
    {
        monedasGroundhog = 0;
        m_TextMeshPro = this.GetComponent<TextMeshProUGUI>();
        m_TextMeshPro.text = "" + monedasGroundhog;
        m_audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        foreach (var grounghog in groundhogController)
        {
            grounghog.monedasConseguidas += aumentarGotchisGroundhog;
        }
        
    }

    private void aumentarGotchisGroundhog(int cantidad)
    {
        monedasGroundhog += cantidad;
        m_audio.Play();
        m_TextMeshPro.text = "" + monedasGroundhog;
    }
}
