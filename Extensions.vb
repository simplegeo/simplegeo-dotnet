Public Module Extensions
    <Runtime.CompilerServices.Extension()> _
    Public Function Compose(ByVal format As String, ByVal ParamArray args As Object()) As String
        Return String.Format( _
            Globalization.CultureInfo.InvariantCulture, _
            format, _
 _
            Aggregate arg In args _
            Let a = If(arg, String.Empty) _
            Select If( _
                TypeOf a Is IFormattable, _
                DirectCast(a, IFormattable).ToString( _
                    String.Empty, _
                    Globalization.CultureInfo.InvariantCulture), _
                a.ToString) _
            Into ToArray())

    End Function
    <Runtime.CompilerServices.Extension()> _
    Public Function Join(ByVal value As String(), ByVal separator As String) As String
        Return String.Join(separator, value)
    End Function
    <Runtime.CompilerServices.Extension()> _
    Public Function IsNullOrEmpty(ByVal original As String) As Boolean
        Return String.IsNullOrEmpty(original)
    End Function

    Private UnixEpoch As Date = #1/1/1970#.ToUniversalTime
    <Runtime.CompilerServices.Extension()> _
    Public Function ToUnixTimestamp(ByVal original As Date) As Long
        Return (original.ToUniversalTime - UnixEpoch).TotalSeconds
    End Function
    <Runtime.CompilerServices.Extension()> _
    Public Function ToDate(ByVal original As Long) As Date
        Return UnixEpoch.AddSeconds(original)
    End Function
End Module
