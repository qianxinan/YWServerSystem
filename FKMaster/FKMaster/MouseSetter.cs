using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FKMaster
{
    class MouseSetter
    {
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        /// <summary>
        /// 移动鼠标到指定的坐标点
        /// </summary>
        public static void MoveMouseToPoint(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }
        /// <summary>
        /// 设置鼠标的移动范围
        /// </summary>
        public static void SetMouseRectangle(Rectangle rectangle)
        {
            System.Windows.Forms.Cursor.Clip = rectangle;
        }
        /// <summary>
        /// 设置鼠标位于屏幕中心
        /// </summary>
        public static void SetMouseAtCenterScreen()
        {
            int winHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int winWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            Point centerP = new Point(winWidth / 2, winHeight / 2);
            MoveMouseToPoint(centerP);
        }
    }
}
