using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float currentTime;
    public float shootSpeed;
    public List<GameObject> arrowList;
    public GameObject arrow;
    public float amountOfProjectiles;
    public GameObject lastArrow;
    Action action;
    internal Vector3 shotAngle;
    public GameObject shotOrigin;
    

    private void Start()
    {
        action = GetComponentInParent<Action>();
        for (int i = 0; i < amountOfProjectiles; i++)
        {
            arrow = Instantiate(arrow, new Vector2 (transform.position.x,transform.position.y), transform.rotation);
            arrowList.Add(arrow);
            arrow.SetActive(false);
        }
    }

    private void Update()
    {

        if (currentTime <= 0)
        {
            if (action.shoot == true)
            {
                action.shoot = false;
                foreach (GameObject arrow in arrowList) if (arrow.activeSelf == false)
                    {
                        arrow.SetActive(true);
                        arrow.transform.position = shotOrigin.transform.position;
                        arrow.transform.eulerAngles = shotAngle;
                        lastArrow = arrow;
                        break;
                    }
                currentTime = shootSpeed;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}