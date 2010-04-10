Namespace SimpleGeo
    Public Class NearbyFeature
        Inherits Feature

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
    End Class
End Namespace
