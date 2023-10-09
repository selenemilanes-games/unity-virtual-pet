using UnityEngine;

public class ActivarMenuController : MonoBehaviour
{

    public void ActivarMenu()
    {
        activarMenu(true);
    }

    public void DesactivarMenu(string nombreBoton)
    {
        if (nombreBoton != this.gameObject.name)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                if (this.gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    private void activarMenu(bool estado)
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                this.gameObject.transform.GetChild(i).gameObject.SetActive(!estado);
            }
            else
            {
                this.gameObject.transform.GetChild(i).gameObject.SetActive(estado);
            }
        }
    }
}
