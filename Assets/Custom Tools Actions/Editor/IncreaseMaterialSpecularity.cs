using System.Collections.Generic;
using UnityEngine;
using PiXYZ.Tools;

public class IncreaseMaterialSpecularity : ActionInOut<IList<Material>, IList<Material>> {

    [UserParameter]
    public float aFloatParameter = 1f;

    public override int id { get { return 13457840;} }
    public override string menuPathRuleEngine { get { return "Custom/Increase Material Specularity"; } }
    public override string menuPathToolbox { get { return "Custom/Increase Material Specularity"; } }
    public override string tooltip { get { return "Increase Material Specularity"; } }

    public override IList<Material> run(IList<Material> input) {
        /// Your code here
        return input;
    }
}