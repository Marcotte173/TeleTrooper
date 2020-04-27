using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    
    Bow bow;
    internal bool shoot;
    private void Start()
    {
        
        bow = GetComponentInChildren<Bow>();
    }
    public void Forward(float moveSpeed)
    {
        transform.Translate(new Vector2(1, 0) * moveSpeed * Time.deltaTime);
        
    }

    internal void Fall(float fallSpeed)
    {
        transform.Translate(new Vector2(0, -1) * fallSpeed * Time.deltaTime);
    }

    internal void Jump(float jumpSpeed)
    {
        transform.Translate(new Vector2(0, 1) * jumpSpeed * Time.deltaTime);
    }

    internal void Shoot()
    {
        shoot = true;
    }

    internal void Teleport()
    {
        transform.position = bow.lastArrow.transform.position;
        bow.lastArrow.SetActive(false);
        bow.lastArrow.GetComponent<Arrow>().currentTime = bow.lastArrow.GetComponent<Arrow>().lifetime;
    }
}
