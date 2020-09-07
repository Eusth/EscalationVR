using System;
using System.Runtime.InteropServices;
using System.Text;

namespace VRGIN.Native
{
	// Token: 0x02000092 RID: 146
	public class WindowsInterop
	{
		// Token: 0x06000267 RID: 615
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

		// Token: 0x06000268 RID: 616
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern uint GetWindowThreadProcessId(global::System.IntPtr hWnd, out uint lpdwProcessId);

		// Token: 0x06000269 RID: 617
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		[return: global::System.Runtime.InteropServices.MarshalAs(2)]
		public static extern bool EnumChildWindows(global::System.IntPtr parentHandle, global::VRGIN.Native.WindowsInterop.Win32Callback callback, global::System.IntPtr lParam);

		// Token: 0x0600026A RID: 618
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int ShowCursor(bool bShow);

		// Token: 0x0600026B RID: 619
		[global::System.Runtime.InteropServices.DllImport("USER32.dll", CallingConvention = 3)]
		public static extern void SetCursorPos(int X, int Y);

		// Token: 0x0600026C RID: 620
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		[return: global::System.Runtime.InteropServices.MarshalAs(2)]
		public static extern bool GetCursorPos(out global::VRGIN.Native.WindowsInterop.POINT lpMousePoint);

		// Token: 0x0600026D RID: 621
		[global::System.Runtime.InteropServices.DllImport("USER32.dll")]
		public static extern bool ClientToScreen(global::System.IntPtr hWnd, ref global::VRGIN.Native.WindowsInterop.POINT lpPoint);

		// Token: 0x0600026E RID: 622
		[global::System.Runtime.InteropServices.DllImport("user32.dll", CharSet = 4, SetLastError = true)]
		public static extern int GetWindowText(global::System.IntPtr hWnd, global::System.Text.StringBuilder lpString, int nMaxCount);

		// Token: 0x0600026F RID: 623
		[global::System.Runtime.InteropServices.DllImport("user32.dll", CharSet = 4, SetLastError = true)]
		public static extern int GetWindowTextLength(global::System.IntPtr hWnd);

		// Token: 0x06000270 RID: 624
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern global::System.IntPtr GetActiveWindow();

		// Token: 0x06000271 RID: 625
		[global::System.Runtime.InteropServices.DllImport("user32.dll", CharSet = 4, ExactSpelling = true)]
		[return: global::System.Runtime.InteropServices.MarshalAs(2)]
		public static extern bool ClipCursor(ref global::VRGIN.Native.WindowsInterop.RECT rcClip);

		// Token: 0x06000272 RID: 626
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		[return: global::System.Runtime.InteropServices.MarshalAs(2)]
		public static extern bool GetClipCursor(out global::VRGIN.Native.WindowsInterop.RECT rcClip);

		// Token: 0x06000273 RID: 627
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int GetForegroundWindow();

		// Token: 0x06000274 RID: 628
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		[return: global::System.Runtime.InteropServices.MarshalAs(2)]
		public static extern bool GetWindowRect(global::System.IntPtr hWnd, ref global::VRGIN.Native.WindowsInterop.RECT lpRect);

		// Token: 0x06000275 RID: 629
		[global::System.Runtime.InteropServices.DllImport("user32.dll")]
		[return: global::System.Runtime.InteropServices.MarshalAs(2)]
		public static extern bool GetClientRect(global::System.IntPtr hWnd, ref global::VRGIN.Native.WindowsInterop.RECT lpRect);

		// Token: 0x06000276 RID: 630
		[global::System.Runtime.InteropServices.DllImport("user32", CharSet = 2, ExactSpelling = true, SetLastError = true)]
		[return: global::System.Runtime.InteropServices.MarshalAs(2)]
		public static extern bool SetForegroundWindow(global::System.IntPtr hwnd);

		// Token: 0x020001EC RID: 492
		public struct POINT
		{
			// Token: 0x06000A37 RID: 2615 RVA: 0x00020B41 File Offset: 0x0001ED41
			public POINT(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}

			// Token: 0x0400074A RID: 1866
			public int X;

			// Token: 0x0400074B RID: 1867
			public int Y;
		}

		// Token: 0x020001ED RID: 493
		public struct RECT
		{
			// Token: 0x06000A38 RID: 2616 RVA: 0x00020B52 File Offset: 0x0001ED52
			public RECT(int left, int top, int right, int bottom)
			{
				this.Left = left;
				this.Top = top;
				this.Right = right;
				this.Bottom = bottom;
			}

			// Token: 0x0400074C RID: 1868
			public int Left;

			// Token: 0x0400074D RID: 1869
			public int Top;

			// Token: 0x0400074E RID: 1870
			public int Right;

			// Token: 0x0400074F RID: 1871
			public int Bottom;
		}

		// Token: 0x020001EE RID: 494
		[global::System.Flags]
		public enum MouseEventFlags
		{
			// Token: 0x04000751 RID: 1873
			LeftDown = 2,
			// Token: 0x04000752 RID: 1874
			LeftUp = 4,
			// Token: 0x04000753 RID: 1875
			MiddleDown = 32,
			// Token: 0x04000754 RID: 1876
			MiddleUp = 64,
			// Token: 0x04000755 RID: 1877
			Move = 1,
			// Token: 0x04000756 RID: 1878
			Absolute = 32768,
			// Token: 0x04000757 RID: 1879
			RightDown = 8,
			// Token: 0x04000758 RID: 1880
			RightUp = 16
		}

		// Token: 0x020001EF RID: 495
		// (Invoke) Token: 0x06000A3A RID: 2618
		public delegate bool Win32Callback(global::System.IntPtr hwnd, global::System.IntPtr lParam);
	}
}
