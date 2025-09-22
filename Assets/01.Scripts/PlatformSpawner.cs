using UnityEngine;
//오브젝트 폴링 미리 몇개의 오브젝트를 생성하고 재활용 하는 작업

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] GameObject platPreFab; // 생성할 폴링 오브젝트
    int count = 3; // 만들 폴링 갯수
    GameObject[] platforms; // 생성한 인스턴스 폴링의 위치값이나 생성간격을 할당할 변수
    
    float spawmMin = 1.25f;
    float spawmMax = 2.25f;
    //발판이 생성될 쿨타임
    float spawmTime;
    //발판의 생성 시간
   
    
    float posX = 20f;
    //생성된 발판의 X의 고정 초기값
    float yMin = -3.5f;
    float yMax = 1.5f;
    // 발판의 랜덤한 높이 위치값
    float posY;
    // 발판의 출발지

    int currIndex;  // 사용할 발판의 순서
    Vector3 poolPosition = new Vector3 (0, -15, 0); //폴링 하기 위한 오브젝트 생성의 대기위치
    float lastSpawmTime; // 마지막 배치 시점


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        platforms = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platPreFab, poolPosition, Quaternion.identity);
        }
        // 발판 생성 및 count를 이용한 발판 갯수 제한
        lastSpawmTime = 0f;
        //마지막 배치 시점 초기화
        spawmTime = 0f;
        //다음번 배치까지의 시간 간격을 0으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
            return;
        //게임 오버가 됬을때 발판도 정지

        if (Time.time >=lastSpawmTime+spawmTime)
            //발판의 생성 기한 + 발판이 바로 생성시 발판 스폰타임이 없기에
            //무한 재생성을 막기 위한 생성 쿨타임을 넣기
        { 
           lastSpawmTime = Time.time;
           spawmTime = Random.Range(spawmMin, spawmMax);
            //랜덤으로 발판 생성후 일정 시간후에 생성

            platforms[currIndex].SetActive(false);
            platforms[currIndex].SetActive(true);

            //각각 발판의 스파이크를 재 생성하기 위한 발판의 비활성화/재활성화 작동

           posY = Random.Range(yMin,yMax);
            //생성되는 발판의 위치값
           platforms[currIndex].transform.position = new Vector3(posX, posY);
            //각각 생성되는 발판의 폴링의 위치 재배정
            currIndex++;
                //순번 넘기기



            if (currIndex >= count)

            { currIndex = 0; }
            //폴링되는 발판 위치 재배정을 다시 첫번째 오브젝트로 옮기기 위한 코드

        }
    }
}
