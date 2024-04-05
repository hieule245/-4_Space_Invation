using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected int movespeed = 1;
    [SerializeField] protected Vector3 direc = Vector3.right;

    void Update()
    {
        transform.parent.Translate(this.direc * this.movespeed * Time.deltaTime);
    }
}
