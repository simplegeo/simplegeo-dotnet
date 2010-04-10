Namespace SimpleGeo
    Public Class Link

        Private _HRef As Uri
        <Newtonsoft.Json.JsonProperty("href")> _
        Public Property HRef() As Uri
            Get
                Return _HRef
            End Get
            Set(ByVal value As Uri)
                _HRef = value
            End Set
        End Property

    End Class
End Namespace
