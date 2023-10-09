using System.Collections;
using UnityEngine;

public class MenuFelicidadController : MonoBehaviour
{

    public TamagotchiSO statsTamagotchi;

    private void OnEnable()
    {
        actualizarFelicidad();
    }

    public void actualizarFelicidad()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(i < statsTamagotchi.felicidad ? true : false);
        }
    }
}
