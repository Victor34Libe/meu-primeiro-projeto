using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;

    public void OnButtonClick()
    {
        Color selectedColor = uiButton.GetComponent<Image>().color;
        paddleReference.color = selectedColor;

        Debug.Log($"Botão clicado: Cor selecionada = {selectedColor}");


        if (isColorPlayer)
        {
            Debug.Log("Atualizando cor do jogador no SaveController");
            SaveController.Instance.colorPlayer = selectedColor;
        }
        else
        {
            Debug.Log("Atualizando cor do inimigo no SaveController");
            SaveController.Instance.colorEnemy = selectedColor;
        }
    }
}
