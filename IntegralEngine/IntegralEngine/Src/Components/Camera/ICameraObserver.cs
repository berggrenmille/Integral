using IntegralEngine.Messaging;

namespace IntegralEngine
{
    public interface ICameraObserver
    {
        void OnCameraRender();
        void OnCameraChange();
    }
}