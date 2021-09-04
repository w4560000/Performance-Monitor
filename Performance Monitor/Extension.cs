using System.Windows.Forms;

namespace Performance_Monitor
{
    internal static class Extension
    {
        /// <summary>
        /// 非同步委派更新UI
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeIfRequired(Control control, MethodInvoker action)
        {
            //在非當前執行緒內 使用委派
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}