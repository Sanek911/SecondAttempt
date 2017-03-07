//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace SecondAttempt
//{
//    class vpn
//    {
//        public static string GetCurrentConnectoid()
//        {
//            return GetCurrentConnectoid(null);
//        }
//        public static string GetCurrentConnectoid(TextWriter Log)
//        {
//            if (Log != null) Log.WriteLine("\n----> In ConnectoidHelper::GetCurrentConnectoid");
//            uint dwSize = (uint)Marshal.SizeOf(typeof(RASCONN));
//            if (Log != null) Log.WriteLine("\tUsing struct size dwSize:" + dwSize.ToString());
//            uint count = 4;
//            uint statusCode = 0;
//            RASCONN[] connections = null;
//            while (true)
//            {
//                uint cb = checked(dwSize * count);
//                connections = new RASCONN[count];
//                connections[0].dwSize = dwSize;
//                statusCode = RasEnumConnections(connections, ref cb, ref count);
//                if (Log != null) Log.WriteLine("\tRasEnumConnections() returned count:" + count + " statusCode: " + statusCode + " cb:" + cb);
//                if (statusCode != ERROR_BUFFER_TOO_SMALL)
//                {
//                    break;
//                }
//                count = checked(cb + dwSize - 1) / dwSize;
//            }
//            if (count == 0 || statusCode != 0)
//            {
//                return null;
//            }
//            for (uint i = 0; i < count; i++)
//            {
//                if (Log != null)
//                {
//                    Log.WriteLine("\t-------- RASCONN ------------");
//                    Log.WriteLine("\tRASCONN[" + i + "]");
//                    Log.WriteLine("\tRASCONN[" + i + "].dwSize: " + connections//emoticons/emotion-55.gif" alt="Idea" />.dwSize);

//                    Log.WriteLine("\tRASCONN[" + i + "].hrasconn: " + connectionsIdea.hrasconn);
//                    Log.WriteLine("\tRASCONN[" + i + "].szEntryName: " + connectionsIdea.szEntryName);
//                    Log.WriteLine("\tRASCONN[" + i + "].szDeviceType: " + connectionsIdea.szDeviceType);
//                    Log.WriteLine("\tRASCONN[" + i + "].szDeviceName: " + connectionsIdea.szDeviceName);
//                }

//                RASCONNSTATUS connectionStatus = new RASCONNSTATUS();
//                connectionStatus.dwSize = (uint)Marshal.SizeOf(connectionStatus);
//                statusCode = RasGetConnectStatus(connectionsIdea.hrasconn, ref connectionStatus);
//                if (Log != null) Log.WriteLine("RasGetConnectStatus() returned statusCode: " + statusCode + " dwSize: " + connectionStatus.dwSize);
//                if (statusCode == 0)
//                {
//                    if (Log != null)
//                    {
//                        Log.WriteLine("\t\t-------- RASCONN Status ------------");
//                        Log.WriteLine("\t\tRSCONN[" + i + "].RASCONNSTATUS.dwSize: " + connectionStatus.dwSize);
//                        Log.WriteLine("\t\tRASCONN[" + i + "].RASCONNSTATUS.rasconnstate: " + connectionStatus.rasconnstate);
//                        Log.WriteLine("\t\tRASCONN[" + i + "].RASCONNSTATUS.dwError: " + connectionStatus.dwError);
//                        Log.WriteLine("\t\tRASCONN[" + i + "].RASCONNSTATUS.szDeviceType: " + connectionStatus.szDeviceType);
//                        Log.WriteLine("\t\tRASCONN[" + i + "].RASCONNSTATUS.szDeviceName: " + connectionStatus.szDeviceName);
//                    }
//                    if (connectionStatus.rasconnstate == RASCONNSTATE.RASCS_Connected)
//                    {
//                        if (Log != null) Log.WriteLine("r::GetCurrentConnectoid() called RasGetConnectStatus() statusCode: " + statusCode + " dwSize: " + connectionStatus.dwSize);
//                        return connectionsIdea.szEntryName;
//                    }
//                }
//                else
//                {
//                    if (Log != null)
//                    {
//                        Log.WriteLine("\t\tRasGetConnectStatus returned a statuscode: " + statusCode + " message " + RasErrors.ErrorMessage(statusCode));
//                    }

//                }
//            }

//            return null;
//        } //End of get current Connectoid


//        public struct RASCONN
//        {
//            internal uint dwSize;
//            internal IntPtr hrasconn;
//            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxEntryName + 1)]
//            internal string szEntryName;
//            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceType + 1)]
//            internal string szDeviceType;
//            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceName + 1)]
//            internal string szDeviceName;
//            /* None of these are supported on Windows 98.
//            MSDN lies twice: there is no dwSessionId at all, and szPhonebook and dwSubEntry are not on Win98.
//               [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAX_PATH)]
//               internal string szPhonebook;
//               internal uint dwSubEntry;
//               internal Guid guidEntry;
//               internal uint dwFlags;
//               internal ulong luid;
//            */
//        }

//        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
//        struct RASCONNSTATUS
//        {
//            internal uint dwSize;
//            internal RASCONNSTATE rasconnstate;
//            internal uint dwError;
//            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceType + 1)]
//            internal string szDeviceType;
//            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceName + 1)]
//            internal string szDeviceName;
//            /* Not supported on Windows 98.
//               [MarshalAs(UnmanagedType.ByValTStr, SizeConst=RAS_MaxPhoneNumber + 1)]
//               internal string szPhoneNumber;
//            */
//        }
//    }
//}
