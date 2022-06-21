using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private Transform _MyTransform;

    [Header("Parameters")]
    [SerializeField] private float _limitPosTouch;
    [SerializeField] private float _limitSpeedTouch;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _sensynity;

    [HideInInspector] public float stoped = 0;
    [HideInInspector] public float speedMove;
    [HideInInspector] public float leftMove;
    public Animator AnimPlayer { get; private set; }
    private static Player _instance;
    public static Player Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        speedMove = _maxSpeed;
        _MyTransform = GetComponent<Transform>();
        AnimPlayer = GetComponent<Animator>(); 
        TouchSystem.Touching += TouchSystem_Touching;
    }

    private void TouchSystem_Touching()
    {
        leftMove = 0;
        if (Mathf.Abs(TouchSystem.DistanceBetweenTwoFrame.x) >= 0.05f)
            leftMove = Mathf.Clamp(TouchSystem.DistanceBetweenTwoFrame.x, -_limitSpeedTouch, _limitSpeedTouch);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            _MyTransform.position += (Vector3.forward * speedMove + Vector3.right * (leftMove * _sensynity)) * Time.deltaTime;
            _MyTransform.position = new Vector3(Mathf.Clamp(_MyTransform.position.x, -_limitPosTouch, _limitPosTouch), _MyTransform.position.y, _MyTransform.position.z);
            AnimPlayer.SetBool("Run", true);
        }
        else AnimPlayer.SetBool("Run", false);
    }
}