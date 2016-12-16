Imports System.Net
Public Class BSNetwork
    Public Enum IPProtocolType
        TCP = 1
        UDP = 2
        IPX = 3
        SPX = 4
    End Enum
    Private Function PortOpen(ByVal sHost As System.Net.IPAddress, ByVal iPort As Long, ByVal ProtocolType As IPProtocolType) As Boolean
        Dim bAns As Boolean = False
        Dim EPHost As New System.Net.IPEndPoint(sHost, iPort)
        Dim s As System.Net.Sockets.Socket = Nothing
        Dim IsUDP As Boolean = False
        Select Case ProtocolType
            Case IPProtocolType.TCP
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, _
                                                  System.Net.Sockets.SocketType.Stream, _
                                                  System.Net.Sockets.ProtocolType.Tcp)
            Case IPProtocolType.UDP
                IsUDP = True
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, _
                                                  System.Net.Sockets.SocketType.Dgram, _
                                                  System.Net.Sockets.ProtocolType.Udp)
            Case IPProtocolType.IPX
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, _
                                                  System.Net.Sockets.SocketType.Stream, _
                                                  System.Net.Sockets.ProtocolType.Ipx)
            Case IPProtocolType.SPX
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, _
                                                  System.Net.Sockets.SocketType.Stream, _
                                                  System.Net.Sockets.ProtocolType.Spx)
        End Select
        Try
            s.Connect(EPHost)
        Catch
        End Try
        If Not s.Connected Then
            bAns = False
        Else
            If Not IsUDP Then
                s.Disconnect(False)
            End If
            bAns = True
        End If
        Return bAns
    End Function
    Public Function PortIsUP(ByVal sHost As String, ByVal iPort As Long, Optional ByVal ProtocolType As IPProtocolType = IPProtocolType.TCP, Optional ByRef ErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim myHost As System.Net.IPAddress = System.Net.Dns.GetHostEntry(sHost).AddressList(0)
            bAns = PortOpen(myHost, iPort, ProtocolType)
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
        Return bAns
    End Function
End Class
