using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
    public Transform player;//�ړI�n�A����͖ؔ�
    private NavMeshAgent agent;
    void Start()
    {
        //NavMeshAgent���擾��agent�Ɋi�[���Ă���
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //�ړ���̖ڕW�n�_�U�����Ă���
        agent.destination = player.position;
    }
}
