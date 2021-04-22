using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelector : MonoBehaviour
{
    public GameObject peoplecanvas;
    public GameObject foodcanvas;
    public GameObject nouncanvas;
    public GameObject prefixcanvas;
    public GameObject numberscanvas;
    public GameObject gemtriyacanvas;
    public GameObject connectorscanvas;
    public GameObject verbscanvas;

    public GameObject MainPanel;
    public GameObject Settings;

    string people = "PEOPLE";
    string food = "FOOD";
    string prefix = "PREFIX";
    string noun = "NOUN";
    string verbs = "VERBS";
    string numbers = "NUMBERS";
    string gematriya = "GEMATRIYA";
    string connectors = "CONNECTORS";

    private int peoplenumber;
    private int foodnumber;
    private int verbsnumber;
    private int connectorsnumber;
    private int nounnumber;
    private int numbersnumber;
    private int gematriyanumber;
    private int prefixnumber;
    private void Start()
    {
        peoplenumber = PlayerPrefs.GetInt("REFERENCEPEOPLE");
        foodnumber = PlayerPrefs.GetInt("REFERENCEFOOD");
        verbsnumber = PlayerPrefs.GetInt("REFERENCEVERBS");
        connectorsnumber = PlayerPrefs.GetInt("REFERENCECONNECTORS");
        nounnumber = PlayerPrefs.GetInt("REFERENCENOUN");
        numbersnumber = PlayerPrefs.GetInt("REFERENCENUMBERS");
        gematriyanumber = PlayerPrefs.GetInt("REFERENCEGEMATRIYA");
        prefixnumber = PlayerPrefs.GetInt("REFERENCEPREFIX");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            MainPanel.SetActive(true);
        }
    }
    public void People()
    {
        PlayerPrefs.SetString("REFERENCE", people);
        PlayerPrefs.SetInt("REFERENCENUMBER", peoplenumber);
    }

   public void Food ()
    {
        PlayerPrefs.SetString("REFERENCE", food);
        PlayerPrefs.SetInt("REFERENCENUMBER", foodnumber);
    }
    public void Noun()
    {
        PlayerPrefs.SetString("REFERENCE", noun);
        PlayerPrefs.SetInt("REFERENCENUMBER", nounnumber);
    }
    public void Prefix()
    {
        PlayerPrefs.SetString("REFERENCE", prefix);
        PlayerPrefs.SetInt("REFERENCENUMBER", prefixnumber);
    }
    public void Connectors()
    {
        PlayerPrefs.SetString("REFERENCE", connectors);
        PlayerPrefs.SetInt("REFERENCENUMBER", connectorsnumber);
    }
    public void Verbs()
    {
        PlayerPrefs.SetString("REFERENCE", verbs);
        PlayerPrefs.SetInt("REFERENCENUMBER", verbsnumber);
    }
    public void Numbers()
    {
        PlayerPrefs.SetString("REFERENCE", numbers);
        PlayerPrefs.SetInt("REFERENCENUMBER", numbersnumber);
    }
    public void GEMATRIYA()
    {
        PlayerPrefs.SetString("REFERENCE", gematriya);
        PlayerPrefs.SetInt("REFERENCENUMBER", gematriyanumber);
    }

    public void PEOPLECUSOPEN()
    {
       peoplecanvas.SetActive(true);
    }
    public void PEOPLECUSCLOSE()

    {
       peoplecanvas.SetActive(false);

    }
    public void FOODCUSOPEN()
    {        
       foodcanvas.SetActive(true);   
    }
    public void FOODCUSCLOSE()
    {
        foodcanvas.SetActive(false);
    }
    public void VERBSOPEN()
    {
        verbscanvas.SetActive(true);
    }
    public void VERBSCLOSE()
    {
        verbscanvas.SetActive(false);
    }
    public void NOUNOPEN()
    {
        nouncanvas.SetActive(true);
    }
    public void NOUNCLOSE()
    {
        nouncanvas.SetActive(false);
    }
    public void PREFIXOPEN()
    {
        prefixcanvas.SetActive(true);
    }
    public void PREFIXCLOSE()
    {
        prefixcanvas.SetActive(false);
    }
    public void CONNECTORSOPEN()
    {
        connectorscanvas.SetActive(true);
    }
    public void CONNECTORSCLOSE()
    {
        connectorscanvas.SetActive(false);
    }
    public void NUMBEROPEN()
    {
        numberscanvas.SetActive(true);
    }
    public void NUMBERCLOSE()
    {
        numberscanvas.SetActive(false);
    }
    public void GEMATRIYAOPEN()
    {
        gemtriyacanvas.SetActive(true);
    }
    public void GEMATRIYACLOSE()
    {
        gemtriyacanvas.SetActive(false);
    }
    public void MainPanelClose()
    {
        SceneManager.LoadScene("Main Menu (Desktop)");
    }

    //----------------------------------------------------------------------------------------------------------------

    public void SETTINGSOPEN()
    {
        Settings.SetActive(true);
    }
    public void SETTINGSCLOSE()
    {
        Settings.SetActive(false);
    }
}
