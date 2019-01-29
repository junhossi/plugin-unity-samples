using System.Collections.Generic;
using UnityEngine;
using PiXYZ.Plugin.Unity.Tools;
using System;

public class RunStaticMethod : ActionOut<IList<GameObject>> {

    [UserParameter]
    public DynamicEnum appDomain;

    [UserParameter]
    public DynamicEnum staticClass;

    [UserParameter]
    public DynamicEnum staticMethod;

    public override int id { get { return 4564532;} }
    public override string menuPathRuleEngine { get { return "Custom/Run Static Method"; } }
    public override string menuPathToolbox { get { return "Custom/Run Static Method";} }
    public override string tooltip { get { return "Run Static Method"; } }

    public override void onBeforeDraw() {
        base.onBeforeDraw();

        appDomain = new DynamicEnum();
        appDomain.Add("Option 1");
        appDomain.Add("Option 2");
        appDomain.Add("Option 3");

        staticClass = new DynamicEnum();
        staticClass.Add("Option 1");
        staticClass.Add("Option 2");
        staticClass.Add("Option 3");

        staticMethod = new DynamicEnum();
        staticMethod.Add("Option 1");
        staticMethod.Add("Option 2");
        staticMethod.Add("Option 3");
    }

    public override IList<GameObject> run() {
        
        return null;
    }
}