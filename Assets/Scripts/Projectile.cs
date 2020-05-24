using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Projectile : MonoBehaviour, IPooledObject
{
    public int amountOfDamage = 20;

    public bool IsVisible(Camera camera)
    {
        return transform.position.x >= CameraExtensions.BoundsMin(camera).x - 2;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        FindObjectOfType<AudioManager>().Play("Hit");

        GameObject obj = col.gameObject;
        Player script = (Player)obj.GetComponent(typeof(Player));
        script.ApplyDamage(amountOfDamage);

        gameObject.SetActive(false);
    }
}
