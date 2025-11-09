using UnityEngine;
public class Goal : MonoBehaviour
{
    [SerializeField] bool isGoal1;

    private Rigidbody2D rb;
    [SerializeField] float floatSpeed = 1f; 
    [SerializeField] float floatHeight = 1.5f;

    private Vector2 startPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        rb.MovePosition(startPos + new Vector2(0, newY));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ConstManager.ballTag))
        {
            DataManager.instance.Goal(isGoal1);
            UIManager.instance.UpdateRatio();
        }
    }
}
