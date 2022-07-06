using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int ScorePlayer;
    public int ScoreEnemy;
    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat"); 
        SaveData data = new SaveData();
        data.ScorePlayer = ScorePlayer;
        data.ScoreEnemy = ScoreEnemy;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
            File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            ScoreEnemy = data.ScoreEnemy;
            ScorePlayer = data.ScorePlayer;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            ScorePlayer = 0;
            ScoreEnemy = 0;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerWin()
    {
        ScorePlayer += 1;
        SaveGame();
        Debug.Log("Reloading scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnemyWin()
    {
        ScoreEnemy += 1;
        SaveGame();
        Debug.Log("Reloading scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        LoadGame();
    }



    void OnGUI(){
        GUI.Label(new Rect(10, 10, 150, 150), "Score Player: " + ScorePlayer + "\nScore Enemy: " + ScoreEnemy);
        if (GUI.Button(new Rect(10, 50, 80, 40), "New Game")) ResetData();
    }

}
[Serializable]
class SaveData
{
    public int ScorePlayer;
    public int ScoreEnemy;
}
