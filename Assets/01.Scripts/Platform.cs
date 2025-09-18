using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles; // 장애물 오브젝트틀
    private bool stepped = false; // 플레이어가 밟았는가


    //컴포넌트가 활성 될때마다 발동되는 메서드
    private void OnEnable()
    {
        
    }
    //발판을 리셋하는 처리

    private void OnCollisionEnter2D(Collision2D collision)
        //플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
