using TMPro;
using UnityEngine;

public class exam14 : MonoBehaviour
{
    public GameObject mTarget;
    public Plane myPlane;   //  게임 그래픽에서 가장 중요한 것이라고 함 ----> 평면 처리 

    public TMP_Text mInfoText;

    public void updatePlane(){
        myPlane = new Plane(transform.up,transform.position);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updatePlane();  
    }

    // Update is called once per frame
    void Update()
    {
        updatePlane();

        mTarget.transform.Rotate(0,0,-45 * Time.deltaTime); // 1초에 45도 만큼 회전 시킨다.

        Transform[] children = mTarget.GetComponentsInChildren<Transform>();    

        string _info = "";

        foreach(Transform child in children){
            float _dist = myPlane.GetDistanceToPoint(child.position);
            _info += $"child: {child.name} | dist:{_dist}";
            
            Renderer renderer = child.GetComponent<Renderer>();
            
            if(renderer != null){
                Material _meterial = renderer.material;
                Color color = new Color(1,1,1,1);

            if(_dist <5){
                color.r = _dist / 5;
                }
                _meterial.color = color;
            }
             mInfoText.text = _info;
        }
        
    }

    void OnDrawGizmos(){        // 평면에선 법선이 가장 중요 이걸 이용해서 거리? 를 알 수 있음
        Vector3 lineStart = transform.position;
        Vector3 lineEnd = transform.position + transform.up *5;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(lineStart, lineEnd);    
    }
}
