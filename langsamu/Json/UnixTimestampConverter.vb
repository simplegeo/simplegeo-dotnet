Namespace langsamu.Json
    Public Class UnixTimestampConverter
        Inherits Newtonsoft.Json.JsonConverter

        Private UnixEpoch As Date = #1/1/1970#.ToUniversalTime

        Public Overrides Function CanConvert(ByVal objectType As System.Type) As Boolean
            Return objectType Is GetType(DateTime) OrElse objectType Is GetType(Nullable(Of Date))
        End Function

        Public Overrides Function ReadJson(ByVal reader As Newtonsoft.Json.JsonReader, ByVal objectType As System.Type, ByVal serializer As Newtonsoft.Json.JsonSerializer) As Object
            Dim Timestamp As Long = reader.Value

            Return Timestamp.ToDate
        End Function

        Public Overrides Sub WriteJson(ByVal writer As Newtonsoft.Json.JsonWriter, ByVal value As Object, ByVal serializer As Newtonsoft.Json.JsonSerializer)
            Dim DateValue As Date = value

            writer.WriteValue(DateValue.ToUnixTimestamp)
        End Sub
    End Class
End Namespace