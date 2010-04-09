Namespace SimpleGeo
    Public Class HistoryPoint
        Inherits GeoJSON.Point

        Private _Created As Date?
        <Newtonsoft.Json.JsonProperty("created")> _
        <Newtonsoft.Json.JsonConverter(GetType(langsamu.Json.UnixTimestampConverter))> _
        Public Property Created() As Date?
            Get
                Return _Created
            End Get
            Set(ByVal value As Date?)
                _Created = value
            End Set
        End Property
    End Class
End Namespace
