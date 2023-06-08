using ServerCore;
using System;
using System.Collections.Generic;
using System.Text;


class PacketHandler
{

	public static void S_OkayLoginHandler(PacketSession session, IPacket packet)
    {
		S_OkayLogin pkt = packet as S_OkayLogin;
		ServerSession serverSession = session as ServerSession;
		adminpassword.canlogin = pkt.canLogin;
    }

	// 일별/월별 매출 요청했을 때
	public static void S_SalesInfoHandler(PacketSession session, IPacket packet)
    {
		S_SalesInfo pkt = packet as S_SalesInfo;
		ServerSession serverSession = session as ServerSession;
		SellerScript.netdata = pkt.sales_text;
		//pkt.sales_text
    }

	
}
