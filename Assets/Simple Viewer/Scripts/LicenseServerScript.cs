using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using PiXYZ.Config;

public class LicenseServerScript : MonoBehaviour {

    public InputField address;
    public InputField port;
    public bool flexLM;
    public ErrorWinScript errorWindow;

    private void OnEnable()
    {
        if (Configuration.CurrentLicenseServer == null)
            return;
        if (address.text == "") { address.text = Configuration.CurrentLicenseServer.serverAddress; flexLM = Configuration.CurrentLicenseServer.useFlexLM; }
        if (port.text == "") { port.text = Configuration.CurrentLicenseServer.serverPort.ToString(); flexLM = Configuration.CurrentLicenseServer.useFlexLM; }
    }

    public void apply()
    {
        Configuration.ConfigureLicenseServer(address.text, ushort.Parse(port.text), flexLM);
    }
}
