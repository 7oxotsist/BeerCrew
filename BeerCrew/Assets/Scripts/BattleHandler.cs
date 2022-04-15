using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform pfCharacterBattle;

    private void Start() {
        Instantiate(pfCharacterBattle, new Vector3(-10, 0), Quaternion.identity);
        Instantiate(pfCharacterBattle, new Vector3(10, 0), Quaternion.identity);
    }
}
