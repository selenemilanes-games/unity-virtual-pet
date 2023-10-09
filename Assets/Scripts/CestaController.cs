using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CestaController : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset m_InputAsset;
    private InputActionAsset m_Input;
    private InputAction m_MovementAction;
    private InputAction m_PointerPosition;

    public delegate void Monedas(int cantidad);
    public event Monedas monedasConseguidas;

    private AudioSource monedaSound;

    void OnEnable()
    {
        m_Input = Instantiate(m_InputAsset);
        m_MovementAction = m_Input.FindActionMap("Minijuego").FindAction("Movimiento");
        m_MovementAction.performed += movimientoCesta;
        m_PointerPosition = m_Input.FindActionMap("Minijuego").FindAction("PointerPosition");

        m_Input.FindActionMap("Minijuego").Enable();
        this.gameObject.transform.position = new Vector2(0.67f, -2.55f);

        monedaSound = this.GetComponent<AudioSource>();
    }

    private void movimientoCesta(InputAction.CallbackContext context)
    { 
        if (!this.IsDestroyed())
        {
            //Obtenemos la posicion donde hacemos touch
            Vector2 pointerPosition = m_PointerPosition.ReadValue<Vector2>();

            if (pointerPosition.x >= 0 && pointerPosition.x < 305)
            {
                this.gameObject.transform.position = new Vector2(-6.78f, -2.55f);
            }
            else if (pointerPosition.x >= 305 && pointerPosition.x < 610)
            {
                this.gameObject.transform.position = new Vector2(0.67f, -2.55f);

            }
            else if (pointerPosition.x >= 306 && pointerPosition.x < 915)
            {
                this.gameObject.transform.position = new Vector2(5.34f, -2.55f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruta")
        {
            monedasConseguidas.Invoke(1);
            monedaSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
