Namespace langsamu.Net
    ''' <summary>
    ''' Instantiates a dummy HttpWebRequest required to set shared field to turn off header Expect: 100 continue
    ''' </summary>
    ''' <remarks>See http://haacked.com/archive/2004/05/15/http-web-request-expect-100-continue.aspx#133</remarks>
    Public NotInheritable Class NoExpect100
        Implements IDisposable

        Private Dummy As System.Net.HttpWebRequest
        Private OriginalExpect100 As Boolean

        Public Sub New(ByVal target As Uri)
            Dummy = System.Net.HttpWebRequest.Create(target)
            OriginalExpect100 = Dummy.ServicePoint.Expect100Continue
            Dummy.ServicePoint.Expect100Continue = False
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dummy.ServicePoint.Expect100Continue = OriginalExpect100
        End Sub
    End Class
End Namespace
