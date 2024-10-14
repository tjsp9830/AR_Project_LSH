using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class KGA_ArFaceCtrl : MonoBehaviour
{
    // 한번 생성되어 메터리얼만 갈아울 하나의 프리팹에 직접 달아줄 스크립트


    public ARFace arFace;
    public MeshRenderer meshRenderer;
    public Material curMat;


    LSH_MaterialLoader metLoader;
    ARFaceManager faceManager;



    private void Awake()
    {
        Debug.Log(1);
        // 이 스크립트가 생성될 때에만 다음 컴포넌트를 찾아옴
        arFace = this.GetComponent<ARFace>();
        meshRenderer = this.GetComponent<MeshRenderer>();
        curMat = meshRenderer.materials[0];

    }

    private void Start()
    {
        Debug.Log(2);
        //셋필드 부분은 이해못해서 뺌

        //버튼 등록하기
        metLoader.MaterialButtonLeft();
        metLoader.MaterialButtonRight();


    }





}
