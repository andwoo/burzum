﻿namespace Burzum.Net
{
  public class PostRequest : AbstractHttpRequest
  {
    public PostRequest(string url, string postData, bool isJsonPostData, bool cacheBust, float timeOutLimit, short retryLimit, OnGetRequestSuccessHandler onSuccessHandler, OnGetRequestFailedHandler onFailHandler)
      : base(url, postData, isJsonPostData, cacheBust, timeOutLimit, retryLimit, onSuccessHandler, onFailHandler)
    { }
  }
}
