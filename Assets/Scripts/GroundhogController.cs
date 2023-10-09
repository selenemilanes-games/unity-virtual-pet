using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundhogController : MonoBehaviour
{

    public delegate void Monedas(int cantidad);
    public event Monedas monedasConseguidas;


    private void OnMouseDown()
    {
        monedasConseguidas.Invoke(1);
        this.gameObject.SetActive(false);

    }
}
