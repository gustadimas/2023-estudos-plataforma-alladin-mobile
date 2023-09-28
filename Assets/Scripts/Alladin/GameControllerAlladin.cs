using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerAlladin : MonoBehaviour
{
    [SerializeField] GameObject vaso, maca, dima;
    [SerializeField] GameObject panel;
    [SerializeField] float vasoMacaDimaSpawn;
    [SerializeField] Text txtPontos;
    [SerializeField] float probabilidadeMaca = 0.3f; // 30% de chance de spawnar uma maçã
    [SerializeField] float probabilidadeVaso = 0.7f; // 70% de chance de spawnar um vaso
    [SerializeField] float probabilidadeDima = 0.2f; // 20% de chance de spawnar um diamante 
    public static int pontos;
    public static int vidas = 10;
    public static int dimas = 0;

    void Start()
    {
        Time.timeScale = 1;
        vidas = 10;
        VasoSpawn();
        panel.SetActive(false);
    }

    void VasoSpawn()
    {
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Screen.width / Screen.height;

        float minY = -halfHeight;
        float maxY = halfHeight;

        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(9, randomY, 0);

        float randomValue = Random.value;

        if (randomValue < probabilidadeVaso)
        {
            GameObject _vaso = Instantiate(vaso, spawnPosition, Quaternion.identity);
        }
        else if (randomValue < probabilidadeVaso + probabilidadeMaca)
        {
            GameObject _maca = Instantiate(maca, spawnPosition, Quaternion.identity);
        }
        else if (randomValue < probabilidadeVaso + probabilidadeMaca + probabilidadeDima)
        {
            GameObject _dima = Instantiate(dima, spawnPosition, Quaternion.identity);
        }

        Invoke(nameof(VasoSpawn), vasoMacaDimaSpawn);
    }

    public void Perdeu()
    {
        Time.timeScale = 0;
        panel.SetActive(true);

        txtPontos.text = "Pontuação Final: " + pontos;
    }

    public void Voltar()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}