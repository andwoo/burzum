﻿using extensions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace viewmanager
{
  [RequireComponent(typeof(Canvas), /*typeof(CanvasScaler), */typeof(GraphicRaycaster))]
  public class ViewManager : MonoBehaviour
  {
    public static ViewManager instance { get; private set; }

    private IDictionary<int, Layer> _layers;
    private IDictionary<int, ViewInfo> _views;

    private void Awake()
    {
      Object.DontDestroyOnLoad(this);
      instance = this;
      _layers = new Dictionary<int, Layer>();
      _views = new Dictionary<int, ViewInfo>();
    }

    public void RegisterLayer(int id, string name)
    {
      GameObject viewContainer = new GameObject();
      RectTransform rect = viewContainer.AddComponent<RectTransform>();
      rect.SetAsStretch();
      /*rect.position = Vector3.zero;
      rect.rotation = Quaternion.identity;*/
      viewContainer.name = name;
      viewContainer.transform.SetParent(this.gameObject.transform, false);
      //set new layer as first child
      viewContainer.transform.SetAsLastSibling();
      _layers.Add(id, new Layer(viewContainer));
    }

    public void RegisterView(int viewId, int layerId, string prefabName)
    {
      RegisterView(viewId, layerId, prefabName, string.Empty);
    }

    public void RegisterView(int viewId, int layerId, string prefabName, string assetBundlePath)
    {
      _views.Add(viewId, new ViewInfo(viewId, layerId, prefabName, assetBundlePath));
    }

    public void PushView(int viewId)
    {
      PushView(viewId, null);
    }

    public void PushView(int viewId, object viewData)
    {
      //make sure the view is not already in the queue or currently active
      ViewInfo view = _views[viewId];
      if (!view.active)
      {
        _layers[view.layerId].PushView(view, viewData);
      }
    }

    public void PopView(int viewId)
    {
      ViewInfo view = _views[viewId];
      if (view.active)
      {
        _layers[view.layerId].PopView(view);
      }
    }
  }
}