using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles; // 장애물 오브젝트틀
    private bool stepped; // 플레이어가 밟았는가 모든 기본 변수형태에는 기본값이 들어가 있긴 하다
    int count; 
    //컴포넌트가 활성 될때마다 발동되는 메서드
    private void OnEnable()// 세개의 스파이크에 각각 하나에게 특정 숫자 3개를 주워 그 값이 맞으면
                        // 스파이크가 작동하도록 발동 하는 코드

    {
        count = 0;
        //카운트 숫자를 초기화 해서 스코어 점수가 누적되는것을 방지
        for (int i = 0; i < obstacles.Length; i++)
        {
            stepped = false;

            if(Random.Range(0,3)==2)
            {
                obstacles[i].SetActive(true);
                count++;
               
            }
            else 
                obstacles[i].SetActive(false);

        }
        //발판을 랜덤으로 활성화 하는 코드
    }
    //발판을 리셋하는 처리


    
 
    

    private void OnCollisionEnter2D(Collision2D collision)
        //플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
    {
        if (!stepped && collision.transform.tag == "Player")
            //2D 콜리젼은 복잡하기에 찾을 오브젝트에 태그로 찾기 하기전에 한번 더 찾을 태그의 종류를
            //세세하게 정해줘야 한다. 모든 오브젝트에게 지니고 있는 트랜스폼을 활용
            //그냥 콜리젼은 태그 바로 해도 되지만, 2D는 복잡해서 한번 더 해줘야 함
        { 
        stepped=true;
            int newScore = count + 1 ;
            GameManager.instance.AddScore(newScore);
            //스파이크 갯수에 따라 추가 점수를 넣는 코드
            //싱글턴 게임 매니저의 쉬운 접근을 이용한 인스텐스 코드 활용
            // new는 지역변수.... 기억하자
        }
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
