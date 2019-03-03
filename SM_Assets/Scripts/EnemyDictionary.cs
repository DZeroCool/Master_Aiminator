using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDictionary<TK, TV> : Dictionary<TK, TV>
{
    private Dictionary<TK, TV> enemy_dictionary;
    [SerializeField] List<TK> enemy_names;
    [SerializeField] List<TV> enemy_objects;
}
