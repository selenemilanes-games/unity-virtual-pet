using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagotchiDeadController : MonoBehaviour
{
    private float speed = 2f;
    private float limiteDerecho = 5f;
    private float limiteIzquierdo = -5f;
    private bool direccionIzquierda = true;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    void Update()
    {
        if (direccionIzquierda)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= limiteIzquierdo)
            {
                direccionIzquierda = false;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= limiteDerecho)
            {
                direccionIzquierda = true;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
