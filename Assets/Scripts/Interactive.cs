using UnityEngine;
public class Interactive : MonoBehaviour
{

    Ray _ray;
    RaycastHit _hit;
    [SerializeField] Camera fpscamera;
    Animator anim;
    public float dmg = 20f;
    public GameManager manager;
    public float maxdistance = 2f;
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {
       //for center raycast
        _ray = fpscamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Mine();
        manager.SetPause();
        manager.GameWin();
        manager.GameOver();
    }
    void Mine()
    {
        if (Physics.Raycast(_ray, out _hit, maxdistance))
        {
            if (_hit.transform.tag == "core" || _hit.transform.tag == "gold")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _hit.transform.gameObject.GetComponent<healthbox>().ps.GetComponent<ParticleSystem>().Play();
                    anim.SetTrigger("Attack");
                    _hit.transform.gameObject.GetComponent<healthbox>().hp -= dmg;
                }
            }
        }
    }
}
