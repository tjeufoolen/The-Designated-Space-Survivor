using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour, IPooledObject
{
    private int amountOfDamage = 20;

    public bool IsVisible(Camera camera)
    {
        return transform.position.x >= CameraExtensions.BoundsMin(camera).x;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        Player script = (Player) obj.GetComponent(typeof(Player));
        script.ApplyDamage(amountOfDamage);
        gameObject.SetActive(false);
    }
}
