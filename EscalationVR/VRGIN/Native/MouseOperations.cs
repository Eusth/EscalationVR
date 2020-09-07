using System;

namespace VRGIN.Native
{
	// Token: 0x02000090 RID: 144
	public class MouseOperations
	{
		// Token: 0x06000257 RID: 599 RVA: 0x0000EF1A File Offset: 0x0000D11A
		public static void SetCursorPosition(int X, int Y)
		{
			global::VRGIN.Native.WindowsInterop.SetCursorPos(X, Y);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000EF28 File Offset: 0x0000D128
		public static void SetClientCursorPosition(int x, int y)
		{
			global::VRGIN.Native.WindowsInterop.RECT clientRect = global::VRGIN.Native.WindowManager.GetClientRect();
			global::VRGIN.Native.WindowsInterop.SetCursorPos(x + clientRect.Left, y + clientRect.Top);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000EF54 File Offset: 0x0000D154
		public static global::VRGIN.Native.WindowsInterop.POINT GetClientCursorPosition()
		{
			global::VRGIN.Native.WindowsInterop.POINT cursorPosition = global::VRGIN.Native.MouseOperations.GetCursorPosition();
			global::VRGIN.Native.WindowsInterop.RECT clientRect = global::VRGIN.Native.WindowManager.GetClientRect();
			return new global::VRGIN.Native.WindowsInterop.POINT(cursorPosition.X - clientRect.Left, cursorPosition.Y - clientRect.Top);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000EF91 File Offset: 0x0000D191
		public static void SetCursorPosition(global::VRGIN.Native.WindowsInterop.POINT point)
		{
			global::VRGIN.Native.WindowsInterop.SetCursorPos(point.X, point.Y);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000EFA8 File Offset: 0x0000D1A8
		public static global::VRGIN.Native.WindowsInterop.POINT GetCursorPosition()
		{
			global::VRGIN.Native.WindowsInterop.POINT result;
			bool cursorPos = global::VRGIN.Native.WindowsInterop.GetCursorPos(out result);
			bool flag = !cursorPos;
			if (flag)
			{
				result = new global::VRGIN.Native.WindowsInterop.POINT(0, 0);
			}
			return result;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
		public static void MouseEvent(global::VRGIN.Native.WindowsInterop.MouseEventFlags value)
		{
			global::VRGIN.Native.WindowsInterop.POINT cursorPosition = global::VRGIN.Native.MouseOperations.GetCursorPosition();
			global::VRGIN.Native.WindowsInterop.mouse_event((int)value, cursorPosition.X, cursorPosition.Y, 0, 0);
		}
	}
}
