using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoDaBola : MonoBehaviour
{
    [SerializeField] private AudioSource somDaBolaBatendo;

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        somDaBolaBatendo.Play();
    }
}
