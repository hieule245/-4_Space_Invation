using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = true;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform bulletPrefab;


    void Update()
    {
        this.IsShooting();
        
    }

    void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        this.shootTimer += Time.fixedDeltaTime;

        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        //Transform newbullet = Instantiate(this.bulletPrefab, spawnPos, rotation);
        Transform newbullet = Spawner.instance.Spawn(spawnPos, rotation);
        newbullet.gameObject.SetActive(true);
        Instantiate(this.bulletPrefab);
        
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
