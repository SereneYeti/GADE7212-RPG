using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;

public class UIController : MonoBehaviour
{
    #region Writer
    public GameObject panel;
    public TextMeshProUGUI outputText;
    public TMP_InputField userText;
    public Button Go;
    public Button Close;
    public TextMeshProUGUI txtGO;
    bool writerVis = false;
    #endregion

    #region Writer Vis
    public void OpenWriter()
    {
        writerVis = !writerVis;
        ChangeWriterVis(writerVis);
    }

    public void CloseWriter()
    {
        writerVis = false;
        ChangeWriterVis(writerVis);
    }

    void ChangeWriterVis(bool vis)
    {
        panel.SetActive(vis);
        outputText.gameObject.SetActive(vis);
        userText.gameObject.SetActive(vis);
        Go.gameObject.SetActive(vis);
        Close.gameObject.SetActive(vis);
        txtGO.gameObject.SetActive(vis);
    }
    #endregion

    private void Start()
    {
        CloseWriter();
    }
}
