using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject purple_0;
    [SerializeField] private float forceBuild = 20f;
    [SerializeField] private float maximumHoldTime = 5f;
        //snelheid waarmee de lijn groeit
    [SerializeField] private float lineSpeed = 10f;
    //verwijzing naar de linerenderer
    private LineRenderer _line;
    //we houden hiermee bij of de lijn actief is of niet
    private bool _lineActive = false;

    private float _pressTimer = 0f;
    private float _launchForce = 0f;

    private void Update()
    {
        HandleShot();
    }
    private void HandleShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0;
             _lineActive = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;

            GameObject ball = Instantiate(purple_0, transform.parent);

            ball.transform.rotation = transform.rotation;

            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);

            ball.transform.position = transform.position;
      
             _lineActive = false;
            _line.SetPosition(1, Vector3.zero);     
        }
                if(_pressTimer < maximumHoldTime)
        {

            _pressTimer += Time.deltaTime;
        }
         if (_lineActive) {
            _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }
    }

     private void Start()
 {
    //we vragen het Line Renderer component op en slaan deze op in een variabele zodat we er later dingen mee kunnen doen
     _line = GetComponent<LineRenderer>();
     //We pakken het eindpunt van de lijn en zetten deze op positie 0,0,0 (zelfde plek als het beginpunt). Hierdoor word de lijn onzichtbaar. Punt 0 is het beginpunt en punt 1 het eindpunt.
     _line.SetPosition(0,Vector3.zero);
     //_line.SetPosition(0,Vector3.one); zou het beginpunt aanpassen. Maar dat is niet nodig nu.

    if (Input.GetMouseButtonDown(0))
    {
        _pressTimer = 0f;
        _lineActive = true;
        _lineActive = false;
        _line.SetPosition(1, Vector3.zero);
    }
     if (_lineActive) {
        _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
    }
 }
}