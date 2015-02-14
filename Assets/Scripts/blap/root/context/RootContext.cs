﻿using blap.debug.commands;
using blap.debug.events;
using blap.debug.interfaces;
using blap.debug.mediators;
using blap.debug.models;
using blap.debug.views;
using blap.root.commands;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace blap.root.context
{
  class RootContext : MVCSContext
  {
    #region constructors
      public RootContext()
        : base()
      {
      }

      public RootContext(MonoBehaviour view)
        : base(view)
      {
      }

      public RootContext(MonoBehaviour view, bool autoMapping)
        : base(view, autoMapping)
      {
      }

      public RootContext(MonoBehaviour view, ContextStartupFlags flags)
        : base(view, flags)
      {
      }
    #endregion

    override protected void mapBindings()
    {
      MapViews();
      MapModels();
      MapServices();
      MapCommands();
      MapDebugCommands();
    }

    override protected void postBindings()
    {
    }

    private void MapViews()
    {
      #region debug_console
        mediationBinder.Bind<DebugConsoleView>().To<DebugConsoleMediator>();
      #endregion
    }

    private void MapModels()
    {
      #region debug_console
        ICommandContainer debugCommands = new CommandContainer();
        debugCommands.AddCommand("clr", DebugConsoleEvent.CLEAR_CONSOLE);
        debugCommands.AddCommand("clear", DebugConsoleEvent.CLEAR_CONSOLE);
        injectionBinder.Bind<ICommandContainer>().ToValue(debugCommands).ToSingleton();
      #endregion
    }

    private void MapServices()
    {
    }

    private void MapCommands()
    {
      #region startup
        commandBinder.Bind(ContextEvent.START).To<StartupCommand>();
      #endregion
    }

    private void MapDebugCommands()
    {
      #region debug_console
        commandBinder.Bind(DebugConsoleEvent.COMMAND_ENTERED).To<DebugRouteCommand>();
      #endregion

      #region debug_commands
      #endregion
    }
  }
}
