using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster List", menuName = "MonsterPalace/Bestiary/MonsterList")]
public class SO_MonsterList : ScriptableObject
{
    public List<SO_Monster> monsterList;
}
