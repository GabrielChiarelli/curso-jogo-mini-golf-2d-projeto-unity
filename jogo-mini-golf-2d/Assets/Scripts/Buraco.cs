using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    [SerializeField] private float velocidadeMaximaParaCair;
    [SerializeField] private AudioSource somDaBolaCaindo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            if (other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < velocidadeMaximaParaCair)
            {
                FindObjectOfType<ControleDaBolaDeGolf>().RodarAnimacaoDaBolaCaindo();
                somDaBolaCaindo.Play();
            }
        }
    }
}
