using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void ClearData()
    {
        Debug.Log("Jogo Resetado");
        SaveController.Instance.ClearSave();
    }
}
