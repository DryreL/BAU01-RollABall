using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisements;

public class PlayerBallController : MonoBehaviour
{
    public float speedMultiplier = 5f;

    private Vector3 target;
    private float _moveHorizontal, _moveVertical;
    private Rigidbody myRgdbody;

    // Start is called before the first frame update
    void Start()
    {
        myRgdbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point + Vector3.up * .5f;
                StopCoroutine("MoveTo");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameObject.Destroy(other.gameObject);
        }

        // Increase score by 1
        // Add an extra life at 100 coin
    }

    IEnumerator MoveTo(Vector3 target, string message)
    {
        while ((Vector3.Distance(transform.position, target) > 0.5f))
        {
            //Not there yet
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
            yield return null;
        }
        //Debug.Log("I am idle now!");
        //yield return new WaitForSeconds(2f);
        //Debug.Log("Bekledim!");

        //StartCoroutine("ShowAdWhenReady");
    }

    /*
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady("video"))
        { // Not Ready yet
           yield return null;
        }
        Advertisement.Show();
    }
    */
}
