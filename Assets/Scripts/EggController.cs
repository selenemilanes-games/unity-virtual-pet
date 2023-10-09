using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggController : MonoBehaviour
{
    [SerializeField]
    private TamagotchiSO tamagotchiSO;
    private bool huevoClicado = false;
    private AudioSource sfx;

    void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (this.GetComponent<Rigidbody2D>().transform.position.y > 0f)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnMouseEnter()
    {
        if (!huevoClicado) transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
    }

    private void OnMouseExit()
    {
        if (!huevoClicado) transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.5f);
    }

    private void OnMouseDown()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.up;
        sfx.Play();
        this.GetComponent<ParticleSystem>().Play();

        huevoClicado = true;
        tamagotchiSO.colorHuevo = this.name;

        StartCoroutine(cambioEscena());
    }

    public IEnumerator cambioEscena()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Tamagotchi");
    }
}
