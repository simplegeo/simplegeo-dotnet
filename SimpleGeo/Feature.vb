Namespace SimpleGeo
    Public Class Feature
        Inherits GeoJSON.PointFeature(Of Properties)

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

        Private _LayerLink As Link
        <Newtonsoft.Json.JsonProperty("layerLink")> _
        Public Property LayerLink() As Link
            Get
                Return _LayerLink
            End Get
            Set(ByVal value As Link)
                _LayerLink = value
            End Set
        End Property

        Private _SelfLink As Link
        <Newtonsoft.Json.JsonProperty("selfLink")> _
        Public Property SelfLink() As Link
            Get
                Return _SelfLink
            End Get
            Set(ByVal value As Link)
                _SelfLink = value
            End Set
        End Property
    End Class
End Namespace
