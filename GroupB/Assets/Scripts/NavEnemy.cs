using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
    public Transform player;//目的地、今回は木箱
    private NavMeshAgent agent;
    void Start()
    {
        //NavMeshAgentを取得しagentに格納している
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //移動先の目標地点誘導している
        agent.destination = player.position;
    }
}
