Namespace langsamu.Json
    Public Class DayOfWeekConverter
        Inherits Newtonsoft.Json.JsonConverter

        Public Overrides Function CanConvert(ByVal objectType As System.Type) As Boolean
            Return objectType Is GetType(DayOfWeek)
        End Function

        Public Overrides Function ReadJson(ByVal reader As Newtonsoft.Json.JsonReader, ByVal objectType As System.Type, ByVal serializer As Newtonsoft.Json.JsonSerializer) As Object
            Select Case reader.Value.ToString
                Case "mon"
                    Return DayOfWeek.Monday
                Case "tue"
                    Return DayOfWeek.Tuesday
                Case "wed"
                    Return DayOfWeek.Wednesday
                Case "thu"
                    Return DayOfWeek.Thursday
                Case "fri"
                    Return DayOfWeek.Friday
                Case "sat"
                    Return DayOfWeek.Saturday
                Case "sun"
                    Return DayOfWeek.Sunday
            End Select
        End Function

        Public Overrides Sub WriteJson(ByVal writer As Newtonsoft.Json.JsonWriter, ByVal value As Object, ByVal serializer As Newtonsoft.Json.JsonSerializer)
            writer.WriteValue( _
                Globalization.CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedDayName( _
                    value).ToLower)
        End Sub
    End Class
End Namespace