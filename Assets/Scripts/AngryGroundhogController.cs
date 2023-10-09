using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryGroundhogController : MonoBehaviour
{
    public delegate void AngryFaces(int cantidad);
    public event AngryFaces angryFacesConseguidas;

    private void OnMouseDown()
    {
        angryFacesConseguidas.Invoke(1);
        this.gameObject.SetActive(false);
    }
}
