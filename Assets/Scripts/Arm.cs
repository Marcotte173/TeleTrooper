using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    internal void Up()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 115);
        GetComponentInChildren<Bow>().shotAngle = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 60);
    }

    internal void Down()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30);
        GetComponentInChildren<Bow>().shotAngle = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -30);
    }

    internal void Standard()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 66);
        GetComponentInChildren<Bow>().shotAngle = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
