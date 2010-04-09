Namespace SimpleGeo.Service
    Public Class Client
        Inherits DotNetOpenAuth.OAuth.ConsumerBase

        Public Shadows Property ServiceProvider() As Description
            Get
                Return MyBase.ServiceProvider
            End Get
            Private Set(ByVal value As Description)
            End Set
        End Property
        Public Shadows Property TokenManager() As TokenManager
            Get
                Return MyBase.TokenManager
            End Get
            Private Set(ByVal value As TokenManager)
            End Set
        End Property

        Public Sub New(ByVal Version As Version, ByVal Key As String, ByVal Secret As String)
            MyBase.New( _
                New Description(Version), _
                New TokenManager( _
                    Key, _
                    Secret))
        End Sub

        Public Function GetFeature(ByVal Layer As String, ByVal ID As String) As SimpleGeo.Feature
            Return ExecuteToObject(Of SimpleGeo.Feature)( _
                ServiceProvider.FeatureEndpoint( _
                    Layer, _
                    ID))
        End Function
        Public Sub CreateFeature(ByVal NewFeature As SimpleGeo.CreateFeature)
            Dim Endpoint = ServiceProvider.CreateEndpoint(NewFeature.Properties.layer, NewFeature.ID)

            Using New langsamu.Net.NoExpect100(Endpoint.Location)
                Dim Request = PrepareAuthorizedRequest( _
                    Endpoint, _
                    TokenManager.Secret)

                Dim Json = Newtonsoft.Json.JsonConvert.SerializeObject( _
                    NewFeature, _
                    Newtonsoft.Json.Formatting.Indented, _
                    New Newtonsoft.Json.JsonSerializerSettings With { _
                        .NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore})

                Request.ContentLength = Json.Length

                Using Writer = New IO.StreamWriter(Request.GetRequestStream)
                    Writer.Write(Json)
                End Using

                Request.GetResponse()
            End Using
        End Sub
        Public Sub DeleteFeature(ByVal Feature As SimpleGeo.Feature)
            DeleteFeature(Feature.Properties!layer, Feature.ID)
        End Sub
        Public Sub DeleteFeature(ByVal Layer As String, ByVal ID As String)
            Dim Endpoint = ServiceProvider.DeleteEndpoint(Layer, ID)

            Using New langsamu.Net.NoExpect100(Endpoint.Location)
                PrepareAuthorizedRequest( _
                    Endpoint, _
                    TokenManager.Secret).GetResponse()
            End Using
        End Sub

        Public Function GetFeatures(ByVal Layer As String, ByVal IDs As String()) As SimpleGeo.FeatureCollection
            Return ExecuteToObject(Of SimpleGeo.FeatureCollection)( _
                ServiceProvider.FeatureEndpoint( _
                    Layer, _
                    IDs.Join(",")))
        End Function

        Public Function GetAddress(ByVal Latitude As Double, ByVal Longitude As Double) As SimpleGeo.AddressFeature
            Return ExecuteToObject(Of SimpleGeo.AddressFeature)( _
                ServiceProvider.AddressEndpoint( _
                    Latitude, _
                    Longitude))
        End Function

        Public Function GetHistory(ByVal Layer As String, ByVal ID As String) As SimpleGeo.History
            Return ExecuteToObject(Of SimpleGeo.History)( _
                ServiceProvider.HistoryEndpoint( _
                    Layer, _
                    ID))
        End Function

        Public Function GetNearby(ByVal Hash As String) As SimpleGeo.FeatureCollection
            Return ExecuteToObject(Of SimpleGeo.FeatureCollection)( _
                ServiceProvider.NearbyEndpoint( _
                    Hash))
        End Function
        Public Function GetNearby(ByVal Latitude As Double, ByVal Longitude As Double) As SimpleGeo.FeatureCollection
            Return GetNearby( _
                "{0},{1}".Compose( _
                    Latitude, _
                    Longitude))
        End Function
        Public Function GetNearby(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Radius As Double, ByVal Limit As Integer, ByVal Types As String(), ByVal Start As Date, ByVal [End] As Date) As SimpleGeo.FeatureCollection
            Return ExecuteToObject(Of SimpleGeo.FeatureCollection)( _
               ServiceProvider.NearbyEndpoint( _
                   Latitude, _
                   Longitude, _
                   Radius, _
                   Limit, _
                   Types, _
                   Start, _
                   [End]))
        End Function

        Public Function GetDensity(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Day As DayOfWeek, ByVal Hour As Integer) As SimpleGeo.DensityFeature
            Return ExecuteToObject(Of SimpleGeo.DensityFeature)( _
                ServiceProvider.DensityEndpoint( _
                    Latitude, _
                    Longitude, _
                    Day, _
                    Hour))
        End Function
        Public Function GetDensity(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Day As DayOfWeek) As SimpleGeo.DensityFeature
            Return ExecuteToObject(Of SimpleGeo.DensityFeature)( _
                ServiceProvider.DensityEndpoint( _
                    Latitude, _
                    Longitude, _
                    Day))
        End Function

        Public Function GetStats() As Object
            Return ExecuteToObject(Of Object)( _
                ServiceProvider.StatsEndpoint)
        End Function

        Private Function ExecuteToObject(Of T)(ByVal Endpoint As DotNetOpenAuth.Messaging.MessageReceivingEndpoint) As T
            Using New langsamu.Net.NoExpect100(Endpoint.Location)
                Using Reader As New IO.StreamReader( _
                    PrepareAuthorizedRequest( _
                        Endpoint, _
                        TokenManager.Secret).GetResponse.GetResponseStream)

                    Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of T)( _
                        Reader.ReadToEnd)
                End Using
            End Using
        End Function
    End Class
End Namespace