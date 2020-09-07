using System;
using System.IO;

namespace VRGIN.Helpers
{
	// Token: 0x020000CF RID: 207
	public class JSONData : global::VRGIN.Helpers.JSONNode
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0001A148 File Offset: 0x00018348
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x0001A160 File Offset: 0x00018360
		public override string Value
		{
			get
			{
				return this.m_Data;
			}
			set
			{
				this.m_Data = value;
				this.Tag = global::VRGIN.Helpers.JSONBinaryTag.Value;
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0001A172 File Offset: 0x00018372
		public JSONData(string aData)
		{
			this.m_Data = aData;
			this.Tag = global::VRGIN.Helpers.JSONBinaryTag.Value;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0001A18B File Offset: 0x0001838B
		public JSONData(float aData)
		{
			this.AsFloat = aData;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0001A19D File Offset: 0x0001839D
		public JSONData(double aData)
		{
			this.AsDouble = aData;
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0001A1AF File Offset: 0x000183AF
		public JSONData(bool aData)
		{
			this.AsBool = aData;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001A1C1 File Offset: 0x000183C1
		public JSONData(int aData)
		{
			this.AsInt = aData;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0001A1D4 File Offset: 0x000183D4
		public override string ToString()
		{
			return "\"" + global::VRGIN.Helpers.JSONNode.Escape(this.m_Data) + "\"";
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0001A200 File Offset: 0x00018400
		public override string ToString(string aPrefix)
		{
			return "\"" + global::VRGIN.Helpers.JSONNode.Escape(this.m_Data) + "\"";
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0001A22C File Offset: 0x0001842C
		public override string ToJSON(int prefix)
		{
			switch (this.Tag)
			{
			case global::VRGIN.Helpers.JSONBinaryTag.Value:
				return string.Format("\"{0}\"", global::VRGIN.Helpers.JSONNode.Escape(this.m_Data));
			case global::VRGIN.Helpers.JSONBinaryTag.IntValue:
			case global::VRGIN.Helpers.JSONBinaryTag.DoubleValue:
			case global::VRGIN.Helpers.JSONBinaryTag.FloatValue:
				return this.m_Data;
			}
			throw new global::System.NotSupportedException("This shouldn't be here: " + this.Tag.ToString());
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001A2A8 File Offset: 0x000184A8
		public override void Serialize(global::System.IO.BinaryWriter aWriter)
		{
			global::VRGIN.Helpers.JSONData jsondata = new global::VRGIN.Helpers.JSONData("");
			jsondata.AsInt = this.AsInt;
			bool flag = jsondata.m_Data == this.m_Data;
			if (flag)
			{
				aWriter.Write(4);
				aWriter.Write(this.AsInt);
			}
			else
			{
				jsondata.AsFloat = this.AsFloat;
				bool flag2 = jsondata.m_Data == this.m_Data;
				if (flag2)
				{
					aWriter.Write(7);
					aWriter.Write(this.AsFloat);
				}
				else
				{
					jsondata.AsDouble = this.AsDouble;
					bool flag3 = jsondata.m_Data == this.m_Data;
					if (flag3)
					{
						aWriter.Write(5);
						aWriter.Write(this.AsDouble);
					}
					else
					{
						jsondata.AsBool = this.AsBool;
						bool flag4 = jsondata.m_Data == this.m_Data;
						if (flag4)
						{
							aWriter.Write(6);
							aWriter.Write(this.AsBool);
						}
						else
						{
							aWriter.Write(3);
							aWriter.Write(this.m_Data);
						}
					}
				}
			}
		}

		// Token: 0x04000658 RID: 1624
		private string m_Data;
	}
}
