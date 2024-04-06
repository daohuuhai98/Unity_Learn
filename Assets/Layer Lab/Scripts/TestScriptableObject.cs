using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = 1)]

public class CharacterData : ScriptableObject
{
    public List<Character> ListCharacter;
}

[System.Serializable]

public class Character
{
    public string name;
    public Sprite icon;
    public float exp;
    public int level;
    public int[] geminv;
}