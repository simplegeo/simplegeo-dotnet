Namespace SimpleGeo
    Public Class CreateFeature
        Inherits GeoJSON.PointFeature(Of CreateProperties)

        Private _ID As String
        <Newtonsoft.Json.JsonProperty("id")> _
        Public Property ID() As String
            Get
                Return _ID
            End Get
            Set(ByVal value As String)
                _ID = value
            End Set
        End Property
    End Class
End Namespace
