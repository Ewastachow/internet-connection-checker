using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace InternetConnectionChecker
{
    class DiagnozeWeb
    {

        public static bool PingHost(string ipAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(ipAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
            return pingable;
        }

        public static string PingResultString(string ipAddress)
        {
            DateTime localDate = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            sb.Append(localDate.ToString());
            if (DiagnozeWeb.PingHost(ipAddress))
                sb.Append(" ***** Succesfull *****");
            else
                sb.Append(" ------- Failure ------");
            sb.Append("  ping to ");
            sb.AppendLine(ipAddress);

            return sb.ToString();
        }

    }
}
