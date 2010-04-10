Namespace SimpleGeo
    Public Class DensityProperties

        Private _Hour As Integer
        <Newtonsoft.Json.JsonProperty("hour")> _
        Public Property Hour() As Integer
            Get
                Return _Hour
            End Get
            Set(ByVal value As Integer)
                _Hour = value
            End Set
        End Property

        Private _HrendingRank As Integer
        <Newtonsoft.Json.JsonProperty("trending_rank")> _
        Public Property TrendingRank() As Integer
            Get
                Return _HrendingRank
            End Get
            Set(ByVal value As Integer)
                _HrendingRank = value
            End Set
        End Property

        Private _LocalRank As Integer
        <Newtonsoft.Json.JsonProperty("local_rank")> _
        Public Property LocalRank() As Integer
            Get
                Return _LocalRank
            End Get
            Set(ByVal value As Integer)
                _LocalRank = value
            End Set
        End Property

        Private _CityRank As Integer
        <Newtonsoft.Json.JsonProperty("city_rank")> _
        Public Property CityRank() As Integer
            Get
                Return _CityRank
            End Get
            Set(ByVal value As Integer)
                _CityRank = value
            End Set
        End Property

        Private _WorldwideRank As Integer
        <Newtonsoft.Json.JsonProperty("worldwide_rank")> _
        Public Property WorldwideRank() As Integer
            Get
                Return _WorldwideRank
            End Get
            Set(ByVal value As Integer)
                _WorldwideRank = value
            End Set
        End Property

        Private _Day As DayOfWeek
        <Newtonsoft.Json.JsonProperty("dayname")> _
        <Newtonsoft.Json.JsonConverter(GetType(langsamu.Json.DayOfWeekConverter))> _
        Public Property Day() As DayOfWeek
            Get
                Return _Day
            End Get
            Set(ByVal value As DayOfWeek)
                _Day = value
            End Set
        End Property
    End Class
End Namespace
