using UnityEngine;
//������Ʈ ���� �̸� ��� ������Ʈ�� �����ϰ� ��Ȱ�� �ϴ� �۾�

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] GameObject platPreFab; // ������ ���� ������Ʈ
    int count = 3; // ���� ���� ����
    GameObject[] platforms; // ������ �ν��Ͻ� ������ ��ġ���̳� ���������� �Ҵ��� ����
    
    float spawmMin = 1.25f;
    float spawmMax = 2.25f;
    //������ ������ ��Ÿ��
    float spawmTime;
    //������ ���� �ð�
   
    
    float posX = 20f;
    //������ ������ X�� ���� �ʱⰪ
    float yMin = -3.5f;
    float yMax = 1.5f;
    // ������ ������ ���� ��ġ��
    float posY;
    // ������ �����

    int currIndex;  // ����� ������ ����
    Vector3 poolPosition = new Vector3 (0, -15, 0); //���� �ϱ� ���� ������Ʈ ������ �����ġ
    float lastSpawmTime; // ������ ��ġ ����


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        platforms = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platPreFab, poolPosition, Quaternion.identity);
        }
        // ���� ���� �� count�� �̿��� ���� ���� ����
        lastSpawmTime = 0f;
        //������ ��ġ ���� �ʱ�ȭ
        spawmTime = 0f;
        //������ ��ġ������ �ð� ������ 0���� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
            return;
        //���� ������ ������ ���ǵ� ����

        if (Time.time >=lastSpawmTime+spawmTime)
            //������ ���� ���� + ������ �ٷ� ������ ���� ����Ÿ���� ���⿡
            //���� ������� ���� ���� ���� ��Ÿ���� �ֱ�
        { 
           lastSpawmTime = Time.time;
           spawmTime = Random.Range(spawmMin, spawmMax);
            //�������� ���� ������ ���� �ð��Ŀ� ����

            platforms[currIndex].SetActive(false);
            platforms[currIndex].SetActive(true);

            //���� ������ ������ũ�� �� �����ϱ� ���� ������ ��Ȱ��ȭ/��Ȱ��ȭ �۵�

           posY = Random.Range(yMin,yMax);
            //�����Ǵ� ������ ��ġ��
           platforms[currIndex].transform.position = new Vector3(posX, posY);
            //���� �����Ǵ� ������ ������ ��ġ �����
            currIndex++;
                //���� �ѱ��



            if (currIndex >= count)

            { currIndex = 0; }
            //�����Ǵ� ���� ��ġ ������� �ٽ� ù��° ������Ʈ�� �ű�� ���� �ڵ�

        }
    }
}
