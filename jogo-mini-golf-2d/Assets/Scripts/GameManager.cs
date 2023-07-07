using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float tempoParaProximaFase;
    [SerializeField] private string nomeDaProximaFase;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SairDoJogo();
        }
    }

    public void RodarCoroutineCarregarNovaFase()
    {
        StartCoroutine(CarregarNovaFase());
    }

    private IEnumerator CarregarNovaFase()
    {
        yield return new WaitForSeconds(tempoParaProximaFase);
        SceneManager.LoadScene(nomeDaProximaFase);
    }

    private void SairDoJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
