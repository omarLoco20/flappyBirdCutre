using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class managerScene : MonoBehaviour
{

    string game = "SampleScene";

    public void playGame()
    {
        SceneManager.LoadScene(game);
    }

}
