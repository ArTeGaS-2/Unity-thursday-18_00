using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microorganism : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
        else if (other.gameObject.CompareTag("Slime"))
        {
            Player.Instance.AddScale();
        }
        Score.Instance.AddScore();
        Destroy(gameObject);
    }
}
