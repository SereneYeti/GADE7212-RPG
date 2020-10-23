using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;
using Vieyra1802490_ParsingPrototype;

public class UIController : MonoBehaviour
{
    #region Writer
    public GameObject pnlWriter;
    public TextMeshProUGUI outputText;
    public TMP_InputField userText;
    public Button Go;
    public Button Close;
    public TextMeshProUGUI txtGO;
    bool writerVis = false;
    #endregion

    #region Inventory
    public GameObject pnlInventory;
    public TextMeshProUGUI slot1;
    public TextMeshProUGUI slot2;
    public TextMeshProUGUI slot3;   
    #endregion

    #region Parser
    Parser parser = new Parser();
    #endregion

    #region Writer Vis
    public void OpenWriter()
    {
        writerVis = !writerVis;
        ChangeWriterVis(writerVis);
        UIManager.Instance.InWriter = writerVis;
    }

    public void CloseWriter()
    {
        writerVis = false;
        ChangeWriterVis(writerVis);
        UIManager.Instance.InWriter = writerVis;
    }

    void ChangeWriterVis(bool vis)
    {
        pnlWriter.SetActive(vis);
        outputText.gameObject.SetActive(vis);
        userText.gameObject.SetActive(vis);
        Go.gameObject.SetActive(vis);
        Close.gameObject.SetActive(vis);
        txtGO.gameObject.SetActive(vis);
    }
    #endregion
    public void GetText()
    {
        parser.inputText = userText.text;
        Debug.Log(userText.text);
        parser.Parse();
        outputText.text = parser.outputText;
        parser.RefreshInventory(slot1.text,slot2.text,slot3.text);
    }
    private void Start()
    {
        CloseWriter();
        parser.Start();
    }
}
