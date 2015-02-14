﻿using blap.baseclasses.managers;
using blap.debug.utils;
using blap.debug.views;
using blap.root.views;
using strange.extensions.command.impl;
using UnityEngine;

namespace blap.root.commands
{
  class StartupCommand : Command
  {
    public override void Execute()
    {
      GameObject.Find("ContextView").GetComponent<RootContextView>().root.AddView(BlapViewManager.CreateBlapViewFromPrefab<DebugConsoleView>("console/DebugConsole"));
      Trace.Log("App Startup Complete");
    }
  }
}
