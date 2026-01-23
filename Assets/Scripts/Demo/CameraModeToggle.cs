using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraModeToggle : MonoBehaviour
{
    [SerializeField]
    private bool m_EnableStereoRender = false;
    [SerializeField]
    private bool m_EnableAlternateEyeRender = false;

    [SerializeField]
    private GameObject m_2DCamera;
    [SerializeField]
    private GameObject m_StereoCameraL;
    [SerializeField]
    private GameObject m_StereoCameraR;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ToggleRenderMode();
        }

        if (m_StereoCameraL != null && m_StereoCameraR != null & m_2DCamera != null)
        {
            if (m_EnableStereoRender)
            {
                m_2DCamera.SetActive(false);
                m_2DCamera.tag = "Camera2D";

                m_StereoCameraL.SetActive(true);
                m_StereoCameraR.SetActive(true);
                m_StereoCameraR.tag = "MainCamera";
            }
            else
            {
                m_StereoCameraL.SetActive(false);
                m_StereoCameraR.SetActive(false);
                m_StereoCameraR.tag = "CameraR";

                m_2DCamera.SetActive(true);
                m_2DCamera.tag = "MainCamera";
            }
        }
    }

    public void ToggleRenderMode()
    {
        if (!m_EnableStereoRender && !m_EnableAlternateEyeRender)
        {
            m_EnableAlternateEyeRender = false;
            m_EnableStereoRender = true;
        }
        else if (m_EnableStereoRender)
        {
            m_EnableStereoRender = false;
            m_EnableAlternateEyeRender = true;
        }
        else if (m_EnableAlternateEyeRender)
        {
            m_EnableStereoRender = false;
            m_EnableAlternateEyeRender = false;
        }
    }

    public bool StereoRenderMode()
    {
        return m_EnableStereoRender;
    }

    public bool AlternateEyeRenderMode()
    {
        return m_EnableAlternateEyeRender;
    }
}
