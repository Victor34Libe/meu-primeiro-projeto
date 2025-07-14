using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private Color _colorPlayer = Color.white;
    private Color _colorEnemy = Color.white;

    private static SaveController _instance;

    public string namePlayer;
    public string nameEnemy;

    public Color colorPlayer
    {
        get => _colorPlayer;
        set
        {
            Debug.Log($"Atualizando cor do jogador para: {value}");
            _colorPlayer = value;
        }
    }

    public Color colorEnemy
    { 
        get => _colorEnemy;
        set
        {
            Debug.Log($"Atualizando cor do inimigo para: {value}");
            _colorEnemy = value;
        }
    }

    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SaveController ainda não existe, procurando na cena...");
                _instance = FindObjectOfType<SaveController>();

                if (_instance == null)
                {
                    Debug.Log("Nenhum SaveController encontrado na cena. Criando um novo.");
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
                else
                {
                    Debug.Log("SaveController encontrado na cena.");
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.Log("Outro SaveController ja existe. Destruindo este.");
            Destroy(this.gameObject);
            return;
        }

        Debug.Log("SaveController iniciado com sucesso.");
        DontDestroyOnLoad(this.gameObject);

    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        Debug.Log("Jogador Venceu");
        PlayerPrefs.SetString("SavedWinner", winner);
    }
    public string GetLastWinner()
    {
        Debug.Log("Ultimo vencedor Salvo");
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void ClearSave()
    {
        Debug.Log("Jogo Resetado");
        PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
