using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterSeconds : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(35f);
        Cursor.visible = true;
        SceneManager.LoadScene(1);
    }
}
