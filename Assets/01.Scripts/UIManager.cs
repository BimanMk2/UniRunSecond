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

    //���Ŵ����� ���� ���� �ٽ� �ε��Ͽ� ����ŸƮ

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Aplication.Quit();

#endif

        Application.Quit();
    }
    //����Ƽ�� �ִ� ���� ���� �޼���

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
