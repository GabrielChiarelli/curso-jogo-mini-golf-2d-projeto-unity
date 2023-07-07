using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDaBolaDeGolf : MonoBehaviour
{
    [SerializeField] private Rigidbody2D oRigidbody2D;
    [SerializeField] private LineRenderer oLineRenderer;
    [SerializeField] private Camera cameraDoJogo;
    [SerializeField] private Animator oAnimator;

    [SerializeField] private float forcaParaAdicionar;
    [SerializeField] private float limiteDoArrastar;
    [SerializeField] private float velocidadeMinimaParaArrastar;
    private Vector3 posicaoDoMouse;

    private bool estaArrastando;

    private void Start()
    {
        oLineRenderer.positionCount = 2;
        oLineRenderer.SetPosition(0, Vector2.zero);
        oLineRenderer.SetPosition(1, Vector2.zero);
        oLineRenderer.enabled = false;
    }

    private void Update()
    {
        PegarPosicaoDoMouse();

        if (Input.GetMouseButtonDown(0) && estaArrastando == false && oRigidbody2D.velocity.magnitude <= velocidadeMinimaParaArrastar)
        {
            IniciarArrastar();
        }

        if (estaArrastando)
        {
            Arrastar();
        }

        if (Input.GetMouseButtonUp(0) && estaArrastando)
        {
            PararDeArrastar();
        }
    }

    private void PegarPosicaoDoMouse()
    {
        posicaoDoMouse = cameraDoJogo.ScreenToWorldPoint(Input.mousePosition);
        posicaoDoMouse.z = 0f;
    }

    private void IniciarArrastar()
    {
        estaArrastando = true;

        oLineRenderer.enabled = true;
        oLineRenderer.SetPosition(0, posicaoDoMouse);
        oLineRenderer.SetPosition(1, Vector2.zero);
    }

    private void Arrastar()
    {
        Vector3 posicaoInicial = oLineRenderer.GetPosition(0);
        Vector3 posicaoAtual = posicaoDoMouse;

        Vector3 distanciaDoArrastar = posicaoAtual - posicaoInicial;
        if (distanciaDoArrastar.magnitude <= limiteDoArrastar)
        {
            oLineRenderer.SetPosition(1, posicaoAtual);
        }
        else
        {
            Vector3 distanciaLimitada = posicaoInicial + (distanciaDoArrastar.normalized * limiteDoArrastar);
            oLineRenderer.SetPosition(1, distanciaLimitada);
        }
    }

    private void PararDeArrastar()
    {
        estaArrastando = false;
        oLineRenderer.enabled = false;

        Vector3 posicaoInicial = oLineRenderer.GetPosition(0);
        Vector3 posicaoAtual = oLineRenderer.GetPosition(1);
        Vector3 distanciaDoArrastar = posicaoAtual - posicaoInicial;

        Vector3 forcaFinal = distanciaDoArrastar * forcaParaAdicionar;
        oRigidbody2D.AddForce(-forcaFinal, ForceMode2D.Impulse);
    }   

    public void RodarAnimacaoDaBolaCaindo()
    {
        oRigidbody2D.velocity = Vector2.zero;
        oAnimator.Play("bola-caindo");
        Destroy(oRigidbody2D.transform.gameObject, 1f);
        Destroy(this.gameObject, 1f);
    }
}
