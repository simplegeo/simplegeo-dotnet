Namespace SimpleGeo.Service
    Public Class Client
        Inherits DotNetOpenAuth.OAuth.ConsumerBase

        Public Sub New(ByVal Version As Version, ByVal Key As String, ByVal Secret As String)
            MyBase.New( _
                New Description(Version), _
                New TokenManager( _
                    Key, _
                    Secret))
        End Sub

        Public Function GetFeature(ByVal Layer As String, ByVal ID As String) As SimpleGeo.Feature
            Return Read(Of SimpleGeo.Feature)( _
                Service.FeatureEndpoint( _
                    Layer, _
                    ID))
        End Function
        Public Sub CreateFeature(ByVal NewFeature As SimpleGeo.Feature)
            Write( _
                Service.CreateEndpoint( _
                    NewFeature.Properties.Layer, _
                    NewFeature.ID), _
                NewFeature)
        End Sub
        Public Sub CreateFeatures(ByVal Layer As String, ByVal Features As SimpleGeo.FeatureCollection)
            Write( _
                Service.CreateEndpoint( _
                    Layer), _
                Features)
        End Sub
        Public Sub DeleteFeature(ByVal Feature As SimpleGeo.Feature)
            DeleteFeature(Feature.Properties.Layer, Feature.ID)
        End Sub
        Public Sub DeleteFeature(ByVal Layer As String, ByVal ID As String)
            Dim Endpoint = Service.DeleteEndpoint(Layer, ID)

            Using New langsamu.Net.NoExpect100(Endpoint.Location)
                GetRequest(Endpoint).GetResponse()
            End Using
        End Sub

        Public Function GetFeatures(ByVal Layer As String, ByVal IDs As String()) As SimpleGeo.FeatureCollection
            Return Read(Of SimpleGeo.FeatureCollection)( _
                Service.FeatureEndpoint( _
                    Layer, _
                    IDs.Join(",")))
        End Function

        Public Function GetAddress(ByVal Latitude As Double, ByVal Longitude As Double) As SimpleGeo.AddressFeature
            Return Read(Of SimpleGeo.AddressFeature)( _
                Service.AddressEndpoint( _
                    Latitude, _
                    Longitude))
        End Function

        Public Function GetHistory(ByVal Layer As String, ByVal ID As String) As SimpleGeo.History
            Return Read(Of SimpleGeo.History)( _
                Service.HistoryEndpoint( _
                    Layer, _
                    ID))
        End Function

        Public Function GetNearby(ByVal Hash As String) As SimpleGeo.NearbyFeatureCollection
            Return Read(Of SimpleGeo.NearbyFeatureCollection)( _
                Service.NearbyEndpoint( _
                    Hash))
        End Function
        Public Function GetNearby(ByVal Latitude As Double, ByVal Longitude As Double) As SimpleGeo.NearbyFeatureCollection
            Return GetNearby( _
                "{0},{1}".Compose( _
                    Latitude, _
                    Longitude))
        End Function
        Public Function GetNearby(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Radius As Double, ByVal Limit As Integer, ByVal Types As String(), ByVal Start As Date, ByVal [End] As Date) As SimpleGeo.NearbyFeatureCollection
            Return Read(Of SimpleGeo.NearbyFeatureCollection)( _
               Service.NearbyEndpoint( _
                   Latitude, _
                   Longitude, _
                   Radius, _
                   Limit, _
                   Types, _
                   Start, _
                   [End]))
        End Function

        Public Function GetDensity(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Day As DayOfWeek, ByVal Hour As Integer) As SimpleGeo.DensityFeature
            Return Read(Of SimpleGeo.DensityFeature)( _
                Service.DensityEndpoint( _
                    Latitude, _
                    Longitude, _
                    Day, _
                    Hour))
        End Function
        Public Function GetDensity(ByVal Latitude As Double, ByVal Longitude As Double, ByVal Day As DayOfWeek) As SimpleGeo.DensityFeatureCollection
            Return Read(Of SimpleGeo.DensityFeatureCollection)( _
                Service.DensityEndpoint( _
                    Latitude, _
                    Longitude, _
                    Day))
        End Function

        'TODO: Create Layer object
        '{
        '    "callback_urls": [], 
        '    "name": /string/, 
        '    "selfLink": {
        '        "href": /url/}, 
        '    "public": /boolean/}
        Public Function GetLayer(ByVal Layer As String)
            Return Read(Of Object)( _
                Service.LayerEndpoint( _
                    Layer))
        End Function

        'TODO: Create LayerStats object
        '{
        '   "records": /int/, 
        '   "requests": {
        '       "2010-04-10 12:00": {
        '           "create": /int/, 
        '           "delete": /int, 
        '           "update": /int/, 
        '           "get": /int/}}}
        Public Function GetLayerStats(ByVal Layer As String)
            Return Read(Of Object)( _
                Service.LayerStatsEndpoint( _
                    Layer))
        End Function
        Public Function GetLayerStats(ByVal Layer As String, ByVal Start As Date, ByVal [End] As Date)
            Return Read(Of Object)( _
                Service.LayerStatsEndpoint( _
                    Layer, _
                    Start, _
                    [End]))
        End Function

        'TODO: Create Stats object
        '{
        '   "layers": [], 
        '   "requests": {
        '       "nearby": {
        '           "2010-04-10 12:00": /int/}}}
        Public Function GetStats(ByVal Start As Date, ByVal [End] As Date)
            Return Read(Of Object)( _
                Service.StatsEndpoint( _
                    Start, _
                    [End]))
        End Function
        Public Function GetStats()
            Return Read(Of Object)( _
                Service.StatsEndpoint)
        End Function

#Region " Utilities "
        Private ReadOnly Property Service() As Description
            Get
                Return MyBase.ServiceProvider
            End Get
        End Property
        Private ReadOnly Property Token() As TokenManager
            Get
                Return MyBase.TokenManager
            End Get
        End Property

        Private Function GetRequest(ByVal Endpoint As DotNetOpenAuth.Messaging.MessageReceivingEndpoint) As Net.HttpWebRequest
            Return PrepareAuthorizedRequest( _
                Endpoint, _
                Token.Secret)
        End Function

        Private Function Read(Of T)(ByVal Endpoint As DotNetOpenAuth.Messaging.MessageReceivingEndpoint) As T
            Using New langsamu.Net.NoExpect100(Endpoint.Location)
                Using Reader As New IO.StreamReader( _
                    GetRequest(Endpoint).GetResponse.GetResponseStream)

                    Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of T)( _
                        Reader.ReadToEnd)
                End Using
            End Using
        End Function
        Private Sub Write(ByVal Endpoint As DotNetOpenAuth.Messaging.MessageReceivingEndpoint, ByVal Value As Object)
            Using New langsamu.Net.NoExpect100(Endpoint.Location)
                Dim Json = Newtonsoft.Json.JsonConvert.SerializeObject( _
                    Value, _
                    Newtonsoft.Json.Formatting.Indented, _
                    New Newtonsoft.Json.JsonSerializerSettings With { _
                        .NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore})

                With GetRequest(Endpoint)
                    .ContentLength = Json.Length

                    Using Writer = New IO.StreamWriter(.GetRequestStream)
                        Writer.Write(Json)
                    End Using

                    .GetResponse()
                End With
            End Using
        End Sub
#End Region
    End Class
End Namespace