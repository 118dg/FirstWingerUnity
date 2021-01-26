using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BGScrollData
{
    public Renderer RenderForScroll;
    public float Speed;
    public float OffsetX;
}

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScroll();
    }

    void UpdateScroll()
    {
        for(int i = 0; i < ScrollDatas.Length; i++) //for-which 보다 for가 더 빠름. 모바일에서 구동 속도.
        {
            SetTextureOffset(ScrollDatas[i]);
        }
    }

    void SetTextureOffset(BGScrollData scrollData)
    {
        scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime; //deltaTime : frame 간 시간(sec) //초속 어느정도의 속도로 스크롤할지
        if (scrollData.OffsetX > 1) 
            scrollData.OffsetX = scrollData.OffsetX % 1.0f; //1 초과하지 않음

        Vector2 Offset = new Vector2(scrollData.OffsetX, 0);

        scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", Offset); //material의 SetTextureOffset함수에 대해 구글링해보기!!
    }
}
