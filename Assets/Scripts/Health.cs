using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    internal float _maxHp;
    internal float _hp;

    // Start is called before the first frame update
    void Start()
    {
        _hp = _maxHp = GetComponent<CharacterInfo>().health;
    }

    internal void TakeDamage(int damage)
    {
        _hp = (_hp - damage <= 0) ? 0 : _hp - damage;
        if (_hp == 0) gameObject.SetActive(false);
    }

    internal void Heal(int heal)
    {
        _hp = (_hp + heal >= _maxHp) ? _maxHp : _hp + heal;
    }
}
