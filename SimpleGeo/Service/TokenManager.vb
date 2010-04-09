Namespace SimpleGeo.Service
    Public Class TokenManager
        Implements DotNetOpenAuth.OAuth.ChannelElements.IConsumerTokenManager

        Public Sub New(ByVal key As String, ByVal secret As String)
            _Key = key
            _Secret = secret
        End Sub

        Private _Key As String
        Public ReadOnly Property Key() As String Implements DotNetOpenAuth.OAuth.ChannelElements.IConsumerTokenManager.ConsumerKey
            Get
                Return _Key
            End Get
        End Property

        Private _Secret As String
        Public ReadOnly Property Secret() As String Implements DotNetOpenAuth.OAuth.ChannelElements.IConsumerTokenManager.ConsumerSecret
            Get
                Return _Secret
            End Get
        End Property

#Region " Not implemented "
        Public Function GetTokenType(ByVal token As String) As DotNetOpenAuth.OAuth.ChannelElements.TokenType Implements DotNetOpenAuth.OAuth.ChannelElements.ITokenManager.GetTokenType
            Throw New NotImplementedException
        End Function
        Public Sub ExpireRequestTokenAndStoreNewAccessToken(ByVal consumerKey As String, ByVal requestToken As String, ByVal accessToken As String, ByVal accessTokenSecret As String) Implements DotNetOpenAuth.OAuth.ChannelElements.ITokenManager.ExpireRequestTokenAndStoreNewAccessToken
        End Sub
        Public Function GetTokenSecret(ByVal token As String) As String Implements DotNetOpenAuth.OAuth.ChannelElements.ITokenManager.GetTokenSecret
        End Function
        Public Sub StoreNewRequestToken(ByVal request As DotNetOpenAuth.OAuth.Messages.UnauthorizedTokenRequest, ByVal response As DotNetOpenAuth.OAuth.Messages.ITokenSecretContainingMessage) Implements DotNetOpenAuth.OAuth.ChannelElements.ITokenManager.StoreNewRequestToken
        End Sub
#End Region
    End Class
End Namespace