using System.ComponentModel;
using System.Drawing;

namespace WinFormMVC.Model

{
    public interface IController
    {
        void RefreshPictureBoxSorting();
        void UpdateFunctionTextBox(float xmin, float xmax, float ymin, float ymax);
        void RefreshPictureBoxFunction();
        void SetNewtonZero(float newtonZero);
        void SetBackgroundWorker(BackgroundWorker backgroundWorker);
    }
}
