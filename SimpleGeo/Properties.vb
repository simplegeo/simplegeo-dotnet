Namespace SimpleGeo
    Public Class Properties
        Inherits Generic.Dictionary(Of String, String)

        <Newtonsoft.Json.JsonIgnore()> _
        Public Property Layer() As String
            Get
                Return MyBase.Item("layer")
            End Get
            Set(ByVal value As String)
                MyBase.Item("layer") = value
            End Set
        End Property
        <Newtonsoft.Json.JsonIgnore()> _
        Public Property Type() As FeatureType
            Get
                Return [Enum].Parse(GetType(FeatureType), MyBase.Item("type"))
            End Get
            Set(ByVal value As FeatureType)
                MyBase.Item("type") = value.ToString.ToLower
            End Set
        End Property
    End Class
End Namespace
