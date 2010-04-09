Namespace SimpleGeo
    Public Class Feature
        Inherits GeoJSON.DictionaryFeature(Of GeoJSON.Point)

        Private _ID As String
        Public Property ID() As String
            Get
                Return _ID
            End Get
            Set(ByVal value As String)
                _ID = value
            End Set
        End Property

        Private _Distance As Double
        <Newtonsoft.Json.JsonProperty("distance")> _
        Public Property Distance() As Double
            Get
                Return _Distance
            End Get
            Set(ByVal value As Double)
                _Distance = value
            End Set
        End Property

        Private _Created As Date
        <Newtonsoft.Json.JsonProperty("created")> _
        <Newtonsoft.Json.JsonConverter(GetType(langsamu.Json.UnixTimestampConverter))> _
        Public Property Created() As Date
            Get
                Return _Created
            End Get
            Set(ByVal value As Date)
                _Created = value
            End Set
        End Property
    End Class
End Namespace
