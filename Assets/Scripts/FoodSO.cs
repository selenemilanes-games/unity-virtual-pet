using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoodSO : ScriptableObject
{
    public string foodName;
    public int cost;
    public int hunger;
    public int happiness;
}
