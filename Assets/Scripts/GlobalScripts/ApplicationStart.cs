using UnityEngine;

static class ApplicationStart
{
    // �A�v���J�n
    [RuntimeInitializeOnLoadMethod]
    static void ApplicationInitialization()
    {
        Application.targetFrameRate = 144;
    }
}
