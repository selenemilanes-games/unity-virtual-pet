using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuController : MonoBehaviour
{
    [Header("Game events")]
    public GameEvent abrirMenuStats;
    public GameEvent abrirMenuFood;
    public GameEvent abrirMenuBath;
    public GameEvent abrirMenuGames;
    public GameEventGenerico<string> cerrarMenus;
    public GameEvent limpiarCacas;
    public GameEvent tocaBanarse;
    [SerializeField]
    private TamagotchiSO statsTamagotchi;

    public void carregarMenu()
    {

        if (name == "Btn_GoHome")
        {
            SceneManager.LoadScene("Tamagotchi");
        }
        else if (name == "Btn_Stats")
        {
            abrirMenuStats.Raise();
            cerrarMenus.Raise("StatsMenu");
        }
        else if (name == "Btn_Food")
        {
            abrirMenuFood.Raise();
            cerrarMenus.Raise("FoodMenu");
        }
        else if (name == "Btn_PlayGames")
        {
            if (!statsTamagotchi.comienzaTiempoMuerte) abrirMenuGames.Raise();
        }
        else if (name == "Btn_Games")
        {
            SceneManager.LoadScene("MinigameFruits");
        }
        else if (name == "Btn_GamesGroundhog")
        {
            SceneManager.LoadScene("MinigameGroundhog");
        }
        else if (name == "Btn_Bath")
        {
            abrirMenuBath.Raise();
            cerrarMenus.Raise("BathMenu");
        }
        else if (name == "Btn_StartGame")
        {
            SceneManager.LoadScene("SelectEgg");
        }
    }

    public void irWC()
    {
        limpiarCacas.Raise();
    }

    public void bañarse()
    {
        tocaBanarse.Raise();
    }

    public void activamosExplicacion()
    {
        if (name == "Btn_Games")
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (name == "Btn_GamesGroundhog")
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void desactivamosExplicacion()
    {
        if (name == "Btn_Games")
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (name == "Btn_GamesGroundhog")
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

}
