using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public bool player1;
    public bool player2;
    public bool enemy;
    [SerializeField]
    internal int health;
    [SerializeField]
    internal float moveSpeed;
    [SerializeField]
    internal float jumpForce;
}