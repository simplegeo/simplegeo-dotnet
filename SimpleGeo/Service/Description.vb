Imports DotNetOpenAuth.Messaging

Namespace SimpleGeo.Service
    Public Class Description
        Inherits DotNetOpenAuth.OAuth.ServiceProviderDescription

        Public Sub New(ByVal Version As Version)
            Me.Version = Version

            TamperProtectionElements = New ITamperProtectionChannelBindingElement() { _
                New DotNetOpenAuth.OAuth.ChannelElements.HmacSha1SigningBindingElement()}
        End Sub

        Public Function FeatureEndpoint(ByVal Layer As String, ByVal ID As String) As MessageReceivingEndpoint
            Return Endpoint(FeatureEndpointTemplate, Layer, ID)
        End Function
        Public Function CreateEndpoint(ByVal Layer As String, ByVal ID As String) As MessageReceivingEndpoint
            Return Endpoint( _
                HttpDeliveryMethods.PutRequest, _
                FeatureEndpointTemplate, _
                Layer, _
                ID)
        End Function
        Public Function DeleteEndpoint(ByVal Layer As String, ByVal ID As String) As MessageReceivingEndpoint
            Return Endpoint( _
                HttpDeliveryMethods.DeleteRequest, _
                FeatureEndpointTemplate, _
                Layer, _
                ID)
        End Function

        Public Function AddressEndpoint(ByVal Latitude As Double, ByVal Longitude As Double) As MessageReceivingEndpoint
            Return Endpoint( _
                "nearby/address/{0},{1}.json", _
                Latitude, _
                Longitude)
        End Function

        Public Function HistoryEndpoint(ByVal Layer As String, ByVal ID As String) As MessageReceivingEndpoint
            Return Endpoint( _
                "records/{0}/{1}/history.json", _
                Layer, _
                ID)
        End Function

        Public Function NearbyEndpoint(ByVal Query As String) As MessageReceivingEndpoint
            Return Endpoint( _
                "nearby/{0}.json", _
                Query)
        End Function
        Public Function NearbyEndpoint(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Radius As Double, ByVal Limit As Integer, ByVal Types As String(), ByVal Start As Date, ByVal [End] As Date) As MessageReceivingEndpoint
            Return Endpoint( _
                "nearby/{0},{1}.json?radius={2}&limit={3}&types={4}&start={5}&end={6}", _
                Latitude, _
                Longitude, _
                Radius, _
                Limit, _
                Types.Join(","), _
                Start.ToUnixTimestamp, _
                [End].ToUnixTimestamp)
        End Function

        Public Function DensityEndpoint(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Day As DayOfWeek, ByVal Hour As Integer) As MessageReceivingEndpoint
            Return Endpoint( _
                "density/{0}/{1}/{2},{3}.json", _
                GetDayName(Day), _
                Hour, _
                Latitude, _
                Longitude)
        End Function
        Public Function DensityEndpoint(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Day As DayOfWeek) As MessageReceivingEndpoint
            Return Endpoint( _
                "density/{0}/{1},{2}.json", _
                GetDayName(Day), _
                Latitude, _
                Longitude)
        End Function

        Public Function LayerStatsEndpoint(ByVal Layer As String) As MessageReceivingEndpoint
            Return Endpoint( _
                "stats/{0}.json", _
                Layer)
        End Function
        Public Function StatsEndpoint() As MessageReceivingEndpoint
            Return Endpoint("stats.json")
        End Function

#Region " Data "
        Private Version As Version = New Version(0, 1)
        Private Const FeatureEndpointTemplate As String = "records/{0}/{1}.json"
#End Region
#Region " Utilities "
        Private Function GetUri(ByVal Path As String) As Uri
            Dim BaseTemplate = "http://api.simplegeo.com/{0}/"
            Dim BaseAddress = BaseTemplate.Compose(Version)
            Dim BaseUri = New Uri(BaseAddress)

            Return New Uri(BaseUri, Path)
        End Function
        Private Function Endpoint(ByVal Method As HttpDeliveryMethods, ByVal Template As String, ByVal ParamArray Variables As Object()) As MessageReceivingEndpoint
            Return New MessageReceivingEndpoint( _
                GetUri( _
                    Template.Compose( _
                        Variables)), _
                Method Or HttpDeliveryMethods.AuthorizationHeaderRequest)
        End Function
        Private Function Endpoint(ByVal Template As String, ByVal ParamArray Variables As Object()) As MessageReceivingEndpoint
            Return Endpoint( _
                HttpDeliveryMethods.GetRequest, _
                Template, _
                Variables)
        End Function
        Private Function GetDayName(ByVal DayOfWeek As DayOfWeek) As String
            Return Globalization.CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek).ToLower
        End Function
#End Region
    End Class
End Namespace