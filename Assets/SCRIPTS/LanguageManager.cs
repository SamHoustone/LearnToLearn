using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    public TextMeshProUGUI Play;
    public TextMeshProUGUI PlayH;
    public TextMeshProUGUI Settings;
    public TextMeshProUGUI SettingsH;
    public TextMeshProUGUI Exit;
    public TextMeshProUGUI ExitH;

    void Update()
    {
        if (PlayerPrefs.GetString("LANGUAGE") == "English")
        {
            Play.text = PlayH.text = "PLAY";
            Settings.text = SettingsH.text = "SETTINGS";
            Exit.text = ExitH.text = "EXIT";

        }
        if (PlayerPrefs.GetString("LANGUAGE") == "French")
        {
            Play.text = PlayH.text = "JOUER";
            Settings.text = SettingsH.text = "LES PARAMÈTRES";
            Exit.text = ExitH.text = "SORTIR";
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "Russian")
        {
            Play.text = PlayH.text = "ИГРАТЬ";
            Settings.text = SettingsH.text = "НАСТРОЙКИ";
            Exit.text = ExitH.text = "ВЫХОД";
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "Spanish")
        {
            Play.text = PlayH.text = "TOCAR";
            Settings.text = SettingsH.text = "AJUSTES";
            Exit.text = ExitH.text = "SALIDA";
        }
        if (PlayerPrefs.GetString("LANGUAGE") == "Yiddish")
        {
            Play.text = PlayH.text = "שפּיל";
            Settings.text = SettingsH.text = "באַשטעטיקן";
            Exit.text = ExitH.text = "אַרויסגאַנג";
        }
    }
}
