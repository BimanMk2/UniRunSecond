using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles; // ��ֹ� ������ƮƲ
    private bool stepped; // �÷��̾ ��Ҵ°� ��� �⺻ �������¿��� �⺻���� �� �ֱ� �ϴ�
    int count; 
    //������Ʈ�� Ȱ�� �ɶ����� �ߵ��Ǵ� �޼���
    private void OnEnable()// ������ ������ũ�� ���� �ϳ����� Ư�� ���� 3���� �ֿ� �� ���� ������
                        // ������ũ�� �۵��ϵ��� �ߵ� �ϴ� �ڵ�

    {
        count = 0;
        //ī��Ʈ ���ڸ� �ʱ�ȭ �ؼ� ���ھ� ������ �����Ǵ°��� ����
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
        //������ �������� Ȱ��ȭ �ϴ� �ڵ�
    }
    //������ �����ϴ� ó��


    
 
    

    private void OnCollisionEnter2D(Collision2D collision)
        //�÷��̾� ĳ���Ͱ� �ڽ��� ������� ������ �߰��ϴ� ó��
    {
        if (!stepped && collision.transform.tag == "Player")
            //2D �ݸ����� �����ϱ⿡ ã�� ������Ʈ�� �±׷� ã�� �ϱ����� �ѹ� �� ã�� �±��� ������
            //�����ϰ� ������� �Ѵ�. ��� ������Ʈ���� ���ϰ� �ִ� Ʈ�������� Ȱ��
            //�׳� �ݸ����� �±� �ٷ� �ص� ������, 2D�� �����ؼ� �ѹ� �� ����� ��
        { 
        stepped=true;
            int newScore = count + 1 ;
            GameManager.instance.AddScore(newScore);
            //������ũ ������ ���� �߰� ������ �ִ� �ڵ�
            //�̱��� ���� �Ŵ����� ���� ������ �̿��� �ν��ٽ� �ڵ� Ȱ��
            // new�� ��������.... �������
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
