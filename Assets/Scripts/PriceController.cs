using TMPro;
using UnityEngine;

public class PriceController : MonoBehaviour
{
    void OnEnable()
    {
        int coste = this.gameObject.transform.parent.gameObject.GetComponent<FoodController>().foodSO.cost;
        this.GetComponent<TextMeshProUGUI>().text = coste.ToString();
    }
}
