Namespace SimpleGeo
    Public Class DensityProperties
        Private _hour As Integer
        Public Property hour() As Integer
            Get
                Return _hour
            End Get
            Set(ByVal value As Integer)
                _hour = value
            End Set
        End Property

        Private _trending_rank As Integer
        Public Property trending_rank() As Integer
            Get
                Return _trending_rank
            End Get
            Set(ByVal value As Integer)
                _trending_rank = value
            End Set
        End Property

        Private _local_rank As Integer
        Public Property local_rank() As Integer
            Get
                Return _local_rank
            End Get
            Set(ByVal value As Integer)
                _local_rank = value
            End Set
        End Property

        Private _city_rank As Integer
        Public Property city_rank() As Integer
            Get
                Return _city_rank
            End Get
            Set(ByVal value As Integer)
                _city_rank = value
            End Set
        End Property

        Private _worldwide_rank As Integer
        Public Property worldwide_rank() As Integer
            Get
                Return _worldwide_rank
            End Get
            Set(ByVal value As Integer)
                _worldwide_rank = value
            End Set
        End Property

        'TODO: convert to DayOfWeek
        Private _dayname As String
        Public Property dayname() As String
            Get
                Return _dayname
            End Get
            Set(ByVal value As String)
                _dayname = value
            End Set
        End Property
    End Class
End Namespace
