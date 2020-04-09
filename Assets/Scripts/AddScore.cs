using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private Text m_text;
    private Rigidbody2D ri;
    private float m_speed = 60;
    int m_status;
    int m_fontMax = 28;
    public static AddScore Instance { get; set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    struct m_pos1
    {
        public static Vector3 pos = new Vector3(0, 2.0f, 0);
        public static int fontSize = 0;
    }
    struct m_pos2
    {
        public static Vector3 pos = new Vector3(-3.2f, 4.3f, 0);
        public static int fontSize = 24;
    }
    struct m_pos3
    {
        public static Vector3 pos = new Vector3(-5.2f, 3.3f, 0);
        public static int fontSize = 10;
    }
    void Start()
    {
        m_text = GetComponent<Text>();
        ri = GetComponent<Rigidbody2D>();

    }
    public void _init()
    {
        m_text.text = "" + GameManager.instance.m_iAddScore;
        m_text.fontSize = 1;
        transform.position = m_pos1.pos;
        _AddNewVeloc(m_pos1.pos, m_pos2.pos, m_speed);
        m_status = 0;
        StartCoroutine(IncreateScore());
    }
    void _AddNewVeloc(Vector3 pos1, Vector3 pos2, float speed)
    {
        ri.AddForce(new Vector2((pos2.x - pos1.x) * speed, (pos2.y - pos1.y) * speed));
    }
    void _MovePos(Vector3 pos1, Vector3 pos2, int status)
    {
        if (transform.position.x < pos2.x)
        {
            //Debug.Log("_movePos");
            ri.velocity = new Vector2(0, 0);
            if(m_status == 0)
            {
                StartCoroutine(NextStatus());
            }
        }
        if (status == 0 && m_text.fontSize <= m_fontMax)
        {
            m_text.fontSize++;
        }
        if (status == 1 && m_text.fontSize >=0)
        {
            m_text.fontSize=-2;
        }
    }
    void Update()
    {
        if(m_status == 0)
        {
            _MovePos(m_pos1.pos, m_pos2.pos, 0);
        }
        if(m_status == 1)
        {
            _MovePos(m_pos2.pos, m_pos3.pos, 1);
        }
    }
    IEnumerator NextStatus()
    {
        yield return new WaitForSeconds(1);
        m_status = 1;
        _AddNewVeloc(m_pos2.pos, m_pos3.pos, m_speed);
    }
    IEnumerator IncreateScore()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.SetScore(GameManager.instance.m_iAddScore);
        GameManager.instance.m_iAddScore = 0;
    }
}
