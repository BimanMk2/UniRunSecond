#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public AudioSource music;
    public void Restrat()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        TimeScale(1);
    }

    //씬매니저를 통해 씬을 다시 로드하여 리스타트

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Aplication.Quit();

#endif

        Application.Quit();
    }
    //유니티에 있는 게임 종료 메서드

    public void TimeScale(int scale)

    { 
       Time.timeScale = scale;

        switch (scale)


        {
            case 0: music.Pause(); break;
            case 1: music.Play(); break;
        }
    }

}
