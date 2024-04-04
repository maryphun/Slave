using UnityEngine;

static class ApplicationStart
{
    // アプリ開始
    [RuntimeInitializeOnLoadMethod]
    static void ApplicationInitialization()
    {
        Application.targetFrameRate = 144;
    }
}
