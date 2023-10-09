using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    [SerializeField]
    private GameEvent heTocadoSuelo;
    [SerializeField]
    private List<Sprite> spritesFrutas = new List<Sprite>();

    private void Start()
    {
        int frutaRandom = Random.Range(0, 11);
        this.GetComponent<SpriteRenderer>().sprite = this.spritesFrutas[frutaRandom];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.tag == "Suelo")
            {
                heTocadoSuelo.Raise();
            }
        }
    }
}
