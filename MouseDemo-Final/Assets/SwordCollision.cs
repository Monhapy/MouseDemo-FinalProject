using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    private Collider _swordCollider;
    private GameObject _cubeEnemyObject;
    private GameObject _cameraObject;
    
    private string _targetTag;
    private string _cameraTag;
    
    private CubeEnemy _cubeEnemy;
    private CameraProp _cameraProp;
    
    private void Start()
    {
        _targetTag = "Enemy";
        _cameraTag = "MainCamera";
            
        _cubeEnemyObject= GameObject.FindGameObjectWithTag(_targetTag);
        _cameraObject = GameObject.FindGameObjectWithTag(_cameraTag);

        _cameraProp = _cameraObject.GetComponent<CameraProp>();
        _cubeEnemy = _cubeEnemyObject.GetComponent<CubeEnemy>();
        _swordCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_targetTag))
        {
            _cubeEnemy.Hit();
            _cameraProp.CamAttackShake();
        }
    }


    public void SwordColliderEnabled()
    {
        _swordCollider.enabled = true;
    }
    public void SwordColliderDisabled()
    {
        _swordCollider.enabled = false;
    }
}