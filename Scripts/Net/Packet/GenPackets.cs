using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ServerCore;

public enum PacketID
{
	S_BroadcastEnterGame = 1,
	C_EnterGame = 2,
	C_Login = 3,
	S_OkayLogin = 4,
	S_PlayerList = 5,
	S_PlayerInfo = 6,
	C_PlayerInfo = 7,
	C_SalesInfo = 8,
	S_SalesInfo = 9,
	C_CollectMoney = 10,
	C_SupBeverage = 11,

}

public interface IPacket
{
	ushort Protocol { get; }
	void Read(ArraySegment<byte> segment);
	ArraySegment<byte> Write();
}


public class S_BroadcastEnterGame : IPacket
{
	public int playerId;

	public ushort Protocol { get { return (ushort)PacketID.S_BroadcastEnterGame; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.S_BroadcastEnterGame), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class C_EnterGame : IPacket
{
	public string password;

	public ushort Protocol { get { return (ushort)PacketID.C_EnterGame; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		ushort passwordLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		this.password = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, passwordLen);
		count += passwordLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.C_EnterGame), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		ushort passwordLen = (ushort)Encoding.Unicode.GetBytes(this.password, 0, this.password.Length, segment.Array, segment.Offset + count + sizeof(ushort));
		Array.Copy(BitConverter.GetBytes(passwordLen), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		count += passwordLen;

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class C_Login : IPacket
{
	public int playerId;
	public string password;

	public ushort Protocol { get { return (ushort)PacketID.C_Login; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
		ushort passwordLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		this.password = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, passwordLen);
		count += passwordLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.C_Login), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);
		ushort passwordLen = (ushort)Encoding.Unicode.GetBytes(this.password, 0, this.password.Length, segment.Array, segment.Offset + count + sizeof(ushort));
		Array.Copy(BitConverter.GetBytes(passwordLen), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		count += passwordLen;

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class S_OkayLogin : IPacket
{
	public bool canLogin;

	public ushort Protocol { get { return (ushort)PacketID.S_OkayLogin; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.canLogin = BitConverter.ToBoolean(segment.Array, segment.Offset + count);
		count += sizeof(bool);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.S_OkayLogin), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.canLogin), 0, segment.Array, segment.Offset + count, sizeof(bool));
		count += sizeof(bool);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class S_PlayerList : IPacket
{
	public class Player
	{
		public int playerId;
		public bool isSelf;
		public class Beverage
		{
			public string berName;
			public int cnt;
			public int price;

			public void Read(ArraySegment<byte> segment, ref ushort count)
			{
				ushort berNameLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
				count += sizeof(ushort);
				this.berName = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, berNameLen);
				count += berNameLen;
				this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
				count += sizeof(int);
				this.price = BitConverter.ToInt32(segment.Array, segment.Offset + count);
				count += sizeof(int);
			}

			public bool Write(ArraySegment<byte> segment, ref ushort count)
			{
				bool success = true;
				ushort berNameLen = (ushort)Encoding.Unicode.GetBytes(this.berName, 0, this.berName.Length, segment.Array, segment.Offset + count + sizeof(ushort));
				Array.Copy(BitConverter.GetBytes(berNameLen), 0, segment.Array, segment.Offset + count, sizeof(ushort));
				count += sizeof(ushort);
				count += berNameLen;
				Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
				count += sizeof(int);
				Array.Copy(BitConverter.GetBytes(this.price), 0, segment.Array, segment.Offset + count, sizeof(int));
				count += sizeof(int);
				return success;
			}
		}
		public List<Beverage> beverages = new List<Beverage>();
		public class Money
		{
			public int unit;
			public int cnt;

			public void Read(ArraySegment<byte> segment, ref ushort count)
			{
				this.unit = BitConverter.ToInt32(segment.Array, segment.Offset + count);
				count += sizeof(int);
				this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
				count += sizeof(int);
			}

			public bool Write(ArraySegment<byte> segment, ref ushort count)
			{
				bool success = true;
				Array.Copy(BitConverter.GetBytes(this.unit), 0, segment.Array, segment.Offset + count, sizeof(int));
				count += sizeof(int);
				Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
				count += sizeof(int);
				return success;
			}
		}
		public List<Money> moneys = new List<Money>();

		public void Read(ArraySegment<byte> segment, ref ushort count)
		{
			this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
			this.isSelf = BitConverter.ToBoolean(segment.Array, segment.Offset + count);
			count += sizeof(bool);
			this.beverages.Clear();
			ushort beverageLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
			count += sizeof(ushort);
			for (int i = 0; i < beverageLen; i++)
			{
				Beverage beverage = new Beverage();
				beverage.Read(segment, ref count);
				beverages.Add(beverage);
			}
			this.moneys.Clear();
			ushort moneyLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
			count += sizeof(ushort);
			for (int i = 0; i < moneyLen; i++)
			{
				Money money = new Money();
				money.Read(segment, ref count);
				moneys.Add(money);
			}
		}

		public bool Write(ArraySegment<byte> segment, ref ushort count)
		{
			bool success = true;
			Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			Array.Copy(BitConverter.GetBytes(this.isSelf), 0, segment.Array, segment.Offset + count, sizeof(bool));
			count += sizeof(bool);
			Array.Copy(BitConverter.GetBytes((ushort)this.beverages.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
			count += sizeof(ushort);
			foreach (Beverage beverage in this.beverages)
				beverage.Write(segment, ref count);
			Array.Copy(BitConverter.GetBytes((ushort)this.moneys.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
			count += sizeof(ushort);
			foreach (Money money in this.moneys)
				money.Write(segment, ref count);
			return success;
		}
	}
	public List<Player> players = new List<Player>();

	public ushort Protocol { get { return (ushort)PacketID.S_PlayerList; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.players.Clear();
		ushort playerLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		for (int i = 0; i < playerLen; i++)
		{
			Player player = new Player();
			player.Read(segment, ref count);
			players.Add(player);
		}
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.S_PlayerList), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)this.players.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		foreach (Player player in this.players)
			player.Write(segment, ref count);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class S_PlayerInfo : IPacket
{
	public int playerId;
	public class Beverage
	{
		public string berName;
		public int cnt;
		public int price;

		public void Read(ArraySegment<byte> segment, ref ushort count)
		{
			ushort berNameLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
			count += sizeof(ushort);
			this.berName = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, berNameLen);
			count += berNameLen;
			this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
			this.price = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
		}

		public bool Write(ArraySegment<byte> segment, ref ushort count)
		{
			bool success = true;
			ushort berNameLen = (ushort)Encoding.Unicode.GetBytes(this.berName, 0, this.berName.Length, segment.Array, segment.Offset + count + sizeof(ushort));
			Array.Copy(BitConverter.GetBytes(berNameLen), 0, segment.Array, segment.Offset + count, sizeof(ushort));
			count += sizeof(ushort);
			count += berNameLen;
			Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			Array.Copy(BitConverter.GetBytes(this.price), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			return success;
		}
	}
	public List<Beverage> beverages = new List<Beverage>();
	public class Money
	{
		public int unit;
		public int cnt;

		public void Read(ArraySegment<byte> segment, ref ushort count)
		{
			this.unit = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
			this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
		}

		public bool Write(ArraySegment<byte> segment, ref ushort count)
		{
			bool success = true;
			Array.Copy(BitConverter.GetBytes(this.unit), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			return success;
		}
	}
	public List<Money> moneys = new List<Money>();

	public ushort Protocol { get { return (ushort)PacketID.S_PlayerInfo; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
		this.beverages.Clear();
		ushort beverageLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		for (int i = 0; i < beverageLen; i++)
		{
			Beverage beverage = new Beverage();
			beverage.Read(segment, ref count);
			beverages.Add(beverage);
		}
		this.moneys.Clear();
		ushort moneyLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		for (int i = 0; i < moneyLen; i++)
		{
			Money money = new Money();
			money.Read(segment, ref count);
			moneys.Add(money);
		}
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.S_PlayerInfo), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);
		Array.Copy(BitConverter.GetBytes((ushort)this.beverages.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		foreach (Beverage beverage in this.beverages)
			beverage.Write(segment, ref count);
		Array.Copy(BitConverter.GetBytes((ushort)this.moneys.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		foreach (Money money in this.moneys)
			money.Write(segment, ref count);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class C_PlayerInfo : IPacket
{
	public int playerId;
	public bool isSelf;
	public class Beverage
	{
		public string berName;
		public int cnt;
		public int price;

		public void Read(ArraySegment<byte> segment, ref ushort count)
		{
			ushort berNameLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
			count += sizeof(ushort);
			this.berName = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, berNameLen);
			count += berNameLen;
			this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
			this.price = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
		}

		public bool Write(ArraySegment<byte> segment, ref ushort count)
		{
			bool success = true;
			ushort berNameLen = (ushort)Encoding.Unicode.GetBytes(this.berName, 0, this.berName.Length, segment.Array, segment.Offset + count + sizeof(ushort));
			Array.Copy(BitConverter.GetBytes(berNameLen), 0, segment.Array, segment.Offset + count, sizeof(ushort));
			count += sizeof(ushort);
			count += berNameLen;
			Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			Array.Copy(BitConverter.GetBytes(this.price), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			return success;
		}
	}
	public List<Beverage> beverages = new List<Beverage>();
	public class Money
	{
		public int unit;
		public int cnt;

		public void Read(ArraySegment<byte> segment, ref ushort count)
		{
			this.unit = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
			this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
		}

		public bool Write(ArraySegment<byte> segment, ref ushort count)
		{
			bool success = true;
			Array.Copy(BitConverter.GetBytes(this.unit), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			return success;
		}
	}
	public List<Money> moneys = new List<Money>();

	public ushort Protocol { get { return (ushort)PacketID.C_PlayerInfo; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
		this.isSelf = BitConverter.ToBoolean(segment.Array, segment.Offset + count);
		count += sizeof(bool);
		this.beverages.Clear();
		ushort beverageLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		for (int i = 0; i < beverageLen; i++)
		{
			Beverage beverage = new Beverage();
			beverage.Read(segment, ref count);
			beverages.Add(beverage);
		}
		this.moneys.Clear();
		ushort moneyLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		for (int i = 0; i < moneyLen; i++)
		{
			Money money = new Money();
			money.Read(segment, ref count);
			moneys.Add(money);
		}
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.C_PlayerInfo), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);
		Array.Copy(BitConverter.GetBytes(this.isSelf), 0, segment.Array, segment.Offset + count, sizeof(bool));
		count += sizeof(bool);
		Array.Copy(BitConverter.GetBytes((ushort)this.beverages.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		foreach (Beverage beverage in this.beverages)
			beverage.Write(segment, ref count);
		Array.Copy(BitConverter.GetBytes((ushort)this.moneys.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		foreach (Money money in this.moneys)
			money.Write(segment, ref count);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class C_SalesInfo : IPacket
{
	public int playerId;
	public int beverageId;

	public ushort Protocol { get { return (ushort)PacketID.C_SalesInfo; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
		this.beverageId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.C_SalesInfo), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);
		Array.Copy(BitConverter.GetBytes(this.beverageId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class S_SalesInfo : IPacket
{
	public string sales_text;

	public ushort Protocol { get { return (ushort)PacketID.S_SalesInfo; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		ushort sales_textLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		this.sales_text = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, sales_textLen);
		count += sales_textLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.S_SalesInfo), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		ushort sales_textLen = (ushort)Encoding.Unicode.GetBytes(this.sales_text, 0, this.sales_text.Length, segment.Array, segment.Offset + count + sizeof(ushort));
		Array.Copy(BitConverter.GetBytes(sales_textLen), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		count += sales_textLen;

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class C_CollectMoney : IPacket
{
	public int playerId;
	public class Money
	{
		public int unit;
		public int cnt;

		public void Read(ArraySegment<byte> segment, ref ushort count)
		{
			this.unit = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
			this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
		}

		public bool Write(ArraySegment<byte> segment, ref ushort count)
		{
			bool success = true;
			Array.Copy(BitConverter.GetBytes(this.unit), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			return success;
		}
	}
	public List<Money> moneys = new List<Money>();

	public ushort Protocol { get { return (ushort)PacketID.C_CollectMoney; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
		this.moneys.Clear();
		ushort moneyLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		for (int i = 0; i < moneyLen; i++)
		{
			Money money = new Money();
			money.Read(segment, ref count);
			moneys.Add(money);
		}
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.C_CollectMoney), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);
		Array.Copy(BitConverter.GetBytes((ushort)this.moneys.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		foreach (Money money in this.moneys)
			money.Write(segment, ref count);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}

public class C_SupBeverage : IPacket
{
	public int playerId;
	public class Beverage
	{
		public string berName;
		public int cnt;
		public int price;

		public void Read(ArraySegment<byte> segment, ref ushort count)
		{
			ushort berNameLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
			count += sizeof(ushort);
			this.berName = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, berNameLen);
			count += berNameLen;
			this.cnt = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
			this.price = BitConverter.ToInt32(segment.Array, segment.Offset + count);
			count += sizeof(int);
		}

		public bool Write(ArraySegment<byte> segment, ref ushort count)
		{
			bool success = true;
			ushort berNameLen = (ushort)Encoding.Unicode.GetBytes(this.berName, 0, this.berName.Length, segment.Array, segment.Offset + count + sizeof(ushort));
			Array.Copy(BitConverter.GetBytes(berNameLen), 0, segment.Array, segment.Offset + count, sizeof(ushort));
			count += sizeof(ushort);
			count += berNameLen;
			Array.Copy(BitConverter.GetBytes(this.cnt), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			Array.Copy(BitConverter.GetBytes(this.price), 0, segment.Array, segment.Offset + count, sizeof(int));
			count += sizeof(int);
			return success;
		}
	}
	public List<Beverage> beverages = new List<Beverage>();

	public ushort Protocol { get { return (ushort)PacketID.C_SupBeverage; } }

	public void Read(ArraySegment<byte> segment)
	{
		ushort count = 0;
		count += sizeof(ushort);
		count += sizeof(ushort);
		this.playerId = BitConverter.ToInt32(segment.Array, segment.Offset + count);
		count += sizeof(int);
		this.beverages.Clear();
		ushort beverageLen = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
		count += sizeof(ushort);
		for (int i = 0; i < beverageLen; i++)
		{
			Beverage beverage = new Beverage();
			beverage.Read(segment, ref count);
			beverages.Add(beverage);
		}
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.C_SupBeverage), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes(this.playerId), 0, segment.Array, segment.Offset + count, sizeof(int));
		count += sizeof(int);
		Array.Copy(BitConverter.GetBytes((ushort)this.beverages.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		foreach (Beverage beverage in this.beverages)
			beverage.Write(segment, ref count);

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}
}
