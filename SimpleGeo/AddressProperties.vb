Namespace SimpleGeo
    Public Class AddressProperties
        Private _state_name As String
        Public Property state_name() As String
            Get
                Return _state_name
            End Get
            Set(ByVal value As String)
                _state_name = value
            End Set
        End Property

        Private _street_number As String
        Public Property street_number() As String
            Get
                Return _street_number
            End Get
            Set(ByVal value As String)
                _street_number = value
            End Set
        End Property

        Private _country As String
        Public Property country() As String
            Get
                Return _country
            End Get
            Set(ByVal value As String)
                _country = value
            End Set
        End Property

        Private _street As String
        Public Property street() As String
            Get
                Return _street
            End Get
            Set(ByVal value As String)
                _street = value
            End Set
        End Property

        Private _postal_code As String
        Public Property postal_code() As String
            Get
                Return _postal_code
            End Get
            Set(ByVal value As String)
                _postal_code = value
            End Set
        End Property

        Private _county_name As String
        Public Property county_name() As String
            Get
                Return _county_name
            End Get
            Set(ByVal value As String)
                _county_name = value
            End Set
        End Property

        Private _county_code As String
        Public Property county_code() As String
            Get
                Return _county_code
            End Get
            Set(ByVal value As String)
                _county_code = value
            End Set
        End Property

        Private _state_code As String
        Public Property state_code() As String
            Get
                Return _state_code
            End Get
            Set(ByVal value As String)
                _state_code = value
            End Set
        End Property

        Private _place_name As String
        Public Property place_name() As String
            Get
                Return _place_name
            End Get
            Set(ByVal value As String)
                _place_name = value
            End Set
        End Property
    End Class
End Namespace
