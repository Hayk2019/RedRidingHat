using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangingScene : MonoBehaviour
{

    public void changeScene() {
        SceneManager.LoadScene(1);
    }

}
