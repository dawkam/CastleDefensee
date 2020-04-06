using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navMeshAgent;
    private Transform _goal;
    public GameObject gm;
    private bool _isDead;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _goal = GameObject.FindGameObjectWithTag("Goal").transform;
        _navMeshAgent.SetDestination(_goal.position);
        _anim.SetBool("Walk Forward", true);
    }

    void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            Destroy(gm);

    }


    public void Die()
    {
        if (!_isDead)
        {
            _isDead = true;
            _anim.SetBool("Walk Forward", false);
            _anim.SetTrigger("Die");
            _navMeshAgent.isStopped = true;
        }
    }

    public void InsatnDie()
    {
        Destroy(gm);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        { 
            GameController.instance.TakeLP();
            InsatnDie();
        }
    }

}
