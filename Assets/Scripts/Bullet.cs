using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player hit!");
            GameManager.Instance.SubtractPoint();
        } else if (other.CompareTag("sao")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Sao hit!");
            GameManager.Instance.AddPoint();
        } else if (other.CompareTag("bom")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Bom hit!");
            GameManager.Instance.SubtractPoint();
        } else if (other.CompareTag("dong_ho")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Dong ho hit!");
            Timer.Instance.AddTime();
        } else if (other.CompareTag("bia_do_dan")) {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
