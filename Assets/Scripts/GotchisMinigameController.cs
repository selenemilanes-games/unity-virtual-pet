using TMPro;
using UnityEngine;

public class GotchisMinigameController : MonoBehaviour
{
    public CestaController cController;
    private TextMeshProUGUI m_TextMeshPro;
    public int monedas;

    void Awake()
    {
        monedas = 0;
        m_TextMeshPro = this.GetComponent<TextMeshProUGUI>();
        m_TextMeshPro.text = "" + monedas;
    }

    private void Start()
    {
        cController.monedasConseguidas += aumentarGotchis;
    }

    private void aumentarGotchis(int cantidad)
    {
        monedas += cantidad;
        m_TextMeshPro.text = "" + monedas;
    }
   
}
