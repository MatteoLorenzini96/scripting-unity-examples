using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokeData_", menuName = "Scriptable/PokeData", order = 1)]
public class PokeData : ScriptableObject
{
    public int num;
    public string pokeName;
    public PokeType pokeType1;
    public PokeType pokeType2;
    public string bodyText;
    public Sprite img;
}
