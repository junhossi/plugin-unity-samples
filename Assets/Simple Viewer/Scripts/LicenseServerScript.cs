using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using PiXYZ.PiXYZImportScript;
using PiXYZ.Plugin.Unity;

public class LicenseServerScript : MonoBehaviour {

    public InputField address;
    public InputField port;
    public bool flexLM;
    public ErrorWinScript errorWindow;

    private void OnEnable()
    {
        if (Configuration.CurrentLicenseServer == null)
            return;
        if (address.text == "") { address.text = Configuration.CurrentLicenseServer.ServerAddress; flexLM = Configuration.CurrentLicenseServer.UseFlexLM; }
        if (port.text == "") { port.text = Configuration.CurrentLicenseServer.ServerPort.ToString(); flexLM = Configuration.CurrentLicenseServer.UseFlexLM; }
    }

    public void apply()
    {
        Configuration.ConfigureLicenseServer(address.text, ushort.Parse(port.text), flexLM);
    }
}
