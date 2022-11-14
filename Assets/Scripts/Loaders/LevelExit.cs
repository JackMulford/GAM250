using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;
    [SerializeField] AudioClip exitSound;
    [SerializeField][Range(0, 1)] float exitSoundVolume = 0.25f;

    void OnTriggerEnter2D(Collider2D Player)
    {
        StartCoroutine(LoadNextLevel());
        AudioSource.PlayClipAtPoint(exitSound, Camera.main.transform.position, exitSoundVolume);
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex = 0);
    }

}