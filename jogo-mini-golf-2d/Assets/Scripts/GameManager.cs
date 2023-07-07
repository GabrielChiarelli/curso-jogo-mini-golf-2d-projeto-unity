using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float tempoParaProximaFase;
    [SerializeField] private string nomeDaProximaFase;

    public void RodarCoroutineCarregarNovaFase()
    {
        StartCoroutine(CarregarNovaFase());
    }

    private IEnumerator CarregarNovaFase()
    {
        yield return new WaitForSeconds(tempoParaProximaFase);
        SceneManager.LoadScene(nomeDaProximaFase);
    }
}
