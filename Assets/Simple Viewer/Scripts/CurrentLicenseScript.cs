using UnityEngine;
using UnityEngine.UI;
using PiXYZ.Plugin.Unity;

public class CurrentLicenseScript : MonoBehaviour
{
    public Text infoText;
    public Text detailText;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(infoText != null)
        {
            if (Configuration.IsLicenseValid())
            {
                detailText.text = "";
                infoText.text = "";
                infoText.color = Color.black;
                infoText.fontSize = 14;
                infoText.alignment = TextAnchor.MiddleLeft;
                string[] names;
                string[] values;
                if (Configuration.IsFloatingLicense())
                {
                    Configuration.RetrieveFloatingLicensingSetup();
                    names = new string[]{
                        "License",
                        "",
                        "Server address",
                        "Port"
                    };
                    values = new string[] {
                        "Floating",
                        "",
                        Configuration.CurrentLicenseServer.ServerAddress,
                        Configuration.CurrentLicenseServer.ServerPort.ToString()
                    };
                }
                else
                {
                    names = new string[]{
                        "Start date",
                        "End date",
                        "Company name",
                        "Name",
                        "E-mail"
                    };
                    Configuration.RetrieveCurrentLicense();
                    values = new string[] {
                        Configuration.CurrentLicense.StartDate.ToString("yy-MM-dd"),
                        Configuration.CurrentLicense.EndDate.ToString("yy-MM-dd"),
                        Configuration.CurrentLicense.CustomerCompany,
                        Configuration.CurrentLicense.CustomerName,
                        Configuration.CurrentLicense.CustomerEmail,
                    };
                }

                for (int i = 0; i < names.Length; ++i)
                {
                    infoText.text += names[i] + (names[i].Length > 0 ? ":\n" : "\n");
                    detailText.text += values[i] + "\n";
                }
            }
            else
            {
                infoText.text = "Your license is inexistant or invalid.";
                infoText.color = Color.red;
                infoText.fontSize = 18;
                infoText.alignment = TextAnchor.MiddleCenter;
            }
        }
	}
}
