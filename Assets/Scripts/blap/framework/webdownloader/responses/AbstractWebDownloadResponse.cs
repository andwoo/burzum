﻿using UnityEngine;

namespace blap.framework.webdownloader.responses
{
  public abstract class AbstractWebDownloadResponse
  {
    public bool success { get; protected set; }
    public string downloadPath { get; private set; }
    public short httpErrorCode { get; private set; }
    public string httpErrorMessage { get; private set; }

    public AbstractWebDownloadResponse(WWW httpResponse, bool downloadSuccess, short errorCode, string errorMessage)
    {
      success = downloadSuccess;
      downloadPath = httpResponse.url;
      httpErrorCode = errorCode;
      httpErrorMessage = errorMessage;
    }
  }
}