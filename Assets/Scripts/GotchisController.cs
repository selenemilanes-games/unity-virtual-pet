using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GotchisController : MonoBehaviour
{

    public TamagotchiSO statsTamagotchi;

    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = statsTamagotchi.gotchis+"";
    }

    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = statsTamagotchi.gotchis + "";
    }
}
