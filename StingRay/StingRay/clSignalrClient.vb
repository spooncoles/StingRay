Imports Microsoft.AspNet.SignalR.Client.Hubs
Imports Microsoft.AspNet.SignalR
Public Class clSignalrClient
    Dim connection = New HubConnection("http://localhost:8080")
    Dim myHub = connection.CreateHubProxy("myHub")

    'Sub Main()

    '    connection.Start().Wait()
    '    Console.ForegroundColor = ConsoleColor.Yellow
    '    'myHub.Invoke(Of String)("chatter", "Dean Coles - Logged In")
    '    myHub.Invoke(Of String)("userLogIn", "Dean Coles")
    '    'myHub.Invoke(Of String)("chatter", "Hi!! Server") _
    '    '.ContinueWith(
    '    '    Sub(task)
    '    '        If task.IsFaulted Then
    '    '            Console.WriteLine("Could not Invoke the server method Chatter: {0}", _
    '    '                              task.Exception.GetBaseException())
    '    '        Else
    '    '            Console.WriteLine("Success calling chatter method")
    '    '        End If
    '    '    End Sub)

    '    myHub.On(Of String)("addMessage", _
    '        Sub(param)
    '            Console.WriteLine("Client receiving value from server: {0}", param.ToString())
    '        End Sub)
    '    myHub.On(Of String)("sendMessage", _
    '        Sub(param)
    '            Console.WriteLine(param.ToString())
    '        End Sub)
    '    Console.ReadLine()
    'End Sub

    Sub sendMessage(msg As String)
        myHub.Invoke(Of String)("userLogIn", "Dean Coles")
    End Sub

    Public Sub New()
        connection.Start().Wait()
        'Console.ForegroundColor = ConsoleColor.Yellow
        'myHub.Invoke(Of String)("chatter", "Dean Coles - Logged In")
        myHub.Invoke(Of String)("userLogIn", "Dean Coles")
        'myHub.Invoke(Of String)("chatter", "Hi!! Server") _
        '.ContinueWith(
        '    Sub(task)
        '        If task.IsFaulted Then
        '            Console.WriteLine("Could not Invoke the server method Chatter: {0}", _
        '                              task.Exception.GetBaseException())
        '        Else
        '            Console.WriteLine("Success calling chatter method")
        '        End If
        '    End Sub)

        myHub.On(Of String)("addMessage", _
            Sub(param)
                Console.WriteLine("Client receiving value from server: {0}", param.ToString())
            End Sub)
        myHub.On(Of String)("sendMessage", _
            Sub(param)
                Console.WriteLine(param.ToString())
            End Sub)
        'Console.ReadLine()
    End Sub
End Class
