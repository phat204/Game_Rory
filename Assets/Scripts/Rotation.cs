using UnityEngine;

public class Rotation : MonoBehaviour
{
    public static Rotation Instance { get; private set; }
    public float initRot, rotationSpeed, rotationDirectionChangeTime;
    public int rotationDirection;
    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    void Start() {
        initRot = 50f;
        rotationSpeed = initRot;
        rotationDirection = 1;
    }
    void Update() {
        if (Timer.Instance.isTiming) 
        {
            UpdateRot();
            RandomRot();
        } 
    }

    private void RandomRot() {
        rotationDirectionChangeTime += Time.deltaTime;
        if (rotationDirectionChangeTime >= Random.Range(5f, 7f)) {
            rotationDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            rotationDirectionChangeTime = 0;
        }
    }

    private void UpdateRot() {
        rotationSpeed = Mathf.Lerp(initRot, 200f, 1 - (Timer.Instance.timeLeft / Timer.Instance.gameDuration));
        transform.Rotate(0, 0, rotationSpeed * rotationDirection * Time.deltaTime);
    }
}
