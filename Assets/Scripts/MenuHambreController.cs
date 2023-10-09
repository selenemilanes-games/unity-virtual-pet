using System.Collections;
using UnityEngine;

public class MenuHambreController : MonoBehaviour
{
    public TamagotchiSO statsTamagotchi;

    private void OnEnable()
    {
        actualizarHambre();
    }

    public void actualizarHambre()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(i < statsTamagotchi.hambre ? true : false);
        }
    }
}
