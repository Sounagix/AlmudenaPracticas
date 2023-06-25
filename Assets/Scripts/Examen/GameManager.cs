using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string txtName = "puntos.txt";

    public string filePath;

    private int puntos;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            filePath = Path.Combine(Application.persistentDataPath, txtName);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int _points)
    {
        puntos += _points;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
      
        using (StreamWriter writer = File.CreateText(filePath))
        {
            writer.Write(puntos.ToString());
        }
    }
}
