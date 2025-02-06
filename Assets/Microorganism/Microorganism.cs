using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microorganism : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.Instance.AddScore();
            Player.Instance.AddScale();
            Destroy(gameObject);
        }
    }
}
